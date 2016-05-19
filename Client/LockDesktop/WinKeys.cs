using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MyControl_Client
{
    public static class DisableWinKeys
    {
        [StructLayout(LayoutKind.Sequential)]

        private struct KBDLLHOOKSTRUCT
        {
            public Keys key;
            public int scanCode;
            public int flags;
            public int time;
            public IntPtr extra;
        }

        static IntPtr ptrHook;
        static Imports.LowLevelKeyboardProc objKeyboardProcess;
        public static bool Lock = false;


        private static string[] keystrs = new string[] {
         "backspace",
         "delete",
         "tab",
         "clear",
         "return",
         "pause",
         "escape",
         "space",
         "up",
         "down",
         "right",
         "left",
         "insert",
         "home",
         "end",
         "page up",
         "page down",
         "f1",
         "f2",
         "f3",
         "f4",
         "f5",
         "f6",
         "f7",
         "f8",
         "f9",
         "f10",
         "f11",
         "f12",
         "f13",
         "f14",
         "f15",
         "0",
         "1",
         "2",
         "3",
         "4",
         "5",
         "6",
         "7",
         "8",
         "9",
         "!",
         "\"",
         "#",
         "$",
         "&",
         "'",
         "(",
         ")",
         "*",
         "+",
         ",",
         "-",
         ".",
         "/",
         ":",
         ";",
         "<",
         "=",
         ">",
         "?",
         "@",
         "[",
         "\\",
         "]",
         "^",
         "_",
         "`",
         "a",
         "b",
         "c",
         "d",
         "e",
         "f",
         "g",
         "h",
         "i",
         "j",
         "k",
         "l",
         "m",
         "n",
         "o",
         "p",
         "q",
         "r",
         "s",
         "t",
         "u",
         "v",
         "w",
         "x",
         "y",
         "z",
         "numlock",
         "caps lock",
         "scroll lock",
         "right shift",
         "left shift",
         "right ctrl",
         "left ctrl",
         "right alt",
         "left alt"
        };

        public static IntPtr captureKey(int nCode, IntPtr wp, IntPtr lp)
        {
            Thread.Sleep(50);

            if (nCode >= 0)
            {
                KBDLLHOOKSTRUCT objKeyInfo = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lp, typeof(KBDLLHOOKSTRUCT));
                if (Lock)
                {
                    //Log.Write("DisableWinKeys", objKeyInfo.key.ToString());

                    //Disable keys: alt, ctrl, delete, tab, esc and win key
                    //bool blnEat = false;

                    /*if ((int)wp == 261)
                    {
                        //Log.Write("DisableWinKeys", "OK");
                        blnEat = ((objKeyInfo.scanCode == 9) && (objKeyInfo.flags == 32)) | ((objKeyInfo.scanCode == 27) && (objKeyInfo.flags == 32)) | ((objKeyInfo.scanCode == 27) && (objKeyInfo.flags == 0)) | ((objKeyInfo.scanCode == 91) && (objKeyInfo.flags == 1)) | ((objKeyInfo.scanCode == 92) && (objKeyInfo.flags == 1)) | ((objKeyInfo.scanCode == 73) && (objKeyInfo.flags == 0));
                    }*/

                    
                    if (objKeyInfo.key.ToString() == "RMenu" || objKeyInfo.key.ToString() == "LMenu")//right alt
                    {
                        return (IntPtr)1;
                    }
                    else if (objKeyInfo.key == Keys.Escape)
                    {
                        return (IntPtr)1;
                    }
                    else if (objKeyInfo.key == Keys.Delete)
                    {
                        return (IntPtr)1;
                    }
                    else if (objKeyInfo.key == Keys.Tab)
                    {
                        return (IntPtr)1;
                    }
                    else if (objKeyInfo.key == Keys.Tab)
                    {
                        return (IntPtr)1;
                    }
                    else if (objKeyInfo.key == Keys.LControlKey || objKeyInfo.key == Keys.RControlKey)
                    {
                        return (IntPtr)1;
                    }
                    else if (objKeyInfo.key == Keys.RWin || objKeyInfo.key == Keys.LWin)
                    {
                        return (IntPtr)1;
                    }
                }
            }
            return Imports.CallNextHookEx(ptrHook, nCode, wp, lp);
        }
    }
}
