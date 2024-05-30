using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionalHandling
{
    class NullReferenceExceptionclass
    {
        static void Main()
        {
            try
            {
                string id = null;

                if (id is null)
                {
                    throw new ArgumentNullException("Id Argument cannot be null");
                }
                else
                {
                    int ans = int.Parse(id);
                }

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
