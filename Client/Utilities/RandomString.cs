using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyControl_Client.Utilities
{
    public class RandomString
    {
        public static string Generate(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
