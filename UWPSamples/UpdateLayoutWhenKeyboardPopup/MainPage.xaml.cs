using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace UpdateLayoutWhenKeyboardPopup
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            InputPane.GetForCurrentView().Showing += MainPage_Showing;
            InputPane.GetForCurrentView().Hiding += MainPage_Hiding;
        }

        private void MainPage_Hiding(InputPane sender, InputPaneVisibilityEventArgs args)
        {
            this.rowBottom.Height = new GridLength(1, GridUnitType.Star);
        }

        private void MainPage_Showing(InputPane sender, InputPaneVisibilityEventArgs args)
        {
            this.rowBottom.Height = new GridLength(args.OccludedRect.Height);
        }
    }
}
