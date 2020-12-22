using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TwoWayExchange.FrontUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page 
    {
        public MainPage()
        {
            this.InitializeComponent();
            AppServiceHandler.Instance.RequestReceived += Instance_RequestReceived;
        }

        private void Instance_RequestReceived(object sender, Windows.ApplicationModel.AppService.AppServiceRequestReceivedEventArgs e)
        {
            var message = e.Request.Message;
            if (message.Keys.Contains("Desktop"))
            {
                this.textBoxReceive.Text += $"{message["receive"]}\n";
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ApiInformation.IsApiContractPresent("Windows.ApplicationModel.FullTrustAppContract", 1, 0))
            {
                AppServiceHandler.Instance.Connected += Instance_Connected;
                await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync();
            }
        }

        private async void Instance_Connected(object sender, AppServiceConnectionConnectedEventArgs e)
        {
            AppServiceHandler.Instance.Connected -= Instance_Connected;
            var valueSet = new ValueSet();
            valueSet.Add("UWP", this.textBoxSend.Text);
            var response = await e.Connection.SendMessageAsync(valueSet);
        }
    }
}
