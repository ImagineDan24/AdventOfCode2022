namespace AdventOfCode2022.Day
{
    public static class Day12
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\Day12.txt";
            var lines = File.ReadAllLines(fileInput);

            if (lines != null)
            {
                Part1(lines);
                Part2(lines);
            }
        }

        public static ((int, int) start, (int, int) end, Dictionary<(int, int), char> map) GenerateMapAndValues(String[] lines)
        {
            var start = (-1, -1);
            var end = (-1, -1);
            var map = new Dictionary<(int, int), char>();

            for (var y = 0; y < lines.Length; y++)
            {
                for (var x = 0; x < lines[y].Length; x++)
                {
                    var c = lines[y][x];
                    if (c == 'S')
                    {
                        start = (x, y);
                        c = 'a';
                    }
                    else if (c == 'E')
                    {
                        end = (x, y);
                        c = 'z';
                    }

                    map[(x, y)] = c;
                }
            }

            return (start, end, map);
        }

        public static int? BFS(Dictionary<(int, int), char> map, (int, int) end, Queue<((int x, int y), int)> queue)
        {
            var neighbours = new (int, int)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };
            var visited = new HashSet<(int, int)>();

            while (queue.Count > 0)
            {
                var (coord, steps) = queue.Dequeue();

                if (coord == end)
                {
                    return steps;
                }

                if (!visited.Add(coord))
                {
                    continue;
                }

                foreach (var (dx, dy) in neighbours)
                {
                    var newCoord = (coord.x + dx, coord.y + dy);

                    if (map.ContainsKey(newCoord) && map[newCoord] - map[coord] <= 1)
                    {
                        queue.Enqueue((newCoord, steps + 1));
                    }
                }
            }

            return null;
        }

        public static void Part1(String[] lines)
        {
            Console.WriteLine("Commencing Day 12, Part 1...");

            var (start, end, map) = GenerateMapAndValues(lines);

            var queue = new Queue<((int x, int y), int)>();
            queue.Enqueue((start, 0));

            var steps = BFS(map, end, queue);
            Console.WriteLine("Answer: " + steps);
        }

        public static void Part2(String[] lines)
        {
            Console.WriteLine("Commencing Day 12, Part 2...");
            var (_, end, map) = GenerateMapAndValues(lines);

            var queue = new Queue<((int x, int y), int)>();

            //find all points on map that are 'a'
            foreach (var point in map)
            {
                if (point.Value == 'a')
                {
                    queue.Enqueue((point.Key, 0));
                }
            }

            var steps = BFS(map, end, queue);
            Console.WriteLine("Answer: " + steps);
        }
    }
}
