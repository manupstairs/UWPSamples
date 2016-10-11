using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UseWebView
{
    public class WebViewEx
    {
        public static string GetUri(DependencyObject obj)
        {
            return (string)obj.GetValue(UriProperty);
        }

        public static void SetUri(DependencyObject obj, string value)
        {
            obj.SetValue(UriProperty, value);
        }

        // Using a DependencyProperty as the backing store for WebViewUri.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UriProperty =
            DependencyProperty.RegisterAttached("Uri", typeof(string), typeof(WebViewEx), new PropertyMetadata(null, PropertyChangedCallback));

        private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var webView = d as WebView;
            webView.NavigateToString(e.NewValue.ToString());
        }



        public static string GetAdaptiveUri(DependencyObject obj)
        {
            return (string)obj.GetValue(AdaptiveUriProperty);
        }

        public static void SetAdaptiveUri(DependencyObject obj, string value)
        {
            obj.SetValue(AdaptiveUriProperty, value);
        }

        // Using a DependencyProperty as the backing store for AdaptiveUri.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AdaptiveUriProperty =
            DependencyProperty.RegisterAttached("AdaptiveUri", typeof(string), typeof(WebViewEx), new PropertyMetadata(null, UriPropertyChangedCallback));

        private static void UriPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var webView = d as WebView;
            var adaptive = e.NewValue.ToString().Replace("<img", "<img width=100%");
            webView.NavigateToString(adaptive);
        }

       
    }
}
