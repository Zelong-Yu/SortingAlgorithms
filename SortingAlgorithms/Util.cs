using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public static class Util
    {
        public static void QuickSort<T> (T[] input) where T : IComparable
        {
            helper(input, 0, input.Length - 1);

            void helper(T[] arr, int left, int right)
            {
                if (left < right)
                {
                    int p = partition(arr, left, right);
                    helper(arr, left, p - 1);
                    helper(arr, p + 1, right);
                }
            }

            int partition(T[] arr, int left, int right)
            {
                //randomly choose a pivot
                int pivotIndex = new Random().Next(left, right);
                T pivotValue = arr[pivotIndex];
                //put pivot index to the far right
                Swap(ref arr[pivotIndex], ref arr[right]);

                int originalRight = right;

                while(left<right)
                {
                    if (arr[left].CompareTo(pivotValue) > 0)
                    {
                        Swap(ref arr[left], ref arr[right--]);
                    }
                    else left++;
                }

                //put pivotvalue to correct location
                Swap(ref arr[left],ref arr[originalRight]);

                return pivotIndex;
            }
        }

        public static void Swap<T>(ref T A, ref T B)
        {
            T temp = A;
            A = B;
            B = temp;
        }

    }
}
