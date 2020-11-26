using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;

namespace OnewayRequest.FrontUWP
{
    public class AppServiceConnectionConnectedEventArgs : EventArgs
    {
        public AppServiceConnection Connection { get; }

        public AppServiceConnectionConnectedEventArgs(AppServiceConnection connection)
        {
            Connection = connection;
        }
    }
}
