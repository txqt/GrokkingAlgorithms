using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrokkingAlgorithms.Algorithm;
public class BinarySearch
{
    public static int Search(int[] array, int target) // Iterative version
    {
        int left = 0;
        int right = array.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (array[mid] == target)
            {
                return mid;
            }
            else if (array[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
            Console.WriteLine($"Left: {left}, Right: {right}, Mid: {mid}");
        }
        return -1;
    }

    public static int Search(int[] arr, int target, int left, int right) // Recursive version
    {
        if (left > right)
            return -1;

        int mid = (left + right) / 2;

        if (arr[mid] == target)
            return mid;
        else if (arr[mid] > target)
            return Search(arr, target, left, mid - 1);
        else
            return Search(arr, target, mid + 1, right);
    }
}
