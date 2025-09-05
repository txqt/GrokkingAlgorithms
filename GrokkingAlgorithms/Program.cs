using GrokkingAlgorithms.Algorithm;
using GrokkingAlgorithms.ConsoleMenus;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Submenu for Binary Search
        var binarySearchMenu = new MenuBuilder()
            .Title("Binary Search")
            .Add("Run Binary Search", RunBinarySearch)
            .Add("Run Binary Search Recursive", RunBinarySearchRecursive)
            .AddExit("Back");

        // Submenu for Selection Sort
        var selectionSortMenu = new MenuBuilder()
            .Title("Selection Sort")
            .Add("Run Selection Sort", RunSelectionSort)
            .AddExit("Back");

        // Submenu for Recursion
        var recursionMenu = new MenuBuilder()
            .Title("Recursion")
            .Add("Countdown", () => Recursion.Countdown(5))
            .Add("Sum of array", () =>
            {
                int[] array = { 1, 2, 3, 4, 5 };
                Console.WriteLine($"Sum = {new Recursion().SumRecursive(array)}");
            })
            .Add("Count elements", () =>
            {
                int[] array = { 1, 2, 3, 4, 5 };
                Console.WriteLine($"Count = {Recursion.CountRecursive(array)}");
            })
            .Add("Max element", () =>
            {
                int[] array = { 1, 2, 3, 4, 5 };
                Console.WriteLine($"Max = {Recursion.MaxRecursive(array)}");
            })
            .AddExit("Back");

        // Main menu
        var mainMenu = new MenuBuilder()
            .Title("Main Menu")
            .AddSubMenu("Binary Search", binarySearchMenu)
            .AddSubMenu("Selection Sort", selectionSortMenu)
            .AddSubMenu("Recursion", recursionMenu)
            .AddExit("Exit");

        mainMenu.Show();
    }

    private static void CheckIsValidInput(string? input)
    {
        while (input != null && !int.TryParse(input, out _))
        {
            Console.Write("Invalid input. Please enter a number: ");
            input = Console.ReadLine();
        }
    }

    private static void RunBinarySearch()
    {
        int[] array = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
        Console.WriteLine("Array:");
        foreach (var num in array) Console.Write(num + " ");
        Console.WriteLine();

        Console.Write("Enter a number to search for: ");
        var input = Console.ReadLine();
        CheckIsValidInput(input);

        int target = int.Parse(input!);
        int result = BinarySearch.Search(array, target);

        if (result != -1)
            Console.WriteLine($"Number found at index {result}.");
        else
            Console.WriteLine("Number not found in the array.");
    }

    private static void RunBinarySearchRecursive()
    {
        int[] array = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
        Console.WriteLine("Array:");
        foreach (var num in array) Console.Write(num + " ");
        Console.WriteLine();

        Console.Write("Enter a number to search for: ");
        var input = Console.ReadLine();
        CheckIsValidInput(input);

        int target = int.Parse(input!);
        int result = BinarySearch.Search(array, target, 0, array.Length - 1);

        if (result != -1)
            Console.WriteLine($"Number found at index {result}.");
        else
            Console.WriteLine("Number not found in the array.");
    }

    private static void RunSelectionSort()
    {
        int[] array = { 64, 25, 12, 22, 11 };
        Console.WriteLine("Unsorted array:");
        foreach (var num in array) Console.Write(num + " ");
        Console.WriteLine();

        int[] sortedArray = SelectionSort.Sort(array);

        Console.WriteLine("Sorted array:");
        foreach (var num in sortedArray) Console.Write(num + " ");
        Console.WriteLine();
    }
}