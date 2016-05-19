using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyControl_Client
{
    public static class ChangePassword
    {
        public static void DisableChangePassword()//disable task manager
        {
            RegistryKey regkey;
            string keyValueInt = "1";
            string subKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";

            try
            {
                regkey = Registry.CurrentUser.CreateSubKey(subKey);
                regkey.SetValue("DisableChangePassword", keyValueInt);
                regkey.Close();

                Log.Write("DisableChangePassword", "ChangePassword has Disabled.");
            }
            catch (Exception ex)
            {
                Log.Write("DisableChangePassword", ex.ToString());
            }
        }

        public static void EnableChangePassword()//enable task manager
        {
            try
            {
                string subKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";
                RegistryKey rk = Registry.CurrentUser;
                RegistryKey sk1 = rk.OpenSubKey(subKey);
                if (sk1 != null)
                    rk.DeleteSubKeyTree(subKey);

                Log.Write("DisableChangePassword", "ChangePassword has Enabled.");
            }
            catch (Exception ex)
            {
                Log.Write("DisableChangePassword", ex.ToString());
            }
        }
    }
}
