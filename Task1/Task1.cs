using System;
using System.Runtime.CompilerServices;

public class Task1
{
    public async static Task SolutionTask1()
    {
        Console.WriteLine("Enter n for array1");
        int n1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter m for array1");
        int m1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter n for array2");
        int n2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter m for array2");
        int m2 = Convert.ToInt32(Console.ReadLine());
        if (n1 <= 0 || m1 <= 0 || n2 <= 0 || m2 <= 0)
        {
            Console.WriteLine("The numbers must be greater than zero");
        }
        else
        {
            Task<string> array1 = ProcessArrayAsync(n1, m1);
            Task<string> array2 = ProcessArrayAsync(n2, m2);

            string[] result = await Task.WhenAll(array1, array2);
            Console.WriteLine($"{result[0]}{result[1]}");
        }
    }


    static async Task<string> ProcessArrayAsync(int n, int m)
    {
        // Имитация длительной работы
        await Task.Delay(100); 
        return Find(n,m);
    }

    private static string Find(int n, int m)
    {
        int index = 0;
        List<int> circularArray = new List<int>();
        List<int> result = new List<int>();
        result.Add(1);

        for (int i = 1; i <= n; i++)
        {
            circularArray.Add(i);
        }
        do
        {
            if (index + m - 1 < circularArray.Count()) index += m - 1;
            else index = index + m - 1 - circularArray.Count();
            result.Add(circularArray[index]);
        }
        while (circularArray[index] != 1);
        result.RemoveAt(result.Count() - 1);
        string resultStr = string.Join("", result);
        return resultStr;
    }
}