using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary1
{
    public static class PrintItems
    {
        public static void PrintItem(Dictionary<int, string> dict)
        {
            foreach (var item in dict)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }
        }
    }
}
