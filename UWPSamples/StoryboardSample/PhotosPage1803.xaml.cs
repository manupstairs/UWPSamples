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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StoryboardSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PhotosPage1803 : Page
    {
        public List<PhotoModel> Photos { get; set; }

        private Popup popup = new Popup();

        public PhotosPage1803()
        {
            this.InitializeComponent();
            Photos = CreatePhotos();
            this.DataContext = this;
            popup.RenderTransform = new TranslateTransform();
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

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            popup.IsOpen = false;

            var tappedImage = e.OriginalSource as Image;
            var image = new Image { Source = tappedImage.Source };
            popup.Child = image;
            popup.IsOpen = true;

            //获取被点击图片相对MainPage的坐标
            var position = tappedImage.TransformToVisual(this).TransformPoint(new Point());
            //获取MainPage的中心坐标
            var xCenter = ActualWidth / 2 - 200;
            var yCenter = ActualHeight / 2 - 200;

            var storyBoard = new Storyboard();
            var extendAnimation = new DoubleAnimation { Duration = new Duration(TimeSpan.FromSeconds(0.5)), From = 200, To = 400, EnableDependentAnimation = true };
            Storyboard.SetTarget(extendAnimation, image);
            Storyboard.SetTargetProperty(extendAnimation, "Width");
            Storyboard.SetTargetProperty(extendAnimation, "Height");

            var xAnimation = new DoubleAnimation { Duration = new Duration(TimeSpan.FromSeconds(0.5)), From = position.X, To = xCenter, EnableDependentAnimation = true };
            Storyboard.SetTarget(xAnimation, popup);
            Storyboard.SetTargetProperty(xAnimation, "(UIElement.RenderTransform).(TranslateTransform.X)");

            var yAnimation = new DoubleAnimation { Duration = new Duration(TimeSpan.FromSeconds(0.5)), From = position.Y, To = yCenter, EnableDependentAnimation = true };
            Storyboard.SetTarget(yAnimation, popup);
            Storyboard.SetTargetProperty(yAnimation, "(UIElement.RenderTransform).(TranslateTransform.Y)");

            storyBoard.Children.Add(extendAnimation);
            storyBoard.Children.Add(xAnimation);
            storyBoard.Children.Add(yAnimation);

            storyBoard.Begin();
        }
    }
}
