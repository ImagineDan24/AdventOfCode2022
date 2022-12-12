namespace AdventOfCode2022.Day
{
    public static class Day11
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\Day11.txt";
            var lines = File.ReadAllLines(fileInput);

            if (lines != null)
            {
                Part1(lines, 3, 20);
                Part2(lines, 1, 10000);
            }
        }

        public class Monkey
        {
            public List<int>? items;
            public string? sign;
            public string? op;
            public int divisibleBy;
            public int isTrue;
            public int isFalse;
            public int itemsInspected;
            public int lowerWorry;

            public int operation(int worryLevel, string sign, string op)
            {
                itemsInspected++;

                if (op == "old") {
                    if (sign == "+") { return worryLevel + worryLevel; }
                    else if (sign == "-") { return worryLevel - worryLevel; }
                    else if (sign == "*") { return worryLevel * worryLevel; }
                    return worryLevel / worryLevel;
                }

                if (sign == "+") { return worryLevel + Int32.Parse(op); }
                else if (sign == "-") { return worryLevel - Int32.Parse(op); }
                else if (sign == "*") { return worryLevel * Int32.Parse(op); }
                return worryLevel / Int32.Parse(op);
            }

            public int throwTo(int item, int divisibleBy, int lowerWorry)
            {
                if ((item / lowerWorry) % divisibleBy == 0) { return isTrue; }
                return isFalse;
            }
        }

        public static void Part1(String[] lines, int numToLowerWorry, int rounds)
        {
            Console.WriteLine("Commencing Day 11, Part 1...");

            var monkeys = new List<Monkey>();

            for (int i = 0; i < lines.Length - 5; i += 7)
            {
                var getItemList = new List<int>();
                foreach (var item in lines[i + 1].Split(": ")[1].Split(", "))
                {
                    getItemList.Add(Int32.Parse(item));
                }
                var getSign = lines[i + 2].Split("old ")[1].Split(" ")[0];
                var getOp = lines[i + 2].Split("old ")[1].Split(" ")[1];
                var getDivisibleBy = Int32.Parse(lines[i + 3].Split("by ")[1]);
                var getIsTrue = Int32.Parse(lines[i + 4].Split("monkey ")[1]);
                var getIsFalse = Int32.Parse(lines[i + 5].Split("monkey ")[1]);

                monkeys.Add(new Monkey() { items = getItemList, sign = getSign, op = getOp, divisibleBy = getDivisibleBy, isTrue = getIsTrue, isFalse = getIsFalse, itemsInspected = 0, lowerWorry = numToLowerWorry });
            }

            for (int i = 0; i < rounds; i++)
            {
                for (int m = 0; m < monkeys.Count; m++) 
                {
                    if (monkeys[m].items != null)
                    {
                        for (int j = 0; j < monkeys[m].items.Count; j++)
                        {
                            var newWorryLevel = monkeys[m].operation(monkeys[m].items[j], monkeys[m].sign, monkeys[m].op);
                            var throwTo = monkeys[m].throwTo(newWorryLevel, monkeys[m].divisibleBy, monkeys[m].lowerWorry);
                            monkeys[throwTo].items.Add(newWorryLevel / monkeys[m].lowerWorry);
                        }
                        monkeys[m].items.Clear();
                    }
                }
                if (i == 0 || i == 19 || i == 1000)
                {
                    var x = 1;
                }
            }

            int highest = monkeys[0].itemsInspected;
            int secondHighest = monkeys[1].itemsInspected;
            for (int i = 0; i < monkeys.Count; i++)
            {
                if (monkeys[i].itemsInspected > highest)
                {
                    secondHighest = highest;
                    highest = monkeys[i].itemsInspected;
                }
                else if (monkeys[i].itemsInspected > secondHighest)
                {
                    secondHighest = monkeys[i].itemsInspected;
                }
            }

            Console.WriteLine("Answer: " + (highest * secondHighest));

        }

        public static void Part2(String[] lines, int numToLowerWorry, int rounds)
        {
            Console.WriteLine("Commencing Day 11, Part 2...");

            Part1(lines, numToLowerWorry, rounds);

        }
    }
}
