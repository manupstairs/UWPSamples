using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMemoryLeak
{
    public class NavigationEventArgs
    {
        public string PageName { get; set; }

        public object Parameter { get; set; }
    }
}
