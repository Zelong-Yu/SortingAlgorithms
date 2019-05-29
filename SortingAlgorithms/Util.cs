using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public class Util
    {
        //O(nlogn) computational, O(n) space
        public static void QuickSort<T>(T[] input) where T : IComparable
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

                
                while (left < right)
                {
                    if (arr[left].CompareTo(pivotValue) > 0)
                    {
                        Swap(ref arr[left], ref arr[--right]);
                    }
                    else left++;
                }

                //put pivotvalue to correct location
                Swap(ref arr[right], ref arr[originalRight]);

                return right;
            }
        }

        public static void Swap<T>(ref T A, ref T B)
        {
            T temp = A;
            A = B;
            B = temp;
        }

        //regular (not in place) merge sort, O(nlogn) computational, O(n) space
        public static void MergeSort<T> (T[] input) where T: IComparable
        {
            helper(input, 0, input.Length - 1);

            void helper(T[] arr, int left, int right)
            {
                if (left < right)
                {
                    int mid = left + (right - left) / 2;//to prevent overflow

                    helper(arr, left, mid);
                    helper(arr, mid+1, right);

                    merge(arr, left, mid, right);
                }
            }
        }

        //normal(not in place) merge
        private static void merge<T>(T[] arr, int left, int mid, int right) where T : IComparable
        {
            //size of two subarrays
            int m = mid - left + 1;
            int n = right - mid;

            //initialize subarrays
            T[] subL = new T[m];
            T[] subR = new T[n];

            //copy data to sub arrays
            Array.Copy(arr, left, subL, 0, m);
            Array.Copy(arr, mid+1, subR, 0, n);

            //merge 2 subarrays back to original
            int i = 0, j = 0;
            int k = left;
            while (i < m && j < n)
            {
                if (subL[i].CompareTo(subR[j])<=0)
                {
                    arr[k] = subL[i++];
                }
                else
                {
                    arr[k] = subR[j++];
                }
                k++;
            }

            //put the remaining element of subarray back to original
            while (i < m)
            {
                arr[k++] = subL[i++];
            }

            while (j < n) 
            {
                arr[k++] = subR[j++];
            }

        }

        //in place merge sort, O(nlogn) computational
        public static void MergeSortInPlace<T>(T[] input) where T : IComparable
        {
            helper(input, 0, input.Length - 1);

            void helper(T[] arr, int left, int right)
            {
                if (left < right)
                {
                    int mid = left + (right - left) / 2;//to prevent overflow

                    helper(arr, left, mid);
                    helper(arr, mid + 1, right);

                    mergeInplace(arr, left, mid, right);
                }
            }
        }

        private static void mergeInplace<T>(T[] arr, int left, int mid, int right) where T : IComparable
        {
            //start point of first and second subarray
            int i = left;
            int j = mid + 1;

            //merge 2 subarrays back to original
            while (i <= mid && j <= right)
            {
                if (arr[i].CompareTo(arr[j]) <= 0)
                {
                    i++;
                }
                else
                {
                    T temp = arr[j];
                    //shift elements towards the right of j by 1
                    for (int index = j; index >i; index--)
                    {
                        arr[index] = arr[index - 1];
                    }
                    arr[i] = temp;

                    i++;
                    mid++;
                    j++;
                }                
            }
        }

        public static void InsertionSort<T>(T[] input) where T: IComparable
        {
            for (int i = 1; i < input.Length; i++)
            {
                //save the current input[i]
                T temp = input[i];
                int index = i - 1;
                //shift elements right for 1 until finding the place to insert
                while (index>=0 && input[index].CompareTo(temp)>0)
                {
                    input[index + 1] = input[index--];
                }
                //insert the current input[i] to index+1
                input[index + 1] = temp;
            }
        }

        //improved bubblesort (O(n^2)) will reduce #swap when array is (partially) sorted already
        public static void BubbleSort<T>(T[] input) where T: IComparable
        {
            //mark last swap location
            int lastSwapIndex = 0;
            //boarder of unsorted part of array. only need to compare until here
            int sortBorder = input.Length - 1;
            bool isSorted;
            do
            {
                isSorted = true;
                for (int j = 0; j < sortBorder; j++)
                {
                    if (input[j].CompareTo(input[j + 1]) > 0)
                    {
                        Swap(ref input[j], ref input[j + 1]);
                        isSorted = false;
                        lastSwapIndex = j;
                    }
                }
                sortBorder = lastSwapIndex;
                //if the array is sorted, no more loop needed.
                if (isSorted) break;
            } while (!isSorted);
        }

        //O(nlogn) computational, O(1) space
        public static void HeapSort<T>(T[] input) where T: IComparable
        {
            //make a binary max heap from input
            for (int i = input.Length/2-1; i >=0; i--)
            {
                bubbledown(input, i, input.Length);
            }

            //pop out top of heap(current maximal), move to end of heap, bubbledown to get new top of heap
            for (int i = input.Length-1; i > 0; i--)
            {
                Swap(ref input[0], ref input[i]);
                bubbledown(input, 0, i);
            }
        }

        private static void bubbledown<T>(T[] input, int parentIndex, int length) where T : IComparable
        {
            T temp = input[parentIndex];
            int childIndex = 2 * parentIndex + 1;
            while(childIndex<length)
            {
                //if there exists a right child, and right child larger than left child, move to right child
                if (childIndex+1<length&&input[childIndex+1].CompareTo(input[childIndex])>0)
                {
                    childIndex++;
                }
                //if parent is larger then one child, break
                if (temp.CompareTo(input[childIndex]) >= 0)
                    break;
                //bubbledown
                input[parentIndex] = input[childIndex];
                parentIndex = childIndex;
                childIndex = 2 * childIndex + 1;
            }
            //put temp to final position
            input[parentIndex] = temp;
        }

        public static void BucketSort(int[] input)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            foreach (var n in input)
            {
                if (n < min) min = n;
                if (n > max) max = n;
            }
            int[] buckets = new int[max - min + 1];
            foreach (var n in input)
            {
                buckets[n - min]++;
            }
            int counter = 0;
            for (int i = 0; i < buckets.Length; i++)
            {
                while(buckets[i]>0)
                {
                    input[counter++] = min + i;
                    buckets[i]--;
                }
            }
        }
    }
}
