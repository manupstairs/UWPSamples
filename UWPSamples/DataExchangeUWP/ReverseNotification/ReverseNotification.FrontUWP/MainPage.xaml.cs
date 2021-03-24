using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
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
