using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortingAlgorithms;

namespace AlgorithmPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Quicksort");
            int[] arr = new int[] { 3, 6, 9, 2, 3, 1, 0, -1, 10,5,14 };
            Util.QuickSort(arr);
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine("\nMergesort");

            int[] arr2 = new int[] { 3, 6, 9, 2, 3, 1, 0, -1, 10,14,5 };
            Util.MergeSort(arr2);
            foreach (var item in arr2)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine("\nMergeSort Inplace");

            int[] arr3 = new int[] { 3, 6, 9, 2, 3, 1, 0, -1, 10, 14, 5 };
            Util.MergeSortInPlace(arr3);
            foreach (var item in arr3)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine("\nInsertion sort");

            int[] arr4 = new int[] { 3, 6, 9, 2, 3, 1, 0, -1, 10, 14, 5 };
            Util.InsertionSort(arr4);
            foreach (var item in arr4)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine("\nBubble Sort");
            int[] arr5 = new int[] { 3, 6, 9, 2, 3, 1, 0, -1, 10, 14, 5 };
            Util.BubbleSort(arr5);
            foreach (var item in arr5)
            {
                Console.Write($"{item} ");
            }

        }
    }
}
