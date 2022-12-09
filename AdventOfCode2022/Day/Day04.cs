namespace AdventOfCode2022.Day
{
    public static class Day04
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\Day04.txt";
            var lines = File.ReadAllLines(fileInput);

            if (lines != null)
            {
                Part1(lines);
                Part2(lines);
            }
        }

        public static void Part1(String[] lines)
        {
            Console.WriteLine("Commencing Day 04, Part 1...");

            int total = 0;

            for (int i=0; i < lines.Length; i++)
            {
                var x1 = Int32.Parse(lines[i].Split(',')[0].Split('-')[0]);
                var x2 = Int32.Parse(lines[i].Split(',')[0].Split('-')[1]);
                var y1 = Int32.Parse(lines[i].Split(',')[1].Split('-')[0]);
                var y2 = Int32.Parse(lines[i].Split(',')[1].Split('-')[1]);

                if ((x1 <= y1 && x2 >= y2) || (y1 <= x1 && y2 >= x2)) { total++; }
            }

            Console.WriteLine("Answer; " + total);
        }

        public static void Part2(String[] lines)
        {
            Console.WriteLine("Commencing Day 04, Part 2...");

            int total = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                var x1 = Int32.Parse(lines[i].Split(',')[0].Split('-')[0]);
                var x2 = Int32.Parse(lines[i].Split(',')[0].Split('-')[1]);
                var y1 = Int32.Parse(lines[i].Split(',')[1].Split('-')[0]);
                var y2 = Int32.Parse(lines[i].Split(',')[1].Split('-')[1]);
                
                if ((x1 <= y1 && y1 <= x2) || (y1 <= x1 && x1 <= y2)) { total++; }
            }

            Console.WriteLine("Answer; " + total);
        }
    }
}
