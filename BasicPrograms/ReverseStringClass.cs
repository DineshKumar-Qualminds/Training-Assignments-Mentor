using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace BasicPrograms
{
    class ReverseStringClass
    {
        static void Main()
        {
            Console.WriteLine("Enter User Input");
            string userInput = Console.ReadLine();
            string revarseString = ReverseString(userInput);

            Console.WriteLine(revarseString);

            for (int i = 0; i < revarseString.Length; i++)
            {
                Console.WriteLine(revarseString[i]);
            }

        }

        private static string ReverseString(string userInput)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = userInput.Length - 1; i >= 0; i--)
            {
                sb.Append(userInput[i]);
            }
            return sb.ToString();
        }




    }
}
