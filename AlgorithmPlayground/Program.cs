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
            int[] arr = new int[] { 3, 6, 9, 2, 3, 1, 0, -1, 10 };
            Util.QuickSort(arr);
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
