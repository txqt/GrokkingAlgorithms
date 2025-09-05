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

    public static void Run()
    {
        int[] array = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
        Console.WriteLine("Array: " + string.Join(" ", array));

        Console.Write("Enter a number to search for: ");
        var input = Console.ReadLine();

        while (input != null && !int.TryParse(input, out _))
        {
            Console.Write("Invalid input. Enter a number: ");
            input = Console.ReadLine();
        }

        int target = int.Parse(input!);
        int result = BinarySearch.Search(array, target);

        Console.WriteLine(result != -1
            ? $"Number found at index {result}."
            : "Number not found in the array.");
    }
}
