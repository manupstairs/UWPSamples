using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace ReverseNotification.Desktop
{
    class Program
    {
        static void Main(string[] args)
        {
            KillPreviousInstance();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new KeyboardHookHelper());
        }

        private static void KillPreviousInstance()
        {
            Process currentProcess = Process.GetCurrentProcess();
            Process[] processItems = Process.GetProcessesByName(currentProcess.ProcessName);
            if (processItems.Length > 1)
            {
                processItems.Where(p => p.Id != Process.GetCurrentProcess().Id).First().Kill();
            }
        }
    }
}
