using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort_CountInversions
{
    class Program
    {
        static void Main(string[] args)
        {

            string filePath = @"F:\Coursera\Standford - Algorithms 1\TEST.txt";
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    List<int> listOfNumbers = new List<int>();
                    string lineText;
                    while((lineText = sr.ReadLine()) != null)
                    {
                        int nb;
                        if (int.TryParse(lineText, out nb))
                        {
                            listOfNumbers.Add(nb);
                        }
                        else
                        {
                            Console.WriteLine("File format error!");
                            return;
                        }
                    }

                    int[] output = new int[listOfNumbers.Count];
                    long nbOfInversions = SortAndCountInversions(listOfNumbers.ToArray(), listOfNumbers.Count, output);
                    Console.WriteLine("Nb of inversions in file '" + Path.GetFileName(filePath) + "' is: " + nbOfInversions);
                }
            }
            else
                Console.WriteLine("Invalid path!");
            Console.ReadLine();
           
            
        }


        static long SortAndCountInversions(int[] input, int n, int[] output)
        {

            if (n == 1)
            {
                output[0] = input[0];
                return 0;
            }
            int[] firstHalf = new int[n / 2];
            int[] secondHalf = new int[n - n / 2];
            Array.Copy(input, 0, firstHalf, 0, n / 2);
            Array.Copy(input, n / 2, secondHalf, 0, n - n / 2);
            int[] mergedArray = new int[firstHalf.Length];
            int[] mergedArray2 = new int[secondHalf.Length];
            long inversions = 0;
            inversions = SortAndCountInversions(firstHalf, firstHalf.Length, mergedArray);
            inversions += SortAndCountInversions(secondHalf, secondHalf.Length, mergedArray2);
            inversions += MergeAndCountInversions(mergedArray, mergedArray.Length, mergedArray2, mergedArray2.Length, output);
            return inversions;
        }


        static long MergeAndCountInversions(int[] array1, int size1, int[] array2, int size2, int[] mergedArray)
        {
            int i = 0;
            int j = 0;
            long inversions = 0;
            for (int k = 0; k < size1 + size2; k++)
            {
                if (i == size1)
                {
                    Array.Copy(array2, j, mergedArray, k, size2 - j);
                    break;
                }

                if (j == size2)
                {
                    Array.Copy(array1, i, mergedArray, k, size1 - i);
                    break;
                }
                
                if (array1[i] < array2[j])
                {
                    mergedArray[k] = array1[i++];
                }
                else
                {
                    mergedArray[k] = array2[j++];
                    inversions += size1 - i;
                }
            }
            return inversions;
        }
    }
}
