using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.AppService;
using Windows.Foundation.Collections;

namespace GlobalKeyboardHookBackground
{
    public class KeyboardHooker
    {
        private AppServiceConnection Connection { get; set; }

        public Task IitializeTask { get; private set; }

        public KeyboardHooker()
        {
            IitializeTask = IitializeAsync();
        }

        public async Task IitializeAsync()
        {
            Connection = new AppServiceConnection();
            Connection.PackageFamilyName = Package.Current.Id.FamilyName;
            Connection.AppServiceName = "KeyboardHookConnection";
            AppServiceConnectionStatus status = await Connection.OpenAsync();
            if (status != AppServiceConnectionStatus.Success)
            {
                Debug.WriteLine(status);
            }
            var message = new ValueSet();
            message.Add("Request", "Init");
            await Connection.SendMessageAsync(message);
        }

    }
}
