using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace ListViewExSample
{
    public class ListViewEx : ListView, INotifyPropertyChanged
    {
        private ScrollViewer _scrollViewer;
                
        private Visibility _goBottomVisiblity = Visibility.Collapsed;

        public Visibility GoBottomVisiblity
        {
            get { return _goBottomVisiblity; }
            set
            {
                _goBottomVisiblity = value;
                this.OnProperyChanged();
            }
        }


        public event EventHandler LoadHistoryEvent;
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnProperyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ListViewEx()
        {
            this.Loaded += ListViewEx_Loaded;
            this.Unloaded += ListViewEx_Unloaded;
        }

        private void ListViewEx_Unloaded(object sender, RoutedEventArgs e)
        {
            this.Unloaded -= ListViewEx_Unloaded;
            if (_scrollViewer != null)
            {
                _scrollViewer.ViewChanged -= Sv_ViewChanged;
                _scrollViewer.ViewChanged -= Sv_ViewChanged2;
            }
        }

        private void ListViewEx_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Loaded -= ListViewEx_Loaded;
            _scrollViewer = FindFirstChild<ScrollViewer>(this);
            if (_scrollViewer != null)
            {
                _scrollViewer.ViewChanged += Sv_ViewChanged;
                _scrollViewer.ViewChanged += Sv_ViewChanged2;
            }
        }

        private async void Sv_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            if (e.IsIntermediate == false && _scrollViewer.VerticalOffset < 1)
            {
                _scrollViewer.ChangeView(null, 50, null);
                await Task.Delay(10);
                LoadHistoryEvent?.Invoke(this, EventArgs.Empty);
            }
        }

        private void Sv_ViewChanged2(object sender, ScrollViewerViewChangedEventArgs e)
        {
            if (e.IsIntermediate == false)
            {
                CheckGoBottomVisibility();
            }
        }

        private void CheckGoBottomVisibility()
        {
            if (_scrollViewer.VerticalOffset + _scrollViewer.ViewportHeight < _scrollViewer.ScrollableHeight)
            {
                GoBottomVisiblity = Visibility.Visible;
            }
            else
            {
                GoBottomVisiblity = Visibility.Collapsed;
            }
        }

        static T FindFirstChild<T>(FrameworkElement element) where T : FrameworkElement
        {
            int childrenCount = VisualTreeHelper.GetChildrenCount(element);
            var children = new FrameworkElement[childrenCount];

            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(element, i) as FrameworkElement;
                children[i] = child;
                if (child is T)
                    return (T)child;
            }

            for (int i = 0; i < childrenCount; i++)
                if (children[i] != null)
                {
                    var subChild = FindFirstChild<T>(children[i]);
                    if (subChild != null)
                        return subChild;
                }

            return null;
        }
    }
}
