using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
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

        public bool IsAvailable
        {
            get => RadioModel != null;
        }

        public RadioViewModel(RadioKind radioKind)
        {
            RadioKind = radioKind;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async Task InitializeAsync()
        {
            //var radios = await Radio.GetRadiosAsync();
            //RadioModel = radios.FirstOrDefault(r => r.Kind == RadioKind);
            var selectorString = Radio.GetDeviceSelector();
            var deviceInfos = await DeviceInformation.FindAllAsync(selectorString);
            foreach (var deviceInfo in deviceInfos)
            {
                var radio = await Radio.FromIdAsync(deviceInfo.Id);
                if (radio.Kind == RadioKind)
                {
                    RadioModel = radio;
                }
            }
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
