using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace UseWebView
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SecondPage : Page//, INotifyPropertyChanged
    {
        public string HtmlContent
        {
            get
            {
                // return "<p> <img id =\"pic\" class=\"M_cur_zoom_out\" src=\"http://ww4.sinaimg.cn/large/41467e42jw1f8himcfgnoj20gj1ax793.jpg\" /> </p> <p> 微信订阅号 zhangzishi_weixin 合作请直接联系 tintin@zhangzishi.cc</p>";
                return "<p> <img src =\"http://ww3.sinaimg.cn/mw690/9e6b7fdbjw1f8m2oaw2hbj20k00qogoi.jpg\"  /></p>";
            }
        }

        //private string htmlContent2;
        //public string HtmlContent2
        //{
        //    get { return htmlContent2; }
        //    set
        //    {
        //        htmlContent2 = value;
        //        this.OnPropertyChanged();
        //    }
        //}

        //public event PropertyChangedEventHandler PropertyChanged;

        //private void OnPropertyChanged([CallerMemberName] string name = null)
        //{
        //    this.PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(name));
        //}

        public SecondPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    this.HtmlContent2 = HtmlContent;
        //}
    }
}
