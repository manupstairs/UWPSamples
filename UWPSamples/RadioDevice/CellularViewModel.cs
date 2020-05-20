using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioDevice
{
    public class CellularViewModel : RadioViewModel
    {
        public CellularViewModel() : base(Windows.Devices.Radios.RadioKind.MobileBroadband) { }
    }
}
