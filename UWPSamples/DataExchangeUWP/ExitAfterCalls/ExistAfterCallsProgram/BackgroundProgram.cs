using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ExistAfterCallsProgram
{
    internal class BackgroundProgram
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool LockWorkStation();

        internal void LockScreen()
        {
            LockWorkStation();
        }
    }

    
}
