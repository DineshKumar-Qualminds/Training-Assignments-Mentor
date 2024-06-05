using System.Reflection;
using System.Transactions;

namespace BasicPrograms
{
    class WeatherTemperature
    {
        private enum Options
        {
            FindWeatherTemperature,
            Exit
        }

        private static Options ReadUseroptions()
        {
            int selection;
            do
            {
                Console.WriteLine("Select option");
                Console.WriteLine("1. FindWeatherTemperature");
                Console.WriteLine("2. Exit");
                Console.WriteLine();
                Console.Write("Enter Your Choice : ");

                if (!int.TryParse(Console.ReadLine(), out selection))
                {
                    Console.WriteLine("Invalid choice.Please Enter a number");
                    continue;
                }
                if (selection >= 1 && selection <= 2)
                {
                    if (selection == 1)
                    {
                        return Options.FindWeatherTemperature;

                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice.Please Enter a valid number");


                }

            } while (selection != 2);
            return Options.Exit;

        }


        private static void Main()
        {
            Options option;
            do
            {
                option = ReadUseroptions();
                switch (option)
                {
                    case Options.FindWeatherTemperature:
                        TemparatureDetails();
                        break;
                    case Options.Exit:
                        Console.WriteLine("Existing Program");
                        break;
                }
            } while (option != Options.Exit);

        }

        private static void TemparatureDetails()
        {

            decimal temperature;
            do
            {
                Console.Write("Enter weather temperature: ");
                if (!decimal.TryParse(Console.ReadLine(), out temperature))
                {
                    Console.WriteLine("Invalid Input,Please Enter Valid Input");
                }
            } while (temperature == 0);

            if (temperature >= 45 && temperature <= 55)
            {
                Console.WriteLine($"Weather is Very Hot, The Present Temperature is {temperature}\u00B0C");
            }
            else if (temperature >= 35 && temperature <= 44)

            {
                Console.WriteLine($"Weather is Hot,The Present Temperature is {temperature}°C");
            }
            else if (temperature >= 24 && temperature <= 34)
            {
                Console.WriteLine($"Weather is Warm,The Present Temperature is {temperature}°C");
            }
            else
            {
                Console.WriteLine("Temperature is not within the specified ranges.");
            }

            Console.WriteLine();


        }


    }
}
