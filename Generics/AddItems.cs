using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary1
{
    public static class AddItems
    {
        public static void AddItem(Dictionary<int, string> dict, int key, string value)
        {
            try
            {
                dict.Add(key, value);
            }
            catch (ArgumentException) 
            {
                Console.WriteLine("Kay already exits.Please enter a different key");
                int newKey = Dictionary.ReadValidInt("Enter Key : ");
                AddItem(dict, newKey, value);
            }
        }
    }
}
