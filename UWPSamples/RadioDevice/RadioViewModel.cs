using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Radios;


namespace RadioDevice
{
    public class RadioViewModel : INotifyPropertyChanged
    {
        private RadioKind RadioKind { get; }

        private Radio RadioModel { get; set; }

        public bool IsOn
        {
            get => RadioModel?.State == RadioState.On ? true : false;
            set
            {
                SetRadioStatusAsync(value);
            }
        }

        public RadioViewModel(RadioKind radioKind)
        {
            RadioKind = radioKind;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async Task InitializeAsync()
        {
            var radios = await Radio.GetRadiosAsync();
            RadioModel = radios.FirstOrDefault(r => r.Kind == RadioKind);
            this.OnPropertyChanged("IsOn");
        }

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private async void SetRadioStatusAsync(bool isOn)
        {
            if (RadioAccessStatus.Allowed == await Radio.RequestAccessAsync())
            {
                var state = isOn ? RadioState.On : RadioState.Off;
                await RadioModel.SetStateAsync(state);
            }
        }
    }
}
