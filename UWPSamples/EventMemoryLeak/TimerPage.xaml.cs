using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace EventMemoryLeak
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TimerPage : Page
    {
        private DispatcherTimer Timer { get; set; } = new DispatcherTimer();

        public ArrayList arrayList { get; set; }

        public TimerPage()
        {
            this.InitializeComponent();
            arrayList = new ArrayList(10000000);
            Timer.Tick += Timer_Tick;
            Timer.Interval = TimeSpan.FromSeconds(1);
            Timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            int count = 0;
            int.TryParse(TextBoxTimer.Text, out count);
            count += 1;
            TextBoxTimer.Text = count.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            //Timer.Stop();
        }
    }
}
