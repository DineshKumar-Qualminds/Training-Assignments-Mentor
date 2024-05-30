using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary1
{
    public static class RemoveItems
    {
        public static void RemoveItem(Dictionary<int, string> dict, int key)
        {
            if (dict.ContainsKey(key))
            {
                dict.Remove(key);
                Console.WriteLine("Item removed successfully.");
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }
    }
}
