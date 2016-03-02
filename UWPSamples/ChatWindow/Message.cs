using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWindow
{
    public abstract class MessageBase
    {
        public string Name { get; set; }

        public DateTime Published { get; set; }
    }

    public class Message : MessageBase
    {
        public string Comment { get; set; }

        public bool IsSelf { get; set; }
    }

    public class Gift : Message
    {
        public int Amount { get; set; }
    }
}
