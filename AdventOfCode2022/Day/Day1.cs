using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day
{
    public static class Day1
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\Day1.txt";
            var lines = File.ReadAllLines(fileInput);

            Console.WriteLine("Commencing Day 1, Part 1...");

            int highestCals = 0;
            int currentCalSum = 0;

            for (int i=0; i<lines.Length; i++)
            {
                if (lines[i] == "")
                {
                    if (currentCalSum > highestCals)
                    {
                        highestCals = currentCalSum;
                    }
                    currentCalSum = 0;
                }
                else
                {
                    currentCalSum += int.Parse(lines[i]);
                }
            }
            Console.WriteLine("Answer: " + highestCals);

        }
    }
}
