namespace AdventOfCode2022.Day
{
    public static class Day07
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\Day07.txt";
            var lines = File.ReadAllLines(fileInput);

            if (lines != null)
            {
                Part1(lines);
                Part2(lines);
            }
        }

        public class Directory
        {
            public string? Name;
            public int Size;
            public List<Directory> Children = new List<Directory>();
            public Directory? Parent = null;
        }

        public static List<Directory> ObtainAllDirectories(String[] lines)
        {
            var root = new Directory() { Name = "/", Size = 0 };

            var allDirectories = new List<Directory> { root };
            var current = root;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("$ cd"))
                {
                    var dir = lines[i].Split("cd ")[1];
                    if (dir == "..")
                    {
                        current = current?.Parent;
                    }
                    else
                    {
                        var child = new Directory() { Name = dir, Parent = current };
                        current?.Children.Add(child);
                        allDirectories.Add(child);
                        current = child;
                    }
                }
                else if (!lines[i].StartsWith("$ ls") && !lines[i].StartsWith("dir"))
                {
                    var size = int.Parse(lines[i].Split(" ")[0]);
                    var current2 = current;
                    while (current2 != null)
                    {
                        current2.Size += size;
                        current2 = current2.Parent;
                    }
                }
            }
            return allDirectories;
        }

        public static void Part1(String[] lines)
        {
            Console.WriteLine("Commencing Day 07, Part 1...");

            var allDirectories = ObtainAllDirectories(lines);

            int sum = 0;
            foreach (var dir in allDirectories)
            {
                if (dir.Size <= 100000)
                {
                    sum += dir.Size;
                }
            }

            Console.WriteLine("Answer: " + sum);
        }

        public static void Part2(String[] lines)
        {
            Console.WriteLine("Commencing Day 07, Part 2...");

            var allDirectories = ObtainAllDirectories(lines);

            var rootSize = allDirectories[0].Size;
            var remainingDiskSpace = 70000000 - rootSize;
            var spaceNeededToDelete = 30000000 - remainingDiskSpace;

            var SmallestDirToDelete = rootSize;

            for (int i = 0; i < allDirectories.Count; i++)
            {
                if (allDirectories[i].Size < SmallestDirToDelete && allDirectories[i].Size >= spaceNeededToDelete)
                {
                    SmallestDirToDelete = allDirectories[i].Size;
                }
            }

            Console.WriteLine("Answer: " + SmallestDirToDelete);
        }
    }
}
