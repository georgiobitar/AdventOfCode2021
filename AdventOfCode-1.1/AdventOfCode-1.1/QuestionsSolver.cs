using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_1._1
{
    public class QuestionsSolver
    {
        public void Question11()
        {
            List<int> measurementsList = System.IO.File.ReadAllLines(@"..\\..\\..\\inputDay1.txt").ToList().ConvertAll(int.Parse);

            int increasingMeasurements = 0;

            for (int i = 1; i < measurementsList.Count; i++)
            {
                increasingMeasurements = (measurementsList[i] - measurementsList[i - 1] > 0) ? increasingMeasurements + 1 : increasingMeasurements;
            }

            Console.WriteLine("Day 1 Question 1: " + increasingMeasurements.ToString());
        }

        public void Question12()
        {
            List<int> measurementsList = System.IO.File.ReadAllLines(@"..\\..\\..\\inputDay1.txt").ToList().ConvertAll(int.Parse);

            int increasingMeasurements = 0;

            for (int i = 1; i < measurementsList.Count - 2; i++)
            {
                increasingMeasurements = ((measurementsList[i] + measurementsList[i + 1] + measurementsList[i + 2]) - (measurementsList[i - 1] + measurementsList[i] + measurementsList[i + 1]) > 0) ? increasingMeasurements + 1 : increasingMeasurements;
            }

            Console.WriteLine("Day 1 Question 2: " + increasingMeasurements.ToString());
        }

        public void Question21()
        {
            List<string> commands = System.IO.File.ReadAllLines(@"..\\..\\..\\inputDay2.txt").ToList();
            int horizontalPosition = 0;
            int depth = 0;

            foreach (string command in commands)
            {
                int number = int.Parse(command.Split(" ")[1]);
                switch (command.Split(" ")[0])
                {
                    case "forward":
                        horizontalPosition += number;
                        break;
                    case "up":
                        depth -= number;
                        break;
                    case "down":
                        depth += number;
                        break;
                }
            }

            Console.WriteLine("Day 2 Question 1: " + horizontalPosition * depth);
        }

        public void Question22()
        {
            List<string> commands = System.IO.File.ReadAllLines(@"..\\..\\..\\inputDay2.txt").ToList();
            int horizontalPosition = 0;
            int depth = 0;
            int aim = 0;

            foreach (string command in commands)
            {
                int number = int.Parse(command.Split(" ")[1]);
                switch (command.Split(" ")[0])
                {
                    case "forward":
                        horizontalPosition += number;
                        depth += number*aim;
                        break;
                    case "up":
                        aim -= number;
                        break;
                    case "down":
                        aim += number;
                        break;
                }
            }

            Console.WriteLine("Day 2 Question 2: " + horizontalPosition * depth);
        }

        public void Question31()
        {
            int k = 0;
            string gamma = "";
            List<int> count = new List<int>();
            System.IO.File.ReadLines(@"..\\..\\..\\inputDay3.txt").First().ToCharArray().ToList().ForEach(x => count.Add(int.Parse(x.ToString())));
            
            foreach (string line in System.IO.File.ReadLines(@"..\\..\\..\\inputDay3.txt").Skip(1))
            {
                for(int i=0; i<count.Count; i++)
                {
                    count[i] += int.Parse(line[i].ToString());                
                }
                k++;
            }
            for(int j=0; j<count.Count; j++)
            {
                gamma += (count[j] > k/2) ?  "1" : "0";
            }
            Console.WriteLine("Power Consumption: " + Convert.ToInt32(gamma, 2)*Convert.ToInt32(gamma.Replace("1", "2").Replace("0", "1").Replace("2", "0"), 2));
        }

        public void Question32()
        {
            List<string> lines = System.IO.File.ReadLines(@"..\\..\\..\\inputDay3.txt").ToList();
            Int64 oxygenGeneratorRating = 0;
            Int64 co2ScrubberRating = 0;
            int k = 0;
            List<int> count = new List<int>(){ 0 };
            while(oxygenGeneratorRating == 0)
            {
                foreach(string line in lines)
                {
                    count[k] += int.Parse(line[k].ToString());
                }
                if(count[k]>= int.Parse(lines.Count.ToString()) / 2.0)
                {
                    lines.RemoveAll(x => x[k] == '0');
                }
                else {
                    lines.RemoveAll(x => x[k] == '1');
                }

                if (lines.Count == 1)
                {
                    oxygenGeneratorRating = Convert.ToInt64(String.Join("",lines.First()),2);
                }
                else
                {
                    k++;
                    count.Add(0);
                }
            }

            lines = System.IO.File.ReadLines(@"..\\..\\..\\inputDay3.txt").ToList();
            count = new List<int>() { 0 };
            k = 0;
            while (co2ScrubberRating == 0)
            {
                foreach (string line in lines)
                {
                    count[k] += int.Parse(line[k].ToString());
                }
                if (count[k] >= int.Parse(lines.Count.ToString()) / 2.0)
                {
                    lines.RemoveAll(x => x[k] == '1');
                }
                else
                {
                    lines.RemoveAll(x => x[k] == '0');
                }

                if (lines.Count == 1)
                {
                    co2ScrubberRating = Convert.ToInt64(String.Join("", lines.First()), 2);
                }
                else
                {
                    k++;
                    count.Add(0);
                }
            }
            Console.WriteLine("Life Support Rating: " + oxygenGeneratorRating * co2ScrubberRating);
        }
    }
}

