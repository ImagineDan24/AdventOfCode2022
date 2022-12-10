namespace AdventOfCode2022.Day
{
    public static class Day10
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\Day10.txt";
            var lines = File.ReadAllLines(fileInput);

            if (lines != null)
            {
                Part1(lines);
                Part2(lines);
            }
        }

        public static List<string> toCommandList(String[] lines)
        {
            var list = new List<string>();

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == "noop")
                {
                    list.Add(lines[i]);
                }
                else
                {
                    list.Add("noop");
                    list.Add(lines[i]);
                }
            }

            return list;
        }

        public static void Part1(String[] lines)
        {
            Console.WriteLine("Commencing Day 10, Part 1...");

            var list = toCommandList(lines);

            var register = 1;
            var sum = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (i == 19 || i == 59 || i == 99 || i == 139 || i == 179 || i == 219)
                {
                    sum += (i + 1) * register;
                }

                if (list[i] != "noop")
                {
                    register += Int32.Parse(list[i].Split(" ")[1]);
                }
            }

            Console.WriteLine("Answer: " + sum);
        }

        public static void Part2(String[] lines)
        {
            Console.WriteLine("Commencing Day 10, Part 2...");
            Console.WriteLine("Answer: ");

            var list = toCommandList(lines);

            var register = 1;

            for (int i = 0; i < list.Count; i++)
            {
                if (i%40 == register || i%40 == register - 1 || i%40 == register + 1) { Console.Write("#"); }
                else { Console.Write("."); }
                
                if (list[i] != "noop")
                {
                    register += Int32.Parse(list[i].Split(" ")[1]);
                }

                if (i == 39 || i == 79 || i == 119 || i == 159 || i == 199 || i == 239) { Console.WriteLine(); }
            }
        }
    }
}
