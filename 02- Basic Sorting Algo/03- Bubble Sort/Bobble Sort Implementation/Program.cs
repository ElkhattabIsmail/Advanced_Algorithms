using System;

class BubbleSortExample
{
    static void Main(string[] args)
    {
        int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
        int[] Sortedarr = { 1, 2, 3, 4, 5};
        Console.WriteLine("Original array:");
        foreach (int i in arr)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();

        BubbleSort(arr);
        BubbleSort(Sortedarr);
        Console.WriteLine("\nSorted array:");
        foreach (int i in arr)
        {
            Console.Write(i + " ");
        }

        Console.WriteLine("\nSorted An Already Sorted array:");
        foreach (int i in Sortedarr)
        {
            Console.Write(i + " ");
        }
        Console.ReadKey();
    }

    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        int SwapTimes = 0;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < (n - i - 1); j++)
                if (arr[j] > arr[j + 1])
                {
                    // Swap temp and arr[i] ( Tuple Swap)
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    SwapTimes++;
                }
            if (SwapTimes == 0)
                break;
            SwapTimes = 0;
        }
            
    }

}
