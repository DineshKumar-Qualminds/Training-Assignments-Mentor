using System;
using System.Text;
using System.Collections.Generic;

namespace LinkedListGeneric
{
    public class LinkedList
    {
        static void Main(string[] args)
        {
            LinkedList<string> namesList = new LinkedList<string>();

            while (true)
            {
                Console.WriteLine("Choose an operation:");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Remove");
                Console.WriteLine("3. Print");
                Console.WriteLine("4. Remove Frist Element and LastElement");
                Console.WriteLine("5. Clear List");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice: ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    continue;
                }

                switch(choice) 
                {
                    case 1:
                        Console.Write("Enter add name : ");
                        string nameToAdd = Console.ReadLine(); 
                        namesList.AddLast(nameToAdd);   
                        break;
                    case 2:
                        if (namesList.Count == 0)
                        {
                            Console.WriteLine("List is empty.");
                            break;
                        }
                        while (true)
                        {
                            Console.Write("Enter name to remove: ");
                            string removeName = Console.ReadLine();
                            if (!namesList.Contains(removeName))
                            {
                                Console.WriteLine("Invalid name. Please try again.");
                            }
                            else
                            {
                                namesList.Remove(removeName);
                                Console.WriteLine($"{removeName} removed.");
                                break; 
                            }
                        }
                        break;


                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Display list : ");
                        if (namesList.Count > 0) {
                            foreach (string name in namesList)
                            {
                                Console.WriteLine(name);
                            }
                        }
                        else
                        {
                            Console.WriteLine("NameList is Empty");
                        }
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.Write("Remove First Element and last Element : ");
                        if(namesList.Count > 0) {
                            namesList.RemoveFirst();
                            Console.WriteLine("first name is removed");
                        }
                        else
                        {
                            Console.WriteLine("list is empty");
                        }
                        if (namesList.Count > 0)
                        {
                            namesList.RemoveLast();
                            Console.WriteLine("last name is removed");
                        }
                        else
                        {
                            Console.WriteLine("list is empty");
                        }
                      
                        break;
                    case 5:
                        Console.WriteLine("Clear List");
                        if (namesList.Count == 0)
                        {
                            Console.WriteLine("List is Empty");
                        }
                        namesList.Clear();  
                        break;
                    case 6:
                        Console.Write("Exit");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice,Plese try again");
                        break;
                        
                        
                }


            }
        }
    }
}