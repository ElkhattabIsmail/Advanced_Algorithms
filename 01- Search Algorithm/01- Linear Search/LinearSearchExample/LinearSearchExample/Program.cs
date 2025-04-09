using System;


class LinearSearchExample
{
    // Method to perform linear search
    static int LinearSearch(int[] arr, int x)
    {
        int n = arr.Length;
        for (int i = 0; i < n; i++)
        {
            // Return the index of the element if found
            if (arr[i] == x)
                return i;
        }
        // Return -1 if the element is not found
        return -1;
    }
    //to ignore warning, should Add "where T : IEquatable<T>"
    static int LinearSearch<T>(T[] arr, T x) where T : IEquatable<T>
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].Equals(x))
                return i;
        }
        // Return -1 if the element is not found
        return -1;
    }
    static void Main(string[] args)
    {
        int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
        int x = 22; // Element to be searched

        Console.WriteLine("Original Array:");
        foreach (var item in arr)
            Console.Write(item + " ");
        Console.WriteLine();

        int result = LinearSearch(arr, x);

        if (result == -1)
            Console.WriteLine("Element not found in the array.");
        else
            Console.WriteLine("Element found at index: " + result);

        Console.ReadKey();
    }
}