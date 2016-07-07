using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ContentControlWithTemplateSelector
{
    public class CustomTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var room = item as Room;
            if (item == null)
            {
                return base.SelectTemplateCore(item, container);
            }
            if (room.ImageUri == null)
            {
                if (string.IsNullOrEmpty(room.Name))
                {
                    return App.Current.Resources["Default"] as DataTemplate;
                }

                return App.Current.Resources["Name"] as DataTemplate;
            }

            return App.Current.Resources["Image"] as DataTemplate;

            
        }
    }
}
