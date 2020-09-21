using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;
using Windows.Foundation.Collections;

namespace FrontUWPApp
{
    class AppServiceHandler
    {
        private AppServiceConnection AppServiceConnection { get; set; }
        private BackgroundTaskDeferral AppServiceDeferral { get; set; }

        public event EventHandler<string> MessageReceivedEvent;

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

        public void BackgroundActivated(IBackgroundTaskInstance taskInstance)
        {
            AppServiceTriggerDetails appService = taskInstance.TriggerDetails as AppServiceTriggerDetails;
            AppServiceDeferral = taskInstance.GetDeferral();
            AppServiceConnection = appService.AppServiceConnection;
            AppServiceConnection.RequestReceived += OnAppServiceRequestReceived;
            AppServiceConnection.ServiceClosed += AppServiceConnection_ServiceClosed;
        }

        private void OnAppServiceRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            AppServiceDeferral messageDeferral = args.GetDeferral();
            var message = args.Request.Message;
            string text = message["response"] as string;

            MessageReceivedEvent?.Invoke(this, text);
            messageDeferral.Complete();
        }

        private void AppServiceConnection_ServiceClosed(AppServiceConnection sender, AppServiceClosedEventArgs args)
        {
            AppServiceDeferral.Complete();
        }

        public async Task<AppServiceResponse> SendRequestAsync(string message)
        {
            var valueSet = new ValueSet();
            valueSet.Add("request", message);
            return await AppServiceConnection.SendMessageAsync(valueSet);
        }
    }
}
