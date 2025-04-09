using System;
class InsertionSortAlgo
{
    static void InsertionSort(int[] arr)
    {
        int Key = -1;
        int RightIndex;
        for (int i = 1; i < arr.Length - 1; i++)
        {
            Key = arr[i];

            if (Key < arr[i - 1])
            {
                for (int j = 0; j < i; j++)
                {
                    RightIndex = i - j; // Update Index each iteration.
                    Key = arr[i - j]; // update key

                    arr[RightIndex] = arr[RightIndex - 1]; // Swap Values
                    arr[(RightIndex) - 1] = Key;

                    // Check if we found the first element in the array, or if the previous value is greater than the
                    // previous One. If the condition is true, the loop simply exits.
                    // Cuz it iterates uselessly.
                    if ((RightIndex) == 1 || arr[(RightIndex) - 1] > arr[(RightIndex) - 2])
                        break;
                }
            }
        }
      
    }
    static void Main(string[] args)
    {
        int[] arr = { 64, 25, 34, 12, 22, 11, 90 };


        Console.WriteLine("Original array:");
        foreach (int value in arr)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine();

        InsertionSort2(arr);

        Console.WriteLine("\nSorted array ASC:");
        foreach (int value in arr)
        {
            Console.Write(value + " ");
        }

       
        Console.ReadKey();

    }
    //{ 64, 25, 34, 12, 22, 11, 90 }
    static void InsertionSort2(int[] Arr)
    {
        int n = Arr.Length;
        for (int i = 1; i < n; ++i)
        {
            int key = Arr[i];
            int RightIndex = i - 1;

            // Move elements of Arr[0..i-1], that are greater than key,
            // to one position ahead of their current position
            while (RightIndex >= 0 && Arr[RightIndex] > key)
            {
                Arr[RightIndex + 1] = Arr[RightIndex];
                RightIndex--;
            }
            Arr[RightIndex + 1] = key;
        }
    }
}