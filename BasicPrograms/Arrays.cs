using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPrograms
{
    class Arrays
    {
        /*  static void Main(string[] args)
          {

              int[] array = new int[] { 2, 6, 1, 4, 5, 3 };//Create an array 

              //Print original Array
              Console.Write("Given array : ");
              for (int i = 0; i < array.Length; i++)
              {
                  Console.Write(array[i] + " ");

              }
              Console.WriteLine("\n");

              //Push elements into array
              Array.Resize(ref array, array.Length + 1);
              array[array.Length - 1] = 8;
              Array.Resize(ref array, array.Length + 1);
              array[array.Length - 1] = 7;

              Console.Write("Push new elements into array: ");
              for (int i = 0; i < array.Length; i++)
              {
                  Console.Write(array[i] + " ");

              }

              Console.WriteLine();
              //Length of array
              Console.WriteLine();
              Console.Write("Length of array: ");
              Console.WriteLine(array.Length);

              Console.WriteLine();

              //Index of each element
              foreach (int i in array)
              {
                  *//*  Console.Write(i + " ");*//*
                  int index = Array.IndexOf(array, i);
                  Console.WriteLine("Index of Element " + i + " is " + index);

              }


              Console.WriteLine();
              //Sort Elements
              *//*   Console.Write("Sorted array : ");
                 Array.Sort(array, 0, array.Length);
                 for (int i = 0; i < array.Length; i++)
                 {
                     Console.Write(array[i] + " ");
                 }*//*
              for (int i = 0; i < array.Length; i++)
              {
                  for (int j = i + 1; j < array.Length; j++)
                  {
                      if (array[i] > array[j])
                      {
                          int temp = array[i];
                          array[i] = array[j];
                          array[j] = temp;
                      }
                  }
              }

              Console.Write("Sorted Array : ");
              for (int i = 0; i < array.Length; i++)
              {
                  Console.Write(array[i] + " ");
              }

              Console.WriteLine("\n");


              //Reverse Elements 
              Console.Write("Reverse array : ");
              *//*Array.Reverse(array, 0, array.Length);*/
        /* for (int i = 0; i < array.Length; i++)
         {
             Console.Write(array[i] + " ");
         }*//*

        for (int i = array.Length - 1; i >= 0; i--)
        {
            Console.Write(array[i] + " ");
        }


        Console.WriteLine("\n");
        //Replace the first element with last element and print that array
        Console.Write("Replace the first element with last element vice versa: ");
        int lastElement = array[array.Length - 1];
        int firstElement = array[0];
        array[0] = lastElement;
        array[array.Length - 1] = firstElement;


        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }

        Console.WriteLine();

    }*/
    }
}
