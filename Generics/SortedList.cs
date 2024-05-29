using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;

namespace SortedGeneric
{
    public class SortedList
    {
        static void Main(string[] args)
        {
            System.Collections.SortedList sortedList = new System.Collections.SortedList();

            while (true)
            {
                Console.WriteLine("Choose an operation:");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Remove");
                Console.WriteLine("3. Print ");
                Console.WriteLine("4. Remove Frist Element");
                Console.WriteLine("5. RemoveAt Specific Position");
                Console.WriteLine("6. Clear List");
                Console.WriteLine("7. Exit");

                Console.Write("Enter your choice: ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter key to add : ");
                        int keyToAdd = int.Parse(Console.ReadLine());
                        Console.Write("Enter value to add : ");
                        string valueToAdd = Console.ReadLine(); 
                        sortedList.Add(keyToAdd, valueToAdd);
                        break;
                    
                   
                    case 2:
                        if (sortedList.Count == 0)
                        {
                            Console.WriteLine("List is empty.");
                            break;
                        }
                        while (true)
                        {
                            Console.Write("Enter key to remove: ");
                            int keyToRemove = int.Parse(Console.ReadLine());
                            if (!sortedList.Contains(keyToRemove))
                            {
                                Console.WriteLine("Invalid number. Please try again.");
                            }
                            else
                            {
                                sortedList.Remove(keyToRemove);
                                Console.WriteLine($"{keyToRemove} removed.");
                                break;
                            }
                        }
                        break;


                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Display Sorted list : ");
                        if (sortedList.Count > 0)
                        {
                          foreach(DictionaryEntry entry  in sortedList)
                            {
                                Console.WriteLine($"Key:{entry.Key},Value:{entry.Value}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("SortedList is Empty");
                        }
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.Write("Remove First Element : ");
                        if (sortedList.Count > 0)
                        {
                            sortedList.RemoveAt(0);
                            Console.WriteLine("first name is removed");
                        }
                        else
                        {
                            Console.WriteLine("List is empty");
                        }
                        break;
                    case 5:
                        Console.Write("Enter Index to remove : ");
                        int indexToRemove = int.Parse(Console.ReadLine());
                        if (indexToRemove >= 0 && indexToRemove <sortedList.Count)
                        {
                           sortedList.RemoveAt(indexToRemove);
                            Console.WriteLine($"Element at index{indexToRemove} removed");

                        }
                        else
                        {
                            Console.WriteLine("Invalid Index");
                        }

                        break;
                    case 6:
                        Console.WriteLine("Clear List");
                        if (sortedList.Count == 0)
                        {
                            Console.WriteLine("List is Empty");
                        }
                        sortedList.Clear();
                        break;
                    case 7:
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