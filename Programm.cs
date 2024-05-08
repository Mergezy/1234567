using System;

class BubbleSort
{
    public static void Sort<T>(T[] array, Func<T, T, bool> sort)
    {
        int n = array.Length;
        for(int i = 0; i < n -1; i++)
        {
            for(int j = 0; j < n -1 -i; j++)
            {
                if (!sort(array[j], array[j+1]))
                {
                    T temp = array[j];
                    array[j] = array[j+1];
                    array[j+1] = temp;
                }
            }
        }
    }
}
public class HeapSort
{
    public static void Sort<T>(T[] arr, Func<T, T, bool> sort)
    {
        int n = arr.Length;

        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(arr, n, i, sort);

        for (int i = n - 1; i >= 0; i--)
        {
            T temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            Heapify(arr, i, 0, sort);
        }
    }

    private static void Heapify<T>(T[] arr, int n, int i, Func<T, T, bool> sort)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && sort(arr[left], arr[largest]))
            largest = left;

        if (right < n && sort(arr[right], arr[largest]))
            largest = right;

        if (largest != i)
        {
            T swap = arr[i];
            arr[i] = arr[largest];
            arr[largest] = swap;

            Heapify(arr, n, largest, sort);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 1, 2, 3, 14, 15, 16, 17, 18, 19, 20, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
        foreach(int i in array)
        {
            Console.Write($"{i}, ");
        }

        Console.WriteLine();

        HeapSort.Sort(array, (a, b) => a.CompareTo(b) > 0);

        foreach (int i in array)
        {
            Console.Write($"{i}, ");
        }

        Console.WriteLine();

        HeapSort.Sort(array, (a, b) => a.CompareTo(b) < 0);

        foreach (int i in array)
        {
            Console.Write($"{i}, ");
        }
    }
}
