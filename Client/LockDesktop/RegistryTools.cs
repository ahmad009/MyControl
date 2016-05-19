using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyControl_Client
{
    public static class RegistryTools
    {
        public static void DisableRegistryTools()//disable task manager
        {
            RegistryKey regkey;
            string keyValueInt = "1";
            string subKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";

            try
            {
                regkey = Registry.CurrentUser.CreateSubKey(subKey);
                regkey.SetValue("DisableRegistryTools", keyValueInt);
                regkey.Close();

                Log.Write("DisableRegistryTools", "ChangePassword has Disabled.");
            }
            catch (Exception ex)
            {
                Log.Write("DisableRegistryTools", ex.ToString());
            }
        }

        public static void EnableRegistryTools()//enable task manager
        {
            try
            {
                string subKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";
                RegistryKey rk = Registry.CurrentUser;
                RegistryKey sk1 = rk.OpenSubKey(subKey);
                if (sk1 != null)
                    rk.DeleteSubKeyTree(subKey);

                Log.Write("DisableRegistryTools", "RegistryTools has Enabled.");
            }
            catch (Exception ex)
            {
                Log.Write("DisableRegistryTools", ex.ToString());
            }
        }
    }
}