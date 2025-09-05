using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrokkingAlgorithms.Algorithm
{
    public class SelectionSort
    {
        public static int[] Sort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                // Swap the found minimum element with the first element
                int temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;
            }
            return array;
        }

        public static void Run()
        {
            int[] array = { 64, 25, 12, 22, 11 };
            Console.WriteLine("Unsorted array: " + string.Join(" ", array));

            int[] sorted = SelectionSort.Sort(array);
            Console.WriteLine("Sorted array: " + string.Join(" ", sorted));
        }
    }
}
