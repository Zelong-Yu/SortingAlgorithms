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
            int[] arr = new int[] { 3, 6, 9, 2, 3, 1, 0, -1, 10,5,14 };
            Util.QuickSort(arr);
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();

            int[] arr2 = new int[] { 3, 6, 9, 2, 3, 1, 0, -1, 10,14,5 };
            Util.MergeSort(arr2);
            foreach (var item in arr2)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
