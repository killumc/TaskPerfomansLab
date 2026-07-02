using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPerfomansLab
{
    public class Task4
    {
        public static void SolutionTask4()
        {
            string line;
            List<int> nums = new List<int>();
            try
            {
                Console.WriteLine("Enter file path:");
                string filePath = Console.ReadLine();
                //string filePath= "C:\\Users\\Пользователь\\source\\repos\\TaskPerfomansLab\\Task4\\nums.txt";
                StreamReader sr = new StreamReader(filePath);
                do
                {
                    line = sr.ReadLine();
                    if (string.IsNullOrWhiteSpace(line))
                        continue;
                    if (line != null)
                    {
                        int num = int.Parse(line);
                        nums.Add(num);
                    }
                } while (line != null);

                nums.Sort();
                int indexMedian = nums.Count() / 2;
                int median = nums[indexMedian];
                
                int min = GetSumDeviation(median,nums);
                if (min > 20) Console.WriteLine("20 ходов недостаточно для приведения всех элементов массива к одному числу");
                else Console.WriteLine(min);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        private static int GetSumDeviation(int median, List<int> nums)
        {
            int sumDeviation = 0;
            foreach (int num in nums)
            {
                sumDeviation += Math.Abs(num - median);
            }
            return sumDeviation;
        }
    }
}
