
namespace AdventOfCode2022.Day
{
    public static class Day6
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\Day6.txt";
            var input = File.ReadAllLines(fileInput)[0];

            if (input != null)
            {

                Part1And2(input, 4);
                Part1And2(input, 14);
            }
        }

        public static void Part1And2(String input, int sequenceNum)
        {
            if (sequenceNum == 4) { Console.WriteLine("Commencing Day 6, Part 1..."); }
            else { Console.WriteLine("Commencing Day 6, Part 2..."); }

            Queue<char> queue = new Queue<char>();
            int index = 0;

            for (int i = 0; i < input.Length; i++)
            {
                queue.Enqueue(input[i]);
                if (queue.Count == sequenceNum && (queue.Distinct().Count() == queue.Count))
                {
                    index = i + 1;
                    break;
                }
                else if (queue.Count == sequenceNum)
                {
                    queue.Dequeue();
                }
            }

            Console.WriteLine("Answer: " + index);
        }
    }
}
