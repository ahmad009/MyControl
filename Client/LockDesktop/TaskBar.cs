using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyControl_Client
{
    public static class TaskBar
    {
        private const int SW_HIDE = 0;
        private const int SW_SHOW = 1;

        public static void ShowTaskBarandOrb()
        {
            IntPtr hwnd = Imports.FindWindow("Shell_TrayWnd", "");
            Imports.ShowWindow(hwnd, SW_SHOW);

            IntPtr hwndOrb = Imports.FindWindowEx(IntPtr.Zero, IntPtr.Zero, (IntPtr)0xC017, null);
            Imports.ShowWindow(hwndOrb, SW_SHOW);
        }

        public static void HideTaskBarandOrb()
        {
            IntPtr hwnd = Imports.FindWindow("Shell_TrayWnd", null);
            Imports.ShowWindow(hwnd, SW_HIDE);

            IntPtr hwndOrb = Imports.FindWindowEx(IntPtr.Zero, IntPtr.Zero, (IntPtr)0xC017, null);
            Imports.ShowWindow(hwndOrb, SW_HIDE);
        }
    }
}
