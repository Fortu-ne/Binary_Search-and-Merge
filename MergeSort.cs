// Tuesday Dec-07-2022 code
// Binary search (using recuersion) and Merge and sort


// Merge and Sort 

using System.Diagnostics;



public class MergeSort{

    public static void Main(String[] args) {

        Stopwatch start = new Stopwatch();
        start.Start();

        Console.WriteLine("Please press M or B");
        Console.WriteLine("M - to run the Merge Sort ");
        Console.WriteLine("B - to run the Binary Search ");
        var key = Console.ReadKey().Key;
        Console.WriteLine("\n\n");

        if(key == ConsoleKey.M)
        {
            int[] list = { 9, 1, 3, 5, 6, 7, 4, 2, 8, 0, 10, 17, 12, 14, 11, 15, 13, 18, 19, 16, 21, 20, 23, 24, 29, 25, 26, 22, 27, 28 };
            foreach (var item in list)
            {
                Console.Write(item + ",");
            }
            Console.WriteLine("\n\n");

            merge_sort(list);

            foreach (var item in list)
            {
                Console.Write(item + ",");
            }
        }
        else if(key == ConsoleKey.B)
        {
            int[] list = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            foreach (var item in list)
            {
                Console.Write(item +",");
            }
            Console.WriteLine("\n\n");
            Console.Write("Please enter your desired value :");
            int target = int.Parse(Console.ReadLine());
            Console.WriteLine("\n\n");

            verify(list, target);
        }

        start.Stop();
        Console.WriteLine($"The program ran for {start.ElapsedMilliseconds}ms ");

    }

   public static void merge_sort(int[] array)
    {
        int length = array.Length;

        if (length <= 1)
            return;

        int mid = length / 2;
        int[] leftArray = new int[mid];
        int[] rightArray = new int[length - mid];

        // indices for the two new arrays
        int i = 0;
        int n = 0; // leftArray index
        int j = 0; // rightArray index

        for (; i < length; i++)
        {
            if (i < mid)
            {
                leftArray[n] = array[i];
                n++;
            }
            else
            {
                rightArray[j] = array[i];
                j++;
            }
        }

        merge_sort(leftArray);
        merge_sort(rightArray);
        merge(leftArray, rightArray, array);
    }

   public static void merge(int[] leftArray, int[] rightArray, int[] array)
    {

        int leftSize = array.Length / 2;
        int rightSize = array.Length - leftSize;
        // indices for all of the arrays
        int i = 0; // original Array index
        int n = 0; // leftArray index
        int j = 0; // rightArray index


        while (n < leftSize && j < rightSize)
        {
            if (leftArray[n] < rightArray[j])
            {
                array[i] = leftArray[n];
                n++;
                i++;
            }
            else
            {
                array[i] = rightArray[j];
                j++;
                i++;
            }
        }

        while (n < leftSize)
        {
            array[i] = leftArray[n];
            n++;
            i++;
        }

        while (j < rightSize)
        {
            array[i] = rightArray[j];
            j++;
            i++;
        }

    }


    private static void verify(int[] list, int target)
    {
        if (binary_search(list, target))
        {
            Console.WriteLine($"The value {target} was found");
        }
        else
        {
            Console.WriteLine($"The value {target} was not found in the list");
        }
    }

    private static bool binary_search(int[] array, int target)
    {
        int length = array.Length;
        int mid = 0;

        if (length == 0)
            return false; 
        else
        {
            mid = length / 2;
        }

        if (array[mid] == target)
            return true; // base case;
        else if (array[mid] < target)
        {
            mid++;
            
            return binary_search(array[mid..length], target);
        }
        else
        {
            return binary_search(array[..mid], target);
        }
    }

}





