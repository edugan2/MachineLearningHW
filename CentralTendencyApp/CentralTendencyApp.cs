using System;
using System.Collections.Generic;

namespace CentralTendencyApp
{
    static class CentralTendencyApp
    {
        static void Main(string[] args)
        {
            List<double> data = new List<double> { 1, 12, 72, 53, 0, 100, 98, 93, 45, 80, 75, 33, 66, 55, 3, 100};

            double mean = Mean(data, 0, data.Count);
           

            Console.WriteLine("Mean: " +mean);
            if (data.Count % 2 == 0)
            {
                double median = MedianEven(data, data.Count);
                Console.WriteLine("Median: " +median);
            }
            else
            {
                int median = Median(data.Count);
                Console.WriteLine("Median: " + data[median]);
            }

            List<double> mode = Mode(data, 0 ,data.Count);
            Console.WriteLine("Mode: ");
            for (int i = 0; i < mode.Count; i++)
            {
                
                double x = mode[i];
                int y = (int)x;
                Console.WriteLine(data[y] + " ");
            }
        }

        static double Mean(this List<double> values, int start, int end)
        {
            double s = 0;

            for (int i = start; i < end; i++)
            {
                s += values[i];
            }

            return s / (end - start);
        }

        static int Median(int count)
        {
            if (count == 0)
            {
                return 0;
            }
            else
            {
                return count / 2;
            }
        }

       
        static double MedianEven(this List<double> values, int count)
        {
            if (count == 0)
            {
                return 0;
            }
            else
            {
                int a = count /2-1;
                int b = count / 2;
                double c = values[a];
                double d = values[b];
                return (c+d) / 2.0;
            }
        }

        static List<double> Mode(this List<double> values, int start, int end)
        {

            int i = start;
            int counter = 0;
            List<double> Top = new List<double>();
            int counterTop = 0;
            int counterPast = 0;
            for (i = start; i < end; i++)
            {

                if (counter != 0)
                {
                    counter = 0;
                }

                for (int j = i+1; j < end; j++)
                {
                    if (values[j] == values[i])
                    {
                        counter++;
                        if (counter >= counterTop)
                        {
                            counterPast = counterTop;
                            counterTop = counter;

                        }
                    }
                   
                }
                
                if (counterTop >= counterPast)
                {
                    Top.Clear();
                    Top.Add(i);
                }
                if (counterTop == counterPast && counterTop != 0)
                {
                   
                    Top.Add(i);
                }


            }

            return Top;
        }
     }
}
