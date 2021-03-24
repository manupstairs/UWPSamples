using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Windows.ApplicationModel;
using Windows.Foundation.Metadata;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ReverseNotification.FrontUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<string> hotKeyList = new ObservableCollection<string>();

        public ObservableCollection<string> HotKeyList
        {
            get { return hotKeyList; }
            set { hotKeyList = value; }
        }


        public MainPage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Process process = Process.GetCurrentProcess();
            ApplicationData.Current.LocalSettings.Values["processId"] = process.Id;
            if (ApiInformation.IsApiContractPresent("Windows.ApplicationModel.FullTrustAppContract", 1, 0))
            {
                await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync();
            }
            AppServiceHandler.Instance.RequestReceived += Instance_RequestReceived;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            AppServiceHandler.Instance.RequestReceived -= Instance_RequestReceived;
        }

        private void Instance_RequestReceived(object sender, Windows.ApplicationModel.AppService.AppServiceRequestReceivedEventArgs e)
        {
            var message = e.Request.Message;
            if (message.TryGetValue("HotKey", out object keyCode))
            {
                HotKeyList.Add(keyCode.ToString());
            }
        }
    }
}
