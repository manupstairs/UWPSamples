using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KeepUIResponsive
{
    public class ListViewModel : INavigable, INotifyPropertyChanged
    {
        private ObservableCollection<Person> personList;

        public ObservableCollection<Person> PersonList
        {
            get { return personList; }
            set
            {
                personList = value;
                OnPropertyChanged();
            }
        }

        private string notify;

        public string Notify
        {
            get { return notify; }
            set
            {
                notify = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void OnNavigatedFrom(object obj)
        {
           
        }

        public async void OnNavigatedTo(object obj)
        {
            var watch = new Stopwatch();
            Debug.WriteLine("---------------Start");
            watch.Start();

            ////假设耗时1秒
            //Task.Run(()=> { DoBusyWork(); });
            ////耗时1秒
            //int count = GetPersonCount();
            ////假设每创建一个Person耗时500毫秒
            //PersonList = CreatePersonList(count);

            //不必要的等待,耗时1秒
            DoBusyWorkAsync();
            //耗时1秒，返回数字100
            int count = await GetPersonCountAsync();
            //依然会造成长时间阻塞的Get方法
            //PersonList = await CreatePersonListAsync(count);
            PersonList = CreatePersonListWithContinue(count);

            watch.Stop();
            Debug.WriteLine(watch.ElapsedMilliseconds);
            Debug.WriteLine("----------------Stop");

            Notify = "页面初始化已完成！计时：" + watch.ElapsedMilliseconds + "毫秒";
        }

        private void DoBusyWork()
        {
            Task.Delay(1000).Wait();
        }

        private async void DoBusyWorkAsync()
        {
            await Task.Delay(1000);
        }

        private int GetPersonCount()
        {
            int count = 10;
            Task.Delay(1000).Wait();
            return count;
        }

        private async Task<int> GetPersonCountAsync()
        {
            int count = 10;
            await Task.Delay(1000);
            return count;
        }

        private ObservableCollection<Person> CreatePersonList(int count)
        {
            var list = new ObservableCollection<Person>();
            for (int i = 0; i < count; i++)
            {
                var person = Person.CreatePreson(i,i.ToString());
                list.Add(person);
            }

            return list;
        }

        private ObservableCollection<Person> CreatePersonListWithContinue(int count)
        {
            var list = new ObservableCollection<Person>();
            for (int i = 0; i < count; i++)
            {
                Person.CreatePresonAsync(i, i.ToString()).ContinueWith(_ => {
                    var person = _.Result;
                    int index = list.Count(p => p.Age < person.Age);
                    list.Insert(index, person);
                },TaskScheduler.FromCurrentSynchronizationContext());
            }

            return list;
        }

        private async Task<ObservableCollection<Person>> CreatePersonListAsync(int count)
        {
            var list = new ObservableCollection<Person>();
            for (int i = 0; i < count; i++)
            {
                var person = await Person.CreatePresonAsync(i, i.ToString());
                list.Add(person);
            }
            return list;
        }
    }
}
