using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp75
{
    internal static class Helper
    {
        public static bool isExisting(string filepath)
        {
            return File.Exists(filepath);
        }
    }
}
