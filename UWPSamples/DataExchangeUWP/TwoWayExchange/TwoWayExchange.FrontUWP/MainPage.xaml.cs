﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.AppService;
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
        private AppServiceConnection Connection { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            if (ApiInformation.IsApiContractPresent("Windows.ApplicationModel.FullTrustAppContract", 1, 0))
            {
                AppServiceHandler.Instance.Connected += Instance_Connected;
                FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync();
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var valueSet = new ValueSet();
            valueSet.Add("UWP", this.textBoxSend.Text);
            var response = await Connection.SendMessageAsync(valueSet);
        }

        private void Instance_Connected(object sender, AppServiceConnectionConnectedEventArgs e)
        {
            AppServiceHandler.Instance.Connected -= Instance_Connected;
            Connection = e.Connection;
            Connection.RequestReceived += Connection_RequestReceived;
        }

        private async void Connection_RequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            var message = args.Request.Message;
            if (message.TryGetValue("Desktop", out object content))
            {
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                { this.textBoxReceive.Text += $"{content}\n"; });
            }
        }
    }
}
