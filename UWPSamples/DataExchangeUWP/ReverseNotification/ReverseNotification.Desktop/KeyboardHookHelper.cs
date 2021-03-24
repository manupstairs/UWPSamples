using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Windows.ApplicationModel;
using Windows.ApplicationModel.AppService;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.System;

namespace ReverseNotification.Desktop
{
    internal class KeyboardHookHelper : ApplicationContext
    {
        private Process process = null;

        private HotKeyWindow HotKeyWindow { get; set; }

        public KeyboardHookHelper()
        {
            Initialize();
        }

        private void Initialize()
        {
            int processId = (int)ApplicationData.Current.LocalSettings.Values["processId"];
            process = Process.GetProcessById(processId);
            process.EnableRaisingEvents = true;
            process.Exited += HotkeyAppContext_Exited;
            HotKeyWindow = new HotKeyWindow();
            HotKeyWindow.HotkeyPressed += new HotKeyWindow.HotkeyDelegate(hotkeys_HotkeyPressed);
            RegisterEvent();
        }

        private void HotkeyAppContext_Exited(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void hotkeys_HotkeyPressed(int ID)
        {
            var key = Enum.GetName(typeof(VirtualKey), ID);

            var message = new ValueSet
            {
                { "HotKey", key }
            };

            var connection = new AppServiceConnection
            {
                PackageFamilyName = Package.Current.Id.FamilyName,
                AppServiceName = "ReverseNotificationAppService"
            };
            connection.ServiceClosed += Connection_ServiceClosed;

            var status = await connection.OpenAsync();
            if (status == AppServiceConnectionStatus.Success)
            {
                var response = await connection.SendMessageAsync(message);
            }
        }

        private void Connection_ServiceClosed(AppServiceConnection sender, AppServiceClosedEventArgs args)
        {
            Console.WriteLine("Connection_ServiceClosed");
        }

        private void RegisterEvent()
        {
            List<VirtualKey> vKeys = new List<VirtualKey>
            {
                VirtualKey.W,
                VirtualKey.A,
                VirtualKey.S,
                VirtualKey.D
            };
            foreach (VirtualKey key in vKeys)
            {
                HotKeyWindow.RegisterCombo(key);
            }
        }
    }
}