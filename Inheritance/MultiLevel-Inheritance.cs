using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class MultiLevel_Inheritance
    {
        class Animal
        {
            public void Eat()
            {
                Console.WriteLine("Animal is eating.");
            }
        }

        class Dog : Animal
        {
            public void Bark()
            {
                Console.WriteLine("Dog is barking.");
            }
        }

        class Labrador : Dog
        {
            public void Display()
            {
                Console.WriteLine("Labrador is a type of dog.");
            }
        }

        class Program
        {
            static void Main()
            {
                Labrador labrador = new Labrador();
                labrador.Eat();     // Accessing base class method
                labrador.Bark();    // Accessing intermediate class method
                labrador.Display(); // Accessing derived class method
            }
        }

    }
}
