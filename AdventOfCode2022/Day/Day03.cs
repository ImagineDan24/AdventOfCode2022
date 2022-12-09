namespace AdventOfCode2022.Day
{
    public static class Day03
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\Day03.txt";
            var lines = File.ReadAllLines(fileInput);

            if (lines != null)
            {
                Part1(lines);
                Part2(lines);
            }
        }

        public static void Part1(String[] lines)
        {
            Console.WriteLine("Commencing Day 03, Part 1...");

            //Lowercase item types a through z have priorities 1 through 26.
            //Uppercase item types A through Z have priorities 27 through 52.

            int total = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                var firstHalf = lines[i].Substring(0, lines[i].Length / 2);
                var secondHalf = lines[i].Substring(lines[i].Length / 2, lines[i].Length / 2);

                var characterFound = firstHalf.Intersect(secondHalf).ToList()[0];
                var asciiValue = (int)characterFound;
                int value = 0;

                if (asciiValue >= 97 && asciiValue <= 122)  //lowercase
                {
                    value = asciiValue - 96;
                }
                else if (asciiValue >= 65 && asciiValue <= 90) //uppercase
                {
                    value = asciiValue - 38;
                }

                total += value;
            }
            Console.WriteLine("Answer: " + total);
        }

        public static void Part2(String[] lines)
        {
            Console.WriteLine("Commencing Day 03, Part 2...");

            int total = 0;

            for (int i = 0; i <= lines.Length - 3; i+=3)
            {
                var first = lines[i];
                var second = lines[i+1];
                var third = lines[i + 2];

                var characterFound = first.Intersect(second).ToList().Intersect(second.Intersect(third).ToList()).ToList()[0];
                var asciiValue = (int)characterFound;
                int value = 0;

                if (asciiValue >= 97 && asciiValue <= 122)  //lowercase
                {
                    value = asciiValue - 96;
                }
                else if (asciiValue >= 65 && asciiValue <= 90) //uppercase
                {
                    value = asciiValue - 38;
                }

                total += value;
            }
            Console.WriteLine("Answer: " + total);

        }
    }
}
