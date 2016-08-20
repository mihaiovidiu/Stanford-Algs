using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        static int nbOfComparissons = 0;

        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            // Read numbers from file
            using (StreamReader sr = new StreamReader("QuickSort.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    numbers.Add(int.Parse(line));
                }
            }

            int[] unsortedArray = numbers.ToArray();
            QuickSort(unsortedArray, 0, unsortedArray.Length - 1);
            Console.WriteLine("Nb of caparissons was: " + nbOfComparissons);
            Console.ReadLine();

        }


        static void QuickSort(int[] array, int left, int right)
        {
            if (right <= left)
                return;
            else
            {
                // Chose a pivot
                int pivotIndex = Utils.ReturnPivotIndex(array, left, right);
                pivotIndex = Partition(array, left, right, pivotIndex);
                nbOfComparissons += right - left;
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

        

        static void swap(int[] array, int a, int b)
        {
            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
    }
}
