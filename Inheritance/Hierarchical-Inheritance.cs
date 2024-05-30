using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Hierarchical_Inheritance
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

        class Cat : Animal
        {
            public void Meow()
            {
                Console.WriteLine("Cat is meowing.");
            }
        }

        class Program
        {
            static void Main()
            {
                Dog dog = new Dog();
                dog.Eat();  // Accessing base class method from Dog
                dog.Bark(); // Accessing derived class method from Dog

                Cat cat = new Cat();
                cat.Eat();  // Accessing base class method from Cat
                cat.Meow(); // Accessing derived class method from Cat
            }
        }
    }
}
