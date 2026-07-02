using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Task2
{
    
    public static void SolutionTask2()
    {
        List<float[]> dots = new List<float[]>();
        float[] center = new float[2];
        float[] radius = new float[2];
        String line;

        //в комментариях реализация для файлов в папке Task2
        //string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        //string filePath = Path.Combine(projectPath, "Task2");
        try
        {
            //Console.WriteLine("Enter file name (ellipse):");
            //string fileName = Console.ReadLine();
            //string filePathEllipse = Path.Combine(filePath, fileName);
            Console.WriteLine("Enter file path (ellipse):");
            string filePathEllipse = Console.ReadLine();
            StreamReader sr = new StreamReader(filePathEllipse);
            line = sr.ReadLine();
            center = SetCoord(line);
            line = sr.ReadLine();
            radius = SetCoord(line);
            sr.Close();


            //Console.WriteLine("Enter file name (dots):");
            //fileName = Console.ReadLine();
            //string filePathDots = Path.Combine(filePath, fileName);
            Console.WriteLine("Enter file path (dots):");
            string filePathDots = Console.ReadLine();
            sr = new StreamReader(filePathDots);
            do {
                line = sr.ReadLine();
                if (line != null)
                {
                    float[] dotCoord = new float[2];
                    dotCoord[0] = SetCoord(line)[0];
                    dotCoord[1] = SetCoord(line)[1];
                    dots.Add(dotCoord);
                }
            } while (line!= null);
            
            sr.Close();

                    foreach (float[] dot in dots)
        {
            Console.WriteLine(WhereIsDot(dot[0], dot[1], center[0], center[1], radius[0], radius[1]));
        }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }



    }
    private static float[] SetCoord(string line)
    {
        float[] coord = new float[2];

        string[] parts = line.Split(' ');
        coord[0] = float.Parse(parts[0].Replace('.', ','));
        coord[1] = float.Parse(parts[1].Replace('.', ','));

        return coord;
    }
    private static float WhereIsDot(float dot_X, float dot_Y, float center_X, float center_Y, float radius_X, float radius_Y)
    {
        float result;

        result = Sqrt(dot_X - center_X) / Sqrt(radius_X) + (Sqrt(dot_Y - center_Y) / Sqrt(radius_Y));
        if (result > 1) result = 2;
        else if (result < 1) result = 1;
        else result = 0;
        return result;
    }

    private static float Sqrt(float x) { return x * x; }

}

