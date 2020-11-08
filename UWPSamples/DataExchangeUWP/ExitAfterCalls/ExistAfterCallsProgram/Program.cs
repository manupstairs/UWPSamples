using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ExistAfterCallsProgram
{
    class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool LockWorkStation();

        static void Main(string[] args)
        {
            string funcName = args[2];
            switch (funcName)
            {
                case "LockScreen":
                    LockWorkStation();
                    break;
                case "ControlPanel":
                    Process.Start("control.exe");
                    break;
                case "LocalSettings":
                    var content = ApplicationData.Current.LocalSettings.Values["content"].ToString();
                    Process.Start(content);
                    break;

            }
        }
    }
}
