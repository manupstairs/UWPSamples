using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace ContentControlWithTemplateSelector
{
    public class RoomTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var room = value as Room;
            var roomType = parameter.ToString();

            if (roomType == "Default")
            {
                if (room.ImageUri == null && string.IsNullOrEmpty(room.Name))
                {
                    return Visibility.Visible;
                }
            }
            else if (roomType == "Name")
            {
                if (string.IsNullOrEmpty(room.Name) == false && room.ImageUri == null)
                {
                    return Visibility.Visible;
                }
            }
            else
            {
                if (room.ImageUri != null)
                {
                    return Visibility.Visible;
                }
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
