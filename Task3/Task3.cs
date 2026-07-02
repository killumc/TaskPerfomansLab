using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.XPath;
using static System.Net.Mime.MediaTypeNames;
namespace TestPerfomansLab
{
    public class Task3
    {
        public static async Task SolutionTask3()
        {
            string filePathValues = EnterFilePath("Values");
            string filePathTests = EnterFilePath("Tests");
            string filePathReport = EnterFilePath("Report");
            //string filePathValues = "C:\\Users\\Пользователь\\source\\repos\\TaskPerfomansLab\\Task3\\values.json";
            //string filePathTests = "C:\\Users\\Пользователь\\source\\repos\\TaskPerfomansLab\\Task3\\tests.json";
            //string filePathReport = "C:\\Users\\Пользователь\\source\\repos\\TaskPerfomansLab\\Task3\\report.json";
            ValuesContainer? DataValues;
            TestsContainer? DataTests;
            TestsContainer? Report = new TestsContainer();
            using (FileStream fs = new FileStream(filePathValues, FileMode.OpenOrCreate))
            {
                ValuesContainer? result = await JsonSerializer.DeserializeAsync<ValuesContainer>(fs);
                DataValues = result;
            }
           
            using (FileStream fs = new FileStream(filePathTests, FileMode.OpenOrCreate))
            {
                TestsContainer? result = await JsonSerializer.DeserializeAsync<TestsContainer>(fs);
                DataTests = result;
            }

            if (DataValues != null)
            {
                foreach (var values in DataTests.tests)
                {
                    Test test = new Test(values);
                    test.Value = SetValue(DataValues, test);
                    if (test.Values != null)
                    {
                        test.Values = Search(test.Values, DataValues);
                    }
                    if (test!= null) Report.tests.Add(test);

                }
            }

            var options = new JsonSerializerOptions
            {
                WriteIndented = true 
            };

            using (FileStream fs = new FileStream(filePathReport, FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<TestsContainer>(fs, Report, options);
                Console.WriteLine("Data has been saved to file");
            }

        }

        private static List<Test> Search(List<Test> tests, ValuesContainer DataValues)
        {
            List<Test> newTests = new List<Test>();
            foreach (var value in tests)
            {
                Test test = new Test(value);
                test.Value = SetValue(DataValues, test);
                if (test.Values != null)
                {
                    test.Values = Search(test.Values, DataValues);
                }
                newTests.Add(test);
            }
            return newTests;
        }
        private static string SetValue(ValuesContainer container, Test test)
        {
            int id = test.Id;
            foreach (var value in container.Values)
            {
                if(value.Id == id)
                {
                    return value.Value;
                    break;
                }
             }
            return "";

        }
        private static String EnterFilePath(string nameFile)
        {
            Console.WriteLine($"Enter file path ({nameFile}):");
            string filePath = Console.ReadLine();
            return filePath;
        }
    }

    public class Test
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string? Title { get; set; }
        [JsonPropertyName("value")]
        public string? Value { get; set; }
        [JsonPropertyName("values")]
        public List<Test>? Values { get; set; }

        public Test() { }
        public Test(Test test)
        {
            Id = test.Id;
            Title = test.Title;
            Value = test.Value;
            Values = test.Values;
        }
    }
    public class ResultTest
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }
    public class ValuesContainer
    {
        [JsonPropertyName("values")]
        public List<ResultTest> Values { get; set; } = new List<ResultTest>();
    }
    public class TestsContainer
    {
        [JsonPropertyName("tests")]
        public List<Test> tests { get; set; } = new List<Test>();
    }

}