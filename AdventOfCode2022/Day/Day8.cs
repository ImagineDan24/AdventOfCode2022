using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2022.Day
{
    public static class Day8
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\Day8.txt";
            var lines = File.ReadAllLines(fileInput);

            if (lines != null)
            {
                Part1(lines);
                Part2(lines);
            }
        }

        public static void Part1(String[] lines)
        {
            Console.WriteLine("Commencing Day 8, Part 1...");

            int sum = 0;

            for (int i = 1; i < lines.Length - 1; i++)
            {
                for (int j = 1; j < lines[i].Length - 1; j++)
                {
                    var current = Int32.Parse(lines[i][j].ToString());
                    var isVisible = true;

                    for (int k = i + 1; k < lines.Length; k++) //checking below
                    {
                        var compare = Int32.Parse(lines[k][j].ToString());
                        if (current <= compare && isVisible)
                        {
                            isVisible = false;
                        }
                    }
                    if (isVisible == true)
                    {
                        sum++;
                    }

                    if (!isVisible)
                    {
                        isVisible = true;
                        for (int k = i - 1; k >= 0; k--) //checking above
                        {
                            var compare = Int32.Parse(lines[k][j].ToString());
                            if (current <= compare && isVisible)
                            {
                                isVisible = false;
                            }
                        }
                        if (isVisible == true)
                        {
                            sum++;
                        }
                    }

                    if (!isVisible)
                    {
                        isVisible = true;
                        for (int k = j + 1; k < lines[i].Length; k++) //checking right
                        {
                            var compare = Int32.Parse(lines[i][k].ToString());
                            if (current <= compare && isVisible)
                            {
                                isVisible = false;
                            }
                        }
                        if (isVisible == true)
                        {
                            sum++;
                        }
                    }

                    if (!isVisible)
                    {
                        isVisible = true;
                        for (int k = j - 1; k >= 0; k--) //checking left
                        {
                            var compare = Int32.Parse(lines[i][k].ToString());
                            if (current <= compare && isVisible)
                            {
                                isVisible = false;
                            }
                        }
                        if (isVisible == true)
                        {
                            sum++;
                        }
                    }
                }
            }

            var perimeter = 2 * (lines.Length) + 2 * (lines[0].Length) - 4;

            sum += perimeter;

            Console.WriteLine("Answer: " + sum);
        }

        public static void Part2(String[] lines)
        {
            Console.WriteLine("Commencing Day 8, Part 2...");

            int highestProduct = 0;

            for (int i = 1; i < lines.Length - 1; i++)
            {
                for (int j = 1; j < lines[i].Length - 1; j++)
                {
                    var current = Int32.Parse(lines[i][j].ToString());
                    var isVisible = true;
                    var product = 1;
                    var sum = 0;

                    for (int k = i + 1; k < lines.Length; k++) //checking below
                    {
                        var compare = Int32.Parse(lines[k][j].ToString());
                        if (current <= compare && isVisible)
                        {
                            sum = k - i;
                            isVisible = false;
                        }
                        else if (current > compare && isVisible)
                        {
                            sum = k - i;
                        }
                    }
                    if (sum == 0) { sum++; }
                    product *= sum;
                    sum = 0;
                    isVisible = true;
                    
                    for (int k = i - 1; k >= 0; k--) //checking above
                    {
                        var compare = Int32.Parse(lines[k][j].ToString());
                        if (current <= compare && isVisible)
                        {
                            sum = i - k;
                            isVisible = false;
                        }
                        else if (current > compare && isVisible)
                        {
                            sum = i - k;
                        }
                    }
                    if (sum == 0) { sum++; }
                    product *= sum;
                    sum = 0;
                    isVisible = true;

                    for (int k = j + 1; k < lines[i].Length; k++) //checking right
                    {
                        var compare = Int32.Parse(lines[i][k].ToString());
                        if (current <= compare && isVisible)
                        {
                            sum = k - j;
                            isVisible = false;
                        }
                        else if (current > compare && isVisible)
                        {
                            sum = k - j;
                        }
                    }
                    if (sum == 0) { sum++; }
                    product *= sum;
                    sum = 0;
                    isVisible = true;

                    for (int k = j - 1; k >= 0; k--) //checking left
                    {
                        var compare = Int32.Parse(lines[i][k].ToString());
                        if (current <= compare && isVisible)
                        {
                            sum = j - k;
                            isVisible = false;
                        }
                        else if (current > compare && isVisible)
                        {
                            sum = j - k;
                        }
                    }
                    if (sum == 0) { sum++; }
                    product *= sum;

                    if (product > highestProduct) { highestProduct = product; }
                }
            }

            Console.WriteLine("Answer: " + highestProduct);

        }
    }
}
