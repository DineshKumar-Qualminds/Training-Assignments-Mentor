using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionalHandling
{
    class OutofMemoryExceptionClass
    {
        static void Main()
        {
            try
            {
               
                byte[] bigArray = new byte[int.MaxValue];
            }
            catch (OutOfMemoryException ex)
            {
               
                Console.WriteLine("Out of memory exception: " + ex.Message);
                
            }

        }

    }
}
