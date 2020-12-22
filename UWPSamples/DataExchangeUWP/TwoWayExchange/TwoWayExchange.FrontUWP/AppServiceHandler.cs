using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;

namespace TwoWayExchange.FrontUWP
{
    class AppServiceHandler
    {
        private AppServiceConnection Connection { get; set; }

        public event EventHandler<AppServiceRequestReceivedEventArgs> RequestReceived;

        public event EventHandler<AppServiceConnectionConnectedEventArgs> Connected;

        private static AppServiceHandler instance;
        public static AppServiceHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AppServiceHandler();
                }

                return instance;
            }
        }

        private AppServiceHandler()
        {

        }

        public void OnBackgroundActivated(AppServiceTriggerDetails details)
        {
            Connected?.Invoke(this, new AppServiceConnectionConnectedEventArgs(details.AppServiceConnection));
            Connection = details.AppServiceConnection;
            Connection.RequestReceived += Connection_RequestReceived;
        }

        private void Connection_RequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            RequestReceived?.Invoke(this, args);
        }
    }
}
