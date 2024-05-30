using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionalHandling
{
    class IndexOutofRangeClass
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3 };

            try
            {
                int value = numbers[3]; 
                Console.WriteLine($"Value at index 3 is: {value}");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Caught an IndexOutOfRangeException: {ex.Message}");
            }

        }
    }
}