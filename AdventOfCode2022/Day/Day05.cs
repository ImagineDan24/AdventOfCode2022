namespace AdventOfCode2022.Day
{
    public static class Day05
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\Day05.txt";
            var lines = File.ReadAllLines(fileInput);

            if (lines != null)
            {
                Part1(lines);
                Part2(lines);
            }
        }

        public static void Part1(String[] lines)
        {
            Console.WriteLine("Commencing Day 05, Part 1...");

            Stack<string> stack1 = new Stack<string>(new string[] { "R", "G", "H", "Q", "S", "B", "T", "N" });
            Stack<string> stack2 = new Stack<string>(new string[] { "H", "S", "F", "D", "P", "Z", "J" });
            Stack<string> stack3 = new Stack<string>(new string[] { "Z", "H", "V" });
            Stack<string> stack4 = new Stack<string>(new string[] { "M", "Z", "J", "F", "G", "H" });
            Stack<string> stack5 = new Stack<string>(new string[] { "T", "Z", "C", "D", "L", "M", "S", "R" });
            Stack<string> stack6 = new Stack<string>(new string[] { "M", "T", "W", "V", "H", "Z", "J" });
            Stack<string> stack7 = new Stack<string>(new string[] { "T", "F", "P", "L", "Z" });
            Stack<string> stack8 = new Stack<string>(new string[] { "Q", "V", "W", "S" });
            Stack<string> stack9 = new Stack<string>(new string[] { "W", "H", "L", "M", "T", "D", "N", "C" });
            Stack<string>[] stackArray = new Stack<string>[] { stack1, stack2, stack3, stack4, stack5, stack6, stack7, stack8, stack9 };
            var startLine = 10;

            for (int i = startLine; i < lines.Length; i++)
            {
                var num = Int32.Parse(lines[i].Split(' ')[1]);
                var from = Int32.Parse(lines[i].Split(' ')[3]);
                var to = Int32.Parse(lines[i].Split(' ')[5]);

                for (int j = 0; j < num; j++)
                {
                    stackArray[to - 1].Push(stackArray[from - 1].Pop());
                }
            }

            var answer = "";
            for (int i = 0; i < stackArray.Length; i++)
            {
                answer += stackArray[i].Peek().ToString();
            }

            Console.WriteLine("Answer: " + answer);
        }

        public static void Part2(String[] lines)
        {
            Console.WriteLine("Commencing Day 05, Part 2...");

            Stack<string> stack1 = new Stack<string>(new string[] { "R", "G", "H", "Q", "S", "B", "T", "N" });
            Stack<string> stack2 = new Stack<string>(new string[] { "H", "S", "F", "D", "P", "Z", "J" });
            Stack<string> stack3 = new Stack<string>(new string[] { "Z", "H", "V" });
            Stack<string> stack4 = new Stack<string>(new string[] { "M", "Z", "J", "F", "G", "H" });
            Stack<string> stack5 = new Stack<string>(new string[] { "T", "Z", "C", "D", "L", "M", "S", "R" });
            Stack<string> stack6 = new Stack<string>(new string[] { "M", "T", "W", "V", "H", "Z", "J" });
            Stack<string> stack7 = new Stack<string>(new string[] { "T", "F", "P", "L", "Z" });
            Stack<string> stack8 = new Stack<string>(new string[] { "Q", "V", "W", "S" });
            Stack<string> stack9 = new Stack<string>(new string[] { "W", "H", "L", "M", "T", "D", "N", "C" });
            Stack<string>[] stackArray = new Stack<string>[] { stack1, stack2, stack3, stack4, stack5, stack6, stack7, stack8, stack9 };
            var startLine = 10;

            for (int i = startLine; i < lines.Length; i++)
            {
                var num = Int32.Parse(lines[i].Split(' ')[1]);
                var from = Int32.Parse(lines[i].Split(' ')[3]);
                var to = Int32.Parse(lines[i].Split(' ')[5]);
                Stack<string> tmp = new Stack<string>();

                for (int j = 0; j < num; j++)
                {
                    tmp.Push(stackArray[from - 1].Pop());
                }

                for (int k = 0; k < num; k++)
                {
                    stackArray[to - 1].Push(tmp.Pop());
                }
            }

            var answer = "";
            for (int i = 0; i < stackArray.Length; i++)
            {
                answer += stackArray[i].Peek().ToString();
            }

            Console.WriteLine("Answer: " + answer);

        }
    }
}
