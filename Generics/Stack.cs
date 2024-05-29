using System;
using System.Collections;
using System.Collections.Generic;


namespace StackGeneric
{
   

    class Stack
    {
        static void Main()
        {
            System.Collections.Stack stack = new System.Collections.Stack();

            while (true)
            {
                Console.WriteLine("Choose an operation:");
                Console.WriteLine("1. Push");
                Console.WriteLine("2. Pop");
                Console.WriteLine("3. Peek");
                Console.WriteLine("4. Remove Specific value from Stack");
                Console.WriteLine("5. Print");
                Console.WriteLine("6. Clear");
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
                        Console.Write("Enter value to push: ");
                        string valueToPush = Console.ReadLine();
                        stack.Push(valueToPush);
                        break;
                    case 2:
                        if (stack.Count > 0)
                        {
                            object poppedValue = stack.Pop();
                            Console.WriteLine($"Popped value: {poppedValue}");
                        }
                        else
                        {
                            Console.WriteLine("Stack is empty.");
                        }
                        break;
                    case 3:
                        if (stack.Count > 0)
                        {
                            object peekedValue = stack.Peek();
                            Console.WriteLine($"Top value: {peekedValue}");
                        }
                        else
                        {
                            Console.WriteLine("Stack is empty.");
                        }
                        break;
                    case 4:
                        Console.Write("Enter value to remove: ");
                        string valueToRemove = Console.ReadLine();
                        RemoveSpecificValue(stack, valueToRemove);
                        break;
                    case 5:
                        Console.WriteLine("Stack:");
                        if (stack.Count > 0) 
                        {
                            foreach (object obj in stack)
                            {
                                Console.WriteLine(obj);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Stack is empty");
                        }
                      
                        break;
                    case 6:
                        stack.Clear();

                        Console.WriteLine("Stack cleared.");
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void RemoveSpecificValue(System.Collections.Stack stack,string valueToRemove)
        {
            System.Collections.Stack tempStack = new System.Collections.Stack();
            bool found = false;
           

            while (stack.Count > 0)
            {
                object currentValue = stack.Pop();
                if (currentValue.ToString() != valueToRemove)
                {
                    tempStack.Push(currentValue);
                }
                else
                {
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Value not available in the list. Please try again.");
            }

            while (tempStack.Count > 0)
            {
                stack.Push(tempStack.Pop());
            }
        }


    }

}
