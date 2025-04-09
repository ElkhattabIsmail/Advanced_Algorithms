using System;

class BinarySearchExample
{
    // Method to perform binary search
    static int BinarySearch(int[] arr, int x)
    {
        int Start = 0, End = arr.Length - 1;

        while (Start <= End)
        {
            int Middle = (Start + End) / 2;

            // Check if Target is present at mid
            if (arr[Middle] == x)
                return Middle;

            // If Target greater, ignore left half
            if (x > arr[Middle] )
                Start = Middle + 1;
            // If Target is smaller, ignore right half
            else
                End = Middle - 1;
        }


        // If we reach here, then element was not present
        return -1;
    }
    //    Step-by-Step Explanation
    //Initial Variables: Set two pointers, Start(start of the array) and End(end of the array).
    //Find the Middle: Calculate the middle Middle of the current search space.
    //    Element Found: If the element at Middle matches the target Target, return the index Middle.
    //Adjust Search Space: If the target Target is greater than the element at Middle, move the left pointer Start to Middle + 1. Otherwise, adjust the right pointer End to Middle - 1.
    //Repeat or Conclude: Continue the process until the element is found or the pointers Start and End meet.If the element is not found, return -1.
    //Expected Results
    //Before the Search: The sorted array is displayed.
    //    After the Search: The program outputs the index of the found element.If the element is not found, it indicates so.


    static void Main(string[] args)
    {
       
        int[] arr = { 22, 25, 37, 41, 45,46, 49, 51,55,58,70,80,82,90,95 }; // Sorted array

        int Target = 25; // Element to be searched


        Console.WriteLine("Sorted Array:");
        foreach (var item in arr)
            Console.Write(item + " ");
        Console.WriteLine();


        int result = BinarySearch(arr, Target);


        if (result == -1)
            Console.WriteLine("Element not found in the array.");
        else
            Console.WriteLine("Element found at index: " + result);

        Console.ReadKey();
    }
}
