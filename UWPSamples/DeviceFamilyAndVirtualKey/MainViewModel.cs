using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.System;
using Windows.System.Profile;
using Windows.UI.Xaml.Input;

namespace DeviceFamilyAndVirtualKey
{
    public class MainViewModel : ViewModelBase
    {
        private bool _isShiftKeyPressed;

        public ICommand KeyUpCommand { get; set; }

        public ICommand KeyDownCommand { get; set; }

        public ICommand SendMessageCommand { get; set; }

        public bool IsAcceptReturn
        {
            get
            {
                return AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile";
            }
        }

        private string _inputText;
        public string InputText
        {
            get
            {
                return _inputText;
            }
            set
            {
                Set(ref _inputText, value);
            }
        }

        private int _index;

        public int Index
        {
            get { return _index; }
            set { Set( ref _index , value); }
        }

        public ObservableCollection<string> Messages { get; set; } = new ObservableCollection<string>();

        public MainViewModel()
        {
            KeyDownCommand = new RelayCommand<KeyRoutedEventArgs>(KeyDown);
            KeyUpCommand = new RelayCommand<KeyRoutedEventArgs>(KeyUp);
            SendMessageCommand = new RelayCommand(SendMessage);
        }

        private void KeyUp(KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                if (_isShiftKeyPressed)
                {
                    int oldIndex = Index;
                    InputText = InputText.Replace(Environment.NewLine, "\n").Insert(Index, "\n");
                    Index = oldIndex + 1;
                }
                else if (IsAcceptReturn == false)
                {
                    SendMessage();
                }
            }
            _isShiftKeyPressed = false;
        }
        
        private void KeyDown(KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Shift)
            {
                _isShiftKeyPressed = true;
            }
        }

        private void SendMessage()
        {
            if (string.IsNullOrEmpty(InputText) == false)
            {
                Messages.Add(InputText);
                InputText = string.Empty;
            }
        }

    }
}
