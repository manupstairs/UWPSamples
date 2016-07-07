using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentControlWithTemplateSelector
{
    public class MainViewModel
    {
        public ObservableCollection<Room> Rooms { get; set; }

        public MainViewModel()
        {
            Rooms = CreateRooms();
        }

        private ObservableCollection<Room> CreateRooms()
        {
            ObservableCollection<Room> rooms = new ObservableCollection<Room>();
            for (int i = 0; i < 1000; i++)
            {
                var room = new Room { Index = i };

                if (i % 3 == 0)
                {
                    room.Name = "Room " + i;
                    if (i % 2 == 0)
                    {
                        room.ImageUri = new Uri( "ms-appx:///Assets/testImage.jpg");
                    }
                }

                rooms.Add(room);
            }

            return rooms;
        }
    }
}
