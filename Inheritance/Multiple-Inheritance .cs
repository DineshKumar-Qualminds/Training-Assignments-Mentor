using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Multiple_Inheritance
    {
        interface IWalk
        {
            void Walk();
        }

        interface ISwim
        {
            void Swim();
        }

        class Dog : IWalk
        {
            public void Walk()
            {
                Console.WriteLine("Dog is walking.");
            }
        }

        class Fish : ISwim
        {
            public void Swim()
            {
                Console.WriteLine("Fish is swimming.");
            }
        }

        class Tortoise : IWalk, ISwim
        {
            public void Walk()
            {
                Console.WriteLine(" Tortoise is walking.");
            }

            public void Swim()
            {
                Console.WriteLine(" Tortoise is swimming.");
            }
        }

        class Program
        {
            static void Main()
            {
                Dog dog = new Dog();
                dog.Walk(); // Accessing method from IWalk

                Fish fish = new Fish();
                fish.Swim(); // Accessing method from ISwim

                Tortoise tortoise = new Tortoise();
                tortoise.Walk(); // Accessing method from IWalk
                tortoise.Swim(); // Accessing method from ISwim
            }
        }

    }
}
