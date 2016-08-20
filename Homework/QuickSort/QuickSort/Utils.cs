using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    public class Utils
    {
        public static int ReturnPivotIndex(int[] array, int left, int right)
        {
            // Return the first element in the array
            //return left;
            // Return the last element in the array
            //return right;
            // Return the medion of three
            // Find the index of middle element
            int middleIndex = left + (right - left) / 2;
            int theMedian = median(array[left], array[right], array[middleIndex]);
            if (theMedian == array[left])
                return left;
            else if (theMedian == array[right])
                return right;
            else
                return middleIndex;
        }

        public static int min(int a, int b)
        {
            if (a < b)
                return a;
            else
                return b;
        }

        public static int max(int a, int b)
        {
            if (a < b)
                return b;
            else
                return a;
        }

        public static int median(int a, int b, int c)
        {
            return a + b + c - min(min(a, b), c) - max(max(a, b), c);
        }
    }
}
