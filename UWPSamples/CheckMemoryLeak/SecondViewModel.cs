using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CheckMemoryLeak
{
    public class SecondViewModel : INotifyPropertyChanged, INavigable
    {
        private PersonViewModel _selectedPerson;

        public PersonViewModel SelectedPerson 
        {
            get
            {
                return _selectedPerson;
            }
            set
            {
                _selectedPerson = value;
                OnPropertyChanged();
            }
        }

        public event EventHandler GoBackEvent;
        public event EventHandler<NavigationEventArgs> NavigateEvent;
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnNavigatedFrom(object obj)
        {
            
        }

        public void OnNavigatedTo(object obj)
        {
            SelectedPerson = obj as PersonViewModel;
        }

        private void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
