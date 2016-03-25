using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ListViewExSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<int> Items { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            InitData();
            this.listViewEx.LoadHistoryEvent += ListViewEx_LoadHistoryEvent;
        }

        private void ListViewEx_LoadHistoryEvent(object sender, EventArgs e)
        {
            Insert5Item(5);
        }

        private void Insert5Item(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Items.Insert(0, Items.Count + 1);
            }
        }

        private void InitData()
        {
            Items = new ObservableCollection<int>();
            Insert5Item(20);
        }
    }
}
