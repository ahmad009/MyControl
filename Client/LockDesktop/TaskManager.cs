using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyControl_Client
{
    public static class TaskManager
    {
        public static void DisableTaskMgr()//disable task manager
        {
            RegistryKey regkey;
            string keyValueInt = "1";
            string subKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";

            try
            {
                regkey = Registry.CurrentUser.CreateSubKey(subKey);
                regkey.SetValue("DisableTaskMgr", keyValueInt);
                regkey.Close();

                Log.Write("DisableTaskMgr", "TaskMgr has Disabled.");
            }
            catch (Exception ex)
            {
                Log.Write("DisableTaskMgr", ex.ToString());
            }
        }

        public static void EnableTaskMgr()//enable task manager
        {
            try
            {
                string subKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";
                RegistryKey rk = Registry.CurrentUser;
                RegistryKey sk1 = rk.OpenSubKey(subKey);
                if (sk1 != null)
                    rk.DeleteSubKeyTree(subKey);

                Log.Write("DisableTaskMgr", "TaskMgr has Enabled.");
            }
            catch (Exception ex)
            {
                Log.Write("DisableTaskMgr", ex.ToString());
            }
        }
    }
}
