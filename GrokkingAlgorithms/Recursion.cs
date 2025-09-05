using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrokkingAlgorithms
{
    public class Recursion
    {
        public static void Countdown(int n)
        {
            if (n <= 0) // Base case
            {
                Console.WriteLine("Countdown finished!");
            }
            else
            {
                Console.WriteLine(n);
                Countdown(n - 1); // Recursive case
            }
        }

        public int SumRecursive(int[] arr, int index = 0)
        {
            // Base case
            if (index == arr.Length) return 0;
            // Recursive case
            return arr[index] + SumRecursive(arr, index + 1);
        }

        public static int CountRecursive(int[] arr, int index = 0)
        {
            // Base case
            if (index == arr.Length) return 0;
            // Recursive case
            return 1 + CountRecursive(arr, index + 1);
        }

        public static int MaxRecursive(int[] arr, int index = 0)
        {
            // Base case
            if (index == arr.Length - 1) return arr[index];

            // Recursive case
            int subMax = MaxRecursive(arr, index + 1);
            return arr[index] > subMax ? arr[index] : subMax;
        }
    }
}
