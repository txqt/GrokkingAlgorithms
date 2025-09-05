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

                Console.WriteLine("Array state: " + string.Join(", ", array));
            }
            return array;
        }
    }
}
