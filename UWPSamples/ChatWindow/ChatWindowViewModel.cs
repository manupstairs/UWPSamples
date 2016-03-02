using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWindow
{
    public class ChatWindowViewModel
    {
        public List<MessageBase> MessageList { get; set; }

        public ChatWindowViewModel()
        {
            InitSampleData();
        }

        private void InitSampleData()
        {
            MessageList = new List<MessageBase>
            {
                new Message
                {
                    Comment = "天王盖地虎", Name="张三" ,Published = DateTime.Now
                },
                new Message
                {
                    Comment = "宝塔镇河妖", IsSelf = true, Name="政委",Published = DateTime.Now
                },
                new Gift
                {
                    Amount = 100, Comment = "这是我的党费", Name="张三",Published = DateTime.Now
                },
                new Message
                {
                    Comment = "收到，你安心的去吧，组织不会忘记你的", IsSelf = true, Name="政委",Published = DateTime.Now
                }
            };
        }
    }
}
