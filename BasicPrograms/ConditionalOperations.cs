using System;

namespace BasicPrograms
{
    class ConditionalOperations
    {
        static void Main(string[] args)
        {
            // Using if and else operations
            Console.WriteLine("If,else if and else operation example");
            int x;
            Console.Write("Enter x value: ");
            x = Convert.ToInt32(Console.ReadLine());

            int y;
            Console.Write("Enter y value: ");
            y = Convert.ToInt32(Console.ReadLine());
            if (x < y)
            {
                Console.WriteLine($"{x} is less than {y}");

            }
            else if (x == y)
            {
                Console.Write($"{x} is equal to {y}");
            }
            else
            {
                Console.WriteLine($"{x} is greater than {y}");

            }
            Console.WriteLine("\n");


            //using switch
            Console.WriteLine("Switch operation example");
            string fruit = "apple";


            switch (fruit)
            {
                case "banana":
                    Console.WriteLine($"My favorite fruit is {fruit}");
                    break;
                case "mango":
                    Console.WriteLine($"My favorite fruit is {fruit}");
                    break;
                case "apple":
                    Console.WriteLine($"My favorite fruit is {fruit}");
                    break;
                case "orange":
                    Console.WriteLine($"My favorite fruit is {fruit}");
                    break;
                default:
                    Console.WriteLine("I don't like fruits");
                    break;
            }
            Console.WriteLine("\n");


            //ternary operator 
            Console.WriteLine("Ternary operator example ");

            int z;
            do
            {
                Console.Write("Enter z value: ");
                if (!int.TryParse(Console.ReadLine(), out z))
                {
                    Console.WriteLine("Invalid Input, Please enter a valid number");

                }

            } while (z == 0);
            Console.WriteLine("z value is compare with value 10, if equal true,otherwise false");
            string value = z == 10 ? "True" : "False";
            Console.WriteLine(value);


        }
    }
}
