using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LiveVisualTreeTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public List<string> People { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            People = new List<string>
            {
                "张 三",
                "李 四",
                "王 五",
                "赵 六"
            };
            this.DataContext = this;
        }

        private async void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var text = (e.OriginalSource as TextBlock)?.Text;
            MessageDialog dialog = new MessageDialog(text);
            await dialog.ShowAsync();
        }
    }
}
