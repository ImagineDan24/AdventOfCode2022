using System;
using System.IO;

namespace AdventOfCode2022.Day
{
    public static class Day1
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\Day1.txt";
            var lines = File.ReadAllLines(fileInput);

            if (lines != null)
            {
                Part1(lines);
                Part2(lines);
            }
        }

        public static void Part1(String[] lines)
        {
            Console.WriteLine("Commencing Day 1, Part 1...");

            int highestCals = 0;
            int currentCalSum = 0;

            for (int i = 0; i < lines.Length; i++)
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

        public static void Part2(String[] lines)
        {
            Console.WriteLine("Commencing Day 1, Part 2...");

            int highestCals = 0;
            int secondHighestCals = 0;
            int thirdHighestCals = 0;
            int currentCalSum = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == "")
                {
                    if (currentCalSum > highestCals)
                    {
                        thirdHighestCals = secondHighestCals;
                        secondHighestCals = highestCals;
                        highestCals = currentCalSum;

                    }
                    else if (currentCalSum > secondHighestCals && currentCalSum < highestCals)
                    {
                        thirdHighestCals = secondHighestCals;
                        secondHighestCals = currentCalSum;
                    }
                    else if (currentCalSum > thirdHighestCals && currentCalSum < secondHighestCals)
                    {
                        thirdHighestCals = currentCalSum;
                    }
                    currentCalSum = 0;
                }
                else
                {
                    currentCalSum += int.Parse(lines[i]);
                }
            }

            var answer = highestCals + secondHighestCals + thirdHighestCals;

            Console.WriteLine("Answer: " + answer);
        }
    }
}
