using System;

namespace BasicPrograms
{
    class PrintYourName
    {
        static void Main(string[] args)
        {
            string name;
            Console.WriteLine("Enter Your Name");
            name = Console.ReadLine();

            for (int i = 0; i < name.Length; i++)
            {
                Console.WriteLine(name[i]);
            }

        }
    }
}
