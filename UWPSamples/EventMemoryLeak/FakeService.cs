using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMemoryLeak
{
    public class FakeService
    {
        public static FakeService Instance = new FakeService();

        public event EventHandler ShowMeTheMoneyEvent;

        private FakeService() { }
    }
}
