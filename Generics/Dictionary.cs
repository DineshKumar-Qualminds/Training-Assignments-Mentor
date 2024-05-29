using System;
using System.Collections.Generic;

namespace Dictionary1
{
    internal class Dictionary
    {
        static void Main(string[] args)
        {
            Dictionary <int,string > dict = new Dictionary<int,string> ();   

            while (true) 
            {
                Console.WriteLine("What would like to do? (add/remove/print/exit");
                string choice = Console.ReadLine ();



                if (choice == "add")
                {

                    int key = ReadValidInt("Enter Key : ");
                    Console.Write("Enter Value: ");
                    string value  = Console.ReadLine ();   
                    
                    AddItems.AddItem(dict,key, value);


                }
                else if (choice == "remove")
                {
                    int key = ReadValidInt("Enter key to remove : ");
                    RemoveItems.RemoveItem(dict, key);
                }
                else if (choice == "print")
                {
                    PrintItems.PrintItem(dict);
                }
                else if(choice =="exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Choice.Please try again.");
                }
            }



        }

        public static int ReadValidInt(string prompt)
        {
            int key;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine(); 
                if(int.TryParse(input,out key))
                {
                    return key;
                }
                else
                {
                    Console.WriteLine("Invalid input.Please Enter a valid integer.");
                }

            }
        }
    }
}
