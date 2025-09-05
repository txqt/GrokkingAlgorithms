using GrokkingAlgorithms;

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Binary Search");
            Console.WriteLine("2. Selection Sort");
            Console.WriteLine("3. Recursion");
            Console.WriteLine("2. Exit");
            Console.Write("Choose an option: ");

            var choice = Console.ReadLine();

            CheckIsValidInput(choice);

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Binary Search Selected.");
                    RunBinarySearch();
                    break;
                case "2":
                    Console.WriteLine("Selection Sort Selected.");
                    RunSelectionSort();
                    break;
                case "3":
                    Console.WriteLine("Recursion Selected.");
                    RunRecursion();
                    break;
                case "0":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
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
        foreach (var num in array)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
        Console.Write("Enter a number to search for: ");
        var input = Console.ReadLine();
        CheckIsValidInput(input);
        int target = int.Parse(input!);
        int result = BinarySearch.Search(array, target);
        if (result != -1)
        {
            Console.WriteLine($"Number found at index {result}.");
        }
        else
        {
            Console.WriteLine("Number not found in the array.");
        }
    }

    private static void RunSelectionSort()
    {
        int[] array = { 64, 25, 12, 22, 11 };
        Console.WriteLine("Unsorted array:");
        foreach (var num in array)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
        int[] sortedArray = SelectionSort.Sort(array);
        Console.WriteLine("Sorted array:");
        foreach (var num in sortedArray)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }

    private static void RunRecursion()
    {
        int[] array = { 1, 2, 3, 4, 5 };
        Console.WriteLine("Array elements:");
        foreach (var num in array)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
        Recursion.Countdown(5);
        int sum = new Recursion().SumRecursive(array);
        int count = Recursion.CountRecursive(array);
        int max = Recursion.MaxRecursive(array);
        Console.WriteLine($"Sum of array elements: {sum}");
        Console.WriteLine($"Count of array elements: {count}");
        Console.WriteLine($"Max of array elements: {max}");
    }
}
