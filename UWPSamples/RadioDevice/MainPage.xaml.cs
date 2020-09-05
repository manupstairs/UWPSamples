using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Radios;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RadioDevice
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public BluetoothViewModel BluetoothViewModel { get; private set; }

        public WiFiViewModel WiFiViewModel { get; private set; }

        public CellularViewModel CellularViewModel { get; private set; }

        public MainPage()
        {
            this.InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            BluetoothViewModel = new BluetoothViewModel();
            await BluetoothViewModel.InitializeAsync();
            this.OnPropertyChanged("BluetoothViewModel");
            WiFiViewModel = new WiFiViewModel();
            await WiFiViewModel.InitializeAsync();
            this.OnPropertyChanged("WiFiViewModel");

            CellularViewModel = new CellularViewModel();
            await CellularViewModel.InitializeAsync();
            this.OnPropertyChanged("CellularViewModel");
        }

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
