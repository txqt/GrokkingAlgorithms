using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrokkingAlgorithms.Algorithm
{
    public class QuickSort
    {
        public static int[] Sort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(arr, left, right);
                Console.WriteLine($"Pivot Index: {pivotIndex}, Pivot Value: {arr[pivotIndex]}");
                Console.WriteLine("Array state: " + string.Join(", ", arr));
                Sort(arr, left, pivotIndex - 1);
                Sort(arr, pivotIndex + 1, right);
            }

            return arr;
        }
        static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, right);
            return i + 1;
        }

        static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
