using System;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CheckMemoryLeak
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page 
    {
        public MainPage()
        {
            this.InitializeComponent();
            var viewModel = new MainViewModel();
            this.DataContext = viewModel;
            viewModel.NavigateEvent += ViewModel_NavigateEvent;
        }

        private void ViewModel_NavigateEvent(object sender, NavigationEventArgs e)
        {
            this.Frame.Navigate(Type.GetType(e.PageName), e.Parameter);
        }

        //protected override void OnNavigatedFrom(Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        //{
        //    base.OnNavigatedFrom(e);
        //    var viewModel = this.DataContext as INavigable;
        //    viewModel.OnNavigatedFrom(e.Parameter);
        //}
        
    }
}
