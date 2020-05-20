using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Radios;

namespace RadioDevice
{
    public class BluetoothViewModel : RadioViewModel
    {
        public BluetoothViewModel(): base(RadioKind.Bluetooth)
        {
            
        }
    }
}
