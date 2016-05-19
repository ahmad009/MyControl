using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MyControl_Client
{
    public static class Log
    {
        private static string LogFile;

        public static void Initialize(string file)
        {
            LogFile = file;
            Imports.AllocConsole();
        }

        public static void Write(string func, string message)
        {
            string LogStr = "[" + func + "] : " + message;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(LogStr);

            try
            {
                File.AppendAllText(LogFile, LogStr + "\n");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ex.Message);
            }
        }
    }
}
