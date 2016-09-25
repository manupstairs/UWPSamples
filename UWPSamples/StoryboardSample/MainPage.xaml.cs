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

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace StoryboardSample
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public List<PhotoModel> Photos { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            Photos = CreatePhotos();
            this.DataContext = this;
        }

        private List<PhotoModel> CreatePhotos()
        {
            return new List<PhotoModel>
            {
                new PhotoModel {  ImageUri = new Uri("ms-appx:///Assets/0.jpg")},
                new PhotoModel {  ImageUri = new Uri("ms-appx:///Assets/1.jpg")},
                new PhotoModel {  ImageUri = new Uri("ms-appx:///Assets/2.jpg")},
                new PhotoModel {  ImageUri = new Uri("ms-appx:///Assets/3.jpg")},
                new PhotoModel {  ImageUri = new Uri("ms-appx:///Assets/4.jpg")},
                new PhotoModel {  ImageUri = new Uri("ms-appx:///Assets/5.jpg")},
                new PhotoModel {  ImageUri = new Uri("ms-appx:///Assets/6.jpg")},
                new PhotoModel {  ImageUri = new Uri("ms-appx:///Assets/7.jpg")},
                new PhotoModel {  ImageUri = new Uri("ms-appx:///Assets/8.jpg")},
                new PhotoModel {  ImageUri = new Uri("ms-appx:///Assets/9.jpg")}
            };
        }
    }
}
