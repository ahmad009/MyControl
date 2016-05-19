using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyControl_Client
{
    public static class SwitchUser
    {
        public static void DisableSwitchUser()//disable SwitchUser
        {
            RegistryKey regkey;
            string subKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";

            try
            {
                regkey = Registry.LocalMachine.CreateSubKey(subKey);
                regkey.SetValue("HideFastUserSwitching", 0x00000001);
                regkey.Close();

                Log.Write("DisableSwitchUser", "SwitchUser has Disabled.");
            }
            catch (Exception ex)
            {
                Log.Write("DisableSwitchUser", ex.ToString());
            }
        }

        public static void EnableSwitchUser()//enable SwitchUser
        {
            RegistryKey regkey;
            string subKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";

            try
            {
                regkey = Registry.LocalMachine.CreateSubKey(subKey);
                regkey.SetValue("HideFastUserSwitching", "-");
                regkey.Close();

                Log.Write("DisableSwitchUser", "SwitchUser has Enabled.");
            }
            catch (Exception ex)
            {
                Log.Write("DisableSwitchUser", ex.ToString());
            }
        }
    }
}
