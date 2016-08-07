using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 2, 4, 3, 1, 6, 7, 4, 12, 11, 0 };
            QuickSort(a, 0, a.Length - 1);

        }


        static void QuickSort(int[] array, int left, int right)
        {
            if (right <= left)
                return;
            else
            {
                // Chose a pivot
                int pivotIndex = ReturnPivotIndex(array, left, right);
                pivotIndex = Partition(array, left, right, pivotIndex);
                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);
            }

        }

        // input array [left........right]
        // [p....<p i >p..... j<unseen>]
        static int Partition(int[] array, int left, int right, int pivotIndex)
        {
            // if the pivot is not the first element, swap the first element with the pivot
            if (pivotIndex != left)
                swap(array, pivotIndex, left);
            int i = left + 1;
            for (int j = left + 1; j <= right; j++)
            {
                if (array[j] < array[left])
                {
                    swap(array, j, i);
                    i++;
                }
            }
            swap(array, left, i - 1);
            return i - 1; 
        }

        static int ReturnPivotIndex(int[] array, int left, int right)
        {
            // Return the first element in the array
            return left;
        }

        static void swap(int[] array, int a, int b)
        {
            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
    }
}
