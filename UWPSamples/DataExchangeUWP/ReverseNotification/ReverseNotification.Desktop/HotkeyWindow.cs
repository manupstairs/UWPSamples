using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Windows.System;

namespace ReverseNotification.Desktop
{
    public enum Modifiers
    {
        Alt = 1,
        Control = 2,
        Shift = 4,
        Windows = 8,
        NoRepeast = 16384
    }

    public class HotKeyWindow : NativeWindow
    {
        private const int WM_HOTKEY = 0x0312;
        private const int WM_DESTROY = 0x0002;

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private readonly List<int> IDs = new List<int>();
        public delegate void HotkeyDelegate(int ID);
        public event HotkeyDelegate HotkeyPressed;

        // creates a headless Window to register for and handle WM_HOTKEY
        public HotKeyWindow()
        {
            this.CreateHandle(new CreateParams());
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
        }

        public void RegisterCombo(VirtualKey key)
        {
            var keyValue = (int)key;
            if (!IDs.Contains(keyValue) && RegisterHotKey(this.Handle, keyValue, (int)Modifiers.NoRepeast, keyValue))
            {
                IDs.Add(keyValue);
            }
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            this.DestroyHandle();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_HOTKEY: //raise the HotkeyPressed event
                    HotkeyPressed?.Invoke(m.WParam.ToInt32());
                    break;

                case WM_DESTROY: //unregister all hot keys
                    foreach (int ID in IDs)
                    {
                        UnregisterHotKey(this.Handle, ID);
                    }
                    break;
            }
            base.WndProc(ref m);
        }
    }
}