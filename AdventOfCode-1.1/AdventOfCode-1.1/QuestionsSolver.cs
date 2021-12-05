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
                        depth += number * aim;
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
                for (int i = 0; i < count.Count; i++)
                {
                    count[i] += int.Parse(line[i].ToString());
                }
                k++;
            }
            for (int j = 0; j < count.Count; j++)
            {
                gamma += (count[j] > k / 2) ? "1" : "0";
            }
            Console.WriteLine("Power Consumption: " + Convert.ToInt32(gamma, 2) * Convert.ToInt32(gamma.Replace("1", "2").Replace("0", "1").Replace("2", "0"), 2));
        }

        public void Question32()
        {
            List<string> lines = System.IO.File.ReadLines(@"..\\..\\..\\inputDay3.txt").ToList();
            Int64 oxygenGeneratorRating = 0;
            Int64 co2ScrubberRating = 0;
            int k = 0;
            List<int> count = new List<int>() { 0 };
            while (oxygenGeneratorRating == 0)
            {
                foreach (string line in lines)
                {
                    count[k] += int.Parse(line[k].ToString());
                }
                if (count[k] >= int.Parse(lines.Count.ToString()) / 2.0)
                {
                    lines.RemoveAll(x => x[k] == '0');
                }
                else
                {
                    lines.RemoveAll(x => x[k] == '1');
                }

                if (lines.Count == 1)
                {
                    oxygenGeneratorRating = Convert.ToInt64(String.Join("", lines.First()), 2);
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

        public void Question41()
        {
            List<string> input = System.IO.File.ReadLines(@"..\\..\\..\\inputDay4.txt").ToList();
            List<int> numbers = input.First().Split(",").ToList().ConvertAll(int.Parse);
            int k = 0;
            int winner = 0;
            int winningNumber = 0;
            List<Dictionary<int, bool>> boards = new List<Dictionary<int, bool>>();
            boards.Add(new Dictionary<int, bool>());
            foreach (string line in input.Skip(2))
            {
                if (line == "")
                {
                    k++;
                    boards.Add(new Dictionary<int, bool>());
                    continue;
                }
                line.Split(" ").Where(x => x != "").ToList().ForEach(x => boards[k].Add(int.Parse(x), false));
            }

            foreach (int number in numbers)
            {
                boards.Where(x => x.ContainsKey(number)).ToList().ForEach(x => x[number] = true);
                winningNumber = number;
                for (int i = 0; i < Math.Sqrt(boards[0].Count); i++)
                {
                    if (boards.Where(x => x.ElementAt(0 + i * 5).Value == true && x.ElementAt(0 + i * 5).Value == x.ElementAt(1 + i * 5).Value && x.ElementAt(0 + i * 5).Value == x.ElementAt(2 + i * 5).Value && x.ElementAt(0 + i * 5).Value == x.ElementAt(3 + i * 5).Value && x.ElementAt(0 + i * 5).Value == x.ElementAt(4 + i * 5).Value).Count() > 0)
                    {
                        winner = boards.IndexOf(boards.FirstOrDefault(x => x.ElementAt(0 + i * 5).Value == true && x.ElementAt(1 + i * 5).Value == true && x.ElementAt(2 + i * 5).Value == true && x.ElementAt(3 + i * 5).Value == true && x.ElementAt(4 + i * 5).Value == true));
                        break;
                    }

                    if (boards.Where(x => (x.ElementAt(i).Value == true && x.ElementAt(i + 5).Value == true && x.ElementAt(i + 10).Value == true && x.ElementAt(i + 15).Value == true && x.ElementAt(i + 20).Value == true)).Count() > 0)
                    {
                        winner = boards.IndexOf(boards.FirstOrDefault(x => x.ElementAt(i).Value == true && x.ElementAt(i + 5).Value == true && x.ElementAt(i + 10).Value == true && x.ElementAt(i + 15).Value == true && x.ElementAt(i + 20).Value == true));
                        break;
                    }
                }
                if (winner != 0)
                    break;
            }
            int indexx = 0;
            foreach (Dictionary<int, bool> board in boards)
            {
                Console.WriteLine("Board " + indexx);
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(((board.ElementAt(0 + i * 5).Value) ? "V" : "O") + ((board.ElementAt(1 + i * 5).Value) ? "V" : "O") + ((board.ElementAt(2 + i * 5).Value) ? "V" : "O") + ((board.ElementAt(3 + i * 5).Value) ? "V" : "O") + ((board.ElementAt(4 + i * 5).Value) ? "V" : "O"));
                }
                indexx++;
                Console.WriteLine();
            }

            Console.WriteLine(winner);
            Console.WriteLine(winningNumber * boards[winner].Where(x => x.Value == false).ToList().Sum(x => x.Key));
        }

        public void Question42()
        {
            List<string> input = System.IO.File.ReadLines(@"..\\..\\..\\inputDay4.txt").ToList();
            List<int> numbers = input.First().Split(",").ToList().ConvertAll(int.Parse);
            int k = 0;
            bool win = false;
            int winningNumber = 0;
            List<Dictionary<int, bool>> boards = new List<Dictionary<int, bool>>();
            boards.Add(new Dictionary<int, bool>());
            foreach (string line in input.Skip(2))
            {
                if (line == "")
                {
                    k++;
                    boards.Add(new Dictionary<int, bool>());
                    continue;
                }
                line.Split(" ").Where(x => x != "").ToList().ForEach(x => boards[k].Add(int.Parse(x), false));
            }

            foreach (int number in numbers)
            {
                if (win) break;
                boards.Where(x => x.ContainsKey(number)).ToList().ForEach(x => x[number] = true);
                winningNumber = number;
                for (int i = 0; i < 5; i++)
                {
                    if (boards.Count == 1 && ((boards[0].ElementAt(0 + i * 5).Value == true && boards[0].ElementAt(1 + i * 5).Value == true && boards[0].ElementAt(2 + i * 5).Value == true && boards[0].ElementAt(3 + i * 5).Value == true && boards[0].ElementAt(4 + i * 5).Value == true) || (boards[0].ElementAt(i).Value == true && boards[0].ElementAt(i + 5).Value == true && boards[0].ElementAt(i + 10).Value == true && boards[0].ElementAt(i + 15).Value == true && boards[0].ElementAt(i + 20).Value == true)))
                    {
                        for (int ii = 0; ii < 5; ii++)
                        {
                            Console.WriteLine(((boards[0].ElementAt(0 + ii * 5).Value) ? "V" : "O") + ((boards[0].ElementAt(1 + ii * 5).Value) ? "V" : "O") + ((boards[0].ElementAt(2 + ii * 5).Value) ? "V" : "O") + ((boards[0].ElementAt(3 + ii * 5).Value) ? "V" : "O") + ((boards[0].ElementAt(4 + ii * 5).Value) ? "V" : "O"));
                        }
                        win = true;
                        break;
                    }
                    
                    boards.RemoveAll(x => x.ElementAt(0 + i * 5).Value == true && x.ElementAt(1 + i * 5).Value == true && x.ElementAt(2 + i * 5).Value == true && x.ElementAt(3 + i * 5).Value == true && x.ElementAt(4 + i * 5).Value == true);

                    boards.RemoveAll(x => x.ElementAt(i).Value == true && x.ElementAt(i + 5).Value == true && x.ElementAt(i + 10).Value == true && x.ElementAt(i + 15).Value == true && x.ElementAt(i + 20).Value == true);

                }
            }
            int indexx = 0;
            foreach (Dictionary<int, bool> board in boards)
            {
                Console.WriteLine("Board " + indexx);
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(((board.ElementAt(0 + i * 5).Value) ? "V" : "O") + ((board.ElementAt(1 + i * 5).Value) ? "V" : "O") + ((board.ElementAt(2 + i * 5).Value) ? "V" : "O") + ((board.ElementAt(3 + i * 5).Value) ? "V" : "O") + ((board.ElementAt(4 + i * 5).Value) ? "V" : "O"));
                }
                indexx++;
                Console.WriteLine();
            }
            Console.WriteLine(winningNumber);
            Console.WriteLine(winningNumber * boards[0].Where(x => x.Value == false).ToList().Sum(x => x.Key));

        }

        public void Question51()
        {

        }
    }
}

