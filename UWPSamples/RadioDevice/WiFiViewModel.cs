using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Radios;

namespace RadioDevice
{
    public class WiFiViewModel : RadioViewModel
    {
        public WiFiViewModel() : base(RadioKind.WiFi)
        {

        }
    }
}
