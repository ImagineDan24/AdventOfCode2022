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
            public List<long>? items;
            public string? sign;
            public string? op;
            public long divisibleBy;
            public int isTrue;
            public int isFalse;
            public long itemsInspected;
            public long lowerWorry;

            public long operation(long worryLevel, string sign, string op)
            {
                itemsInspected++;

                if (op == "old") {
                    if (sign == "+") { return worryLevel + worryLevel; }
                    else if (sign == "-") { return worryLevel - worryLevel; }
                    else if (sign == "*") { return worryLevel * worryLevel; }
                    return worryLevel / worryLevel;
                }

                if (sign == "+") { return worryLevel + long.Parse(op); }
                else if (sign == "-") { return worryLevel - long.Parse(op); }
                else if (sign == "*") { return worryLevel * long.Parse(op); }
                return worryLevel / long.Parse(op);
            }

            public int throwTo(long item, long divisibleBy)
            { 
                if (item % divisibleBy == 0) { return isTrue; }
                return isFalse;
            }
        }

        public static long CalculateLCD(List<long> divisors)
        {
            var workingList = new List<long>(divisors);
            while (workingList.Distinct().Count() > 1)
            {
                var smallest = workingList.IndexOf(workingList.Min());
                workingList[smallest] += divisors[smallest];
            }
            return workingList[0];

        }

        public static List<Monkey> ParseMonkeys(String[] lines, int numToLowerWorry)
        {
            var monkeys = new List<Monkey>();

            for (int i = 0; i < lines.Length - 5; i += 7)
            {
                var getItemList = new List<long>();
                foreach (var item in lines[i + 1].Split(": ")[1].Split(", "))
                {
                    getItemList.Add(long.Parse(item));
                }
                var getSign = lines[i + 2].Split("old ")[1].Split(" ")[0];
                var getOp = lines[i + 2].Split("old ")[1].Split(" ")[1];
                var getDivisibleBy = long.Parse(lines[i + 3].Split("by ")[1]);
                var getIsTrue = int.Parse(lines[i + 4].Split("monkey ")[1]);
                var getIsFalse = int.Parse(lines[i + 5].Split("monkey ")[1]);

                monkeys.Add(new Monkey() { items = getItemList, sign = getSign, op = getOp, divisibleBy = getDivisibleBy, isTrue = getIsTrue, isFalse = getIsFalse, itemsInspected = 0, lowerWorry = numToLowerWorry });
            }

            return monkeys;
        }

        public static void Part1(String[] lines, int numToLowerWorry, int rounds)
        {
            Console.WriteLine("Commencing Day 11, Part 1...");

            var monkeys = ParseMonkeys(lines, numToLowerWorry);

            var lcd = CalculateLCD(monkeys.Select(m => m.divisibleBy).ToList());

            for (int i = 0; i < rounds; i++)
            {
                for (int m = 0; m < monkeys.Count; m++) 
                {
                    if (monkeys[m].items != null)
                    {
                        for (int j = 0; j < monkeys[m].items.Count; j++)
                        {
                            var newWorryLevel = monkeys[m].operation(monkeys[m].items[j], monkeys[m].sign, monkeys[m].op);
                            var throwTo = monkeys[m].throwTo(newWorryLevel / numToLowerWorry, monkeys[m].divisibleBy);
                            monkeys[throwTo].items.Add(newWorryLevel / numToLowerWorry);
                        }
                        monkeys[m].items.Clear();
                    }
                }
            }

            long highest = monkeys[0].itemsInspected;
            long secondHighest = monkeys[1].itemsInspected;
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

            var monkeys = ParseMonkeys(lines, numToLowerWorry);

            var lcd = monkeys.Select(m => m.divisibleBy).Aggregate((l, r) => l * r);

            for (int i = 0; i < rounds; i++)
            {
                for (int m = 0; m < monkeys.Count; m++)
                {
                    if (monkeys[m].items != null)
                    {
                        for (int j = 0; j < monkeys[m].items.Count; j++)
                        {
                            var newWorryLevel = monkeys[m].operation(monkeys[m].items[j], monkeys[m].sign, monkeys[m].op);
                            var throwTo = monkeys[m].throwTo(newWorryLevel % lcd, monkeys[m].divisibleBy);
                            monkeys[throwTo].items.Add(newWorryLevel % lcd);
                        }
                        monkeys[m].items.Clear();
                    }
                }
            }

            long highest = monkeys[0].itemsInspected;
            long secondHighest = monkeys[1].itemsInspected;
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
    }
}
