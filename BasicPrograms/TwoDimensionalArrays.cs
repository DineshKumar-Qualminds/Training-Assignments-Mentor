using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPrograms
{
    class TwoDimensionalArrays
    {

        static void Main(string[] args)
        {
            int[,] array = new int[,] { { 1, 2, 3, 4 }, { 3, 4, 5, 6 } };

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]}" + " ");
                }
                Console.WriteLine();
            }


        }


    }
}
