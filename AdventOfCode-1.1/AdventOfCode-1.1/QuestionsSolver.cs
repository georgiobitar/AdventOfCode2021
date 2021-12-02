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
    }
}

