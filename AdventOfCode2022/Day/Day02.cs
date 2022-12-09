namespace AdventOfCode2022.Day
{
    public static class Day02
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\Day02.txt";
            var lines = File.ReadAllLines(fileInput);

            if (lines != null)
            {
                Part1(lines);
                Part2(lines);
            }
        }

        public static void Part1(String[] lines)
        {
            Console.WriteLine("Commencing Day 02, Part 1...");

            // A = rock, B = paper, C = scissors
            // X = rock, Y = paper, Z = scissors

            int total = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                int sum = 0;
                var left = lines[i].Split(" ")[0];
                var right = lines[i].Split(" ")[1];

                if (right == "X") { sum += 1; }
                else if (right == "Y") { sum += 2; }
                else { sum += 3; }

                if ((left == "A" && right == "X") || (left == "B" && right == "Y") || (left == "C" && right == "Z")) { sum += 3; }
                else if (left == "A" && right == "Y") { sum += 6; }
                else if (left == "B" && right == "Z") { sum += 6; }
                else if (left == "C" && right == "X") { sum += 6; }

                total += sum;
            }

            Console.WriteLine("Answer: " + total);
        }

        public static void Part2(String[] lines)
        {
            Console.WriteLine("Commencing Day 02, Part 2...");

            // A = rock, B = paper, C = scissors
            // 1 = rock, 2 = paper, 3 = scissors
            // X = lose, Y = draw, Z = win

            int total = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                int sum = 0;
                var left = lines[i].Split(" ")[0];
                var right = lines[i].Split(" ")[1];

                if (right == "X") 
                {
                    if (left == "A")
                    {
                        sum += 3;
                    }
                    else if (left == "B")
                    {
                        sum += 1;
                    }
                    else
                    {
                        sum += 2;
                    }
                }

                else if (right == "Y") 
                {
                    if (left == "A")
                    {
                        sum += 1 + 3;
                    }
                    else if (left == "B")
                    {
                        sum += 2 + 3;
                    }
                    else
                    {
                        sum += 3 + 3;
                    }
                }

                else if (right == "Z") 
                {
                    if (left == "A")
                    {
                        sum += 2 + 6;
                    }
                    else if (left == "B")
                    {
                        sum += 3 + 6;
                    }
                    else
                    {
                        sum += 1 + 6;
                    }
                }
                total += sum;
            }

            Console.WriteLine("Answer: " + total);
        }
    }
}
