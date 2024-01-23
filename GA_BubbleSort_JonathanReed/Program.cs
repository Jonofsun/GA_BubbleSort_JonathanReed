using System;

namespace GA_BubbleSort_JonathanReed
{
    internal class Program
    {
        /* Jonathan Reed
         * 1/22/2024
         * 
         * 
         */
        static Random random = new Random();
        static void Main(string[] args)
        {

            int size = 17;
            int minValue = 1;
            int maxValue = 107; 

            int[] randomArray = GenerateRandomIntArray(size, minValue, maxValue);

            Console.WriteLine("Unsorted Array:\n");
            foreach (int i in randomArray) { Console.Write(i + " "); }
            BubbleSort(randomArray);
            Console.WriteLine("\nSorted Array:\n");
            foreach (int i in randomArray) { Console.Write(i + " "); }
        }
        static int[] GenerateRandomIntArray(int size, int minValue, int maxValue) // function to create an array of a given size filled with random integers within a specified range. This function ensures that the input parameters are valid and throws an exception if they aren't.
        {
            if (size <= 0 || minValue > maxValue)
            {
                throw new ArgumentException("Invalid arguments");
            }

            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = random.Next(minValue, maxValue + 1);
            }
            return arr;
        }

        public static void BubbleSort(int[] arr) /*function takes an array of integers as input and sorts the array in ascending order. The algorithm consists of two nested loops:
                                                   Outer Loop: Iterates over each element in the array. It controls the number of passes through the array. Each pass ensures that the largest element among the unsorted elements bubbles up to its correct position.
                                                   Inner Loop: Goes through the unsorted part of the array. It compares each pair of adjacent items and swaps them if they are in the wrong order.*/
        {
            int arrayLength = arr.Length;
            bool hasSwapped;

            for (int currentPass = 0; currentPass < arrayLength - 1; currentPass++)
            {
                hasSwapped = false;

                for (int currentIndex = 0; currentIndex < arrayLength - 1 - currentPass; currentIndex++)
                {
                    if (arr[currentIndex] > arr[currentIndex + 1])
                    {
                        int temp = arr[currentIndex];
                        arr[currentIndex] = arr[currentIndex + 1];
                        arr[currentIndex + 1] = temp;
                        hasSwapped = true; /*When two adjacent elements are in the wrong order, they are swapped. This is done by storing one of the elements in a temporary variable, replacing it with the other element, and then moving the element in the temporary variable to the other position. */
                    }
                }
                if (!hasSwapped)
                {
                    break; /*flag is used to check whether any elements were swapped during the current pass. If no elements are swapped, it means the array is already sorted, and the algorithm can terminate early, reducing the number of unnecessary passes.*/
                }
            }
        }
    }
}