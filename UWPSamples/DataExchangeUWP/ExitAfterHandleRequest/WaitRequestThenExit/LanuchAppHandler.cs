﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.AppService;
using Windows.Foundation.Collections;

namespace WaitRequestThenExit
{
    class LanuchAppHandler
    {
        private AppServiceConnection Connection { get; set; }

        public Task InitializeTask { get; private set; }

        public LanuchAppHandler()
        {
            InitializeTask = InitializeAsync();
        }

        public async Task InitializeAsync()
        {
            Connection = new AppServiceConnection();
            Connection.PackageFamilyName = Package.Current.Id.FamilyName;
            Connection.AppServiceName = "ParameterAppService";
            AppServiceConnectionStatus status = await Connection.OpenAsync();
            if (status != AppServiceConnectionStatus.Success)
            {
                Console.WriteLine(status);
            }
            else
            {
                Console.WriteLine(status);
                Connection.RequestReceived += Connection_RequestReceived;
            }
        }

        private void Connection_RequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            var content = args.Request.Message["FileName"].ToString();
            Process.Start(content);
            Console.WriteLine("Will exit after received.");
            //Environment.Exit(0);
        }
    }
}
