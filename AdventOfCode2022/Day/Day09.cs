namespace AdventOfCode2022.Day
{
    public static class Day09
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\Day09.txt";
            var lines = File.ReadAllLines(fileInput);

            if (lines != null)
            {
                Part1(lines);
                Part2(lines);
            }
        }

        public static List<(int, int)> travel((int, int) head, (int, int) tail)
        {
            if (head.Item1 - tail.Item1 > 1 && head.Item2 - tail.Item2 > 1) //head is up 2 and right 2
            {
                tail.Item1++;
                tail.Item2++;
            }
            else if (tail.Item1 - head.Item1 > 1 && head.Item2 - tail.Item2 > 1) //head is up 2 and left 2
            {
                tail.Item1--;
                tail.Item2++;
            }
            else if (head.Item1 - tail.Item1 > 1 && tail.Item2 - head.Item2 > 1) //head is down 2 and right 2
            {
                tail.Item1++;
                tail.Item2--;
            }
            else if (tail.Item1 - head.Item1 > 1 && tail.Item2 - head.Item2 > 1) //head is down 2 and left 2
            {
                tail.Item1--;
                tail.Item2--;
            }
            else if (head.Item1 - tail.Item1 > 1 && head.Item2 - tail.Item2 == 1) //head is up 1 and to the right 2
            {
                tail.Item1++;
                tail.Item2++;
            }
            else if (tail.Item1 - head.Item1 > 1 && head.Item2 - tail.Item2 == 1) //head is up 1 and to the left 2
            {
                tail.Item1--;
                tail.Item2++;
            }
            else if (tail.Item1 - head.Item1 > 1 && tail.Item2 - head.Item2 == 1) //head is down 1 and to the left 2
            {
                tail.Item1--;
                tail.Item2--;
            }
            else if (head.Item1 - tail.Item1 > 1 && tail.Item2 - head.Item2 == 1) //head is down 1 and to the right 2
            {
                tail.Item1++;
                tail.Item2--;
            }
            else if (head.Item1 - tail.Item1 == 1 && head.Item2 - tail.Item2 > 1) //head is up 2 and to the right 1
            {
                tail.Item1++;
                tail.Item2++;
            }
            else if (tail.Item1 - head.Item1 == 1 && head.Item2 - tail.Item2 > 1) //head is up 2 and to the left 1
            {
                tail.Item1--;
                tail.Item2++;
            }
            else if (head.Item1 - tail.Item1 == 1 && tail.Item2 - head.Item2 > 1) //head is down 2 and to the right 1
            {
                tail.Item1++;
                tail.Item2--;
            }
            else if (tail.Item1 - head.Item1 == 1 && tail.Item2 - head.Item2 > 1) //head is down 2 and to the left 1
            {
                tail.Item1--;
                tail.Item2--;
            }
            else if (head.Item1 - tail.Item1 > 1) //head is to the right of tail more than 1
            {
                tail.Item1++;
            }

            else if (tail.Item1 - head.Item1 > 1) //head is to the left of tail more than 1
            {
                tail.Item1--;
            }

            else if (tail.Item2 - head.Item2 > 1) //head is below tail more than 1
            {
                tail.Item2--;
            }
            else if (head.Item2 - tail.Item2 > 1) //head is above tail more than 1
            {
                tail.Item2++;
            }

            return new List<(int, int)>() { head, tail };
        }

        public static void Part1(String[] lines)
        {
            Console.WriteLine("Commencing Day 09, Part 1...");

            var positions = new List<(int, int)>();
            var head = (0, 0);
            var tail = (0, 0);

            for (int i = 0; i < lines.Length; i++)
            {
                var command = lines[i].Split(" ")[0];
                var distance = Int32.Parse(lines[i].Split(" ")[1]);

                if (command == "R")
                {
                    for (int j = 0; j < distance; j++)
                    {
                        head.Item1++;
                        var response = travel(head, tail);
                        head = response[0];
                        tail = response[1];
                        positions.Add(tail);
                    }
                }
                else if (command == "L")
                {
                    for (int j = 0; j < distance; j++)
                    {
                        head.Item1--;
                        var response = travel(head, tail);
                        head = response[0];
                        tail = response[1];
                        positions.Add(tail);
                    }
                }
                else if (command == "U")
                {
                    for (int j = 0; j < distance; j++)
                    {
                        head.Item2++;
                        var response = travel(head, tail);
                        head = response[0];
                        tail = response[1];
                        positions.Add(tail);
                    }
                }
                else if (command == "D")
                {
                    for (int j = 0; j < distance; j++)
                    {
                        head.Item2--;
                        var response = travel(head, tail);
                        head = response[0];
                        tail = response[1];
                        positions.Add(tail);
                    }
                }
            }
            
            Console.WriteLine("Answer: " + positions.Distinct().Count());
        }


        public static List<(int, int)> travel2((int, int) head, (int, int) tail1, (int, int) tail2, (int, int) tail3, (int, int) tail4, (int, int) tail5, (int, int) tail6, (int, int) tail7, (int, int) tail8, (int, int) tail9)
        {
            var response1 = travel(head, tail1);
            head = response1[0];
            tail1 = response1[1];

            var response2 = travel(tail1, tail2);
            tail1 = response2[0];
            tail2 = response2[1];

            var response3 = travel(tail2, tail3);
            tail2 = response3[0];
            tail3 = response3[1];

            var response4 = travel(tail3, tail4);
            tail3 = response4[0];
            tail4 = response4[1];

            var response5 = travel(tail4, tail5);
            tail4 = response5[0];
            tail5 = response5[1];

            var response6 = travel(tail5, tail6);
            tail5 = response6[0];
            tail6 = response6[1];

            var response7 = travel(tail6, tail7);
            tail6 = response7[0];
            tail7 = response7[1];

            var response8 = travel(tail7, tail8);
            tail7 = response8[0];
            tail8 = response8[1];

            var response9 = travel(tail8, tail9);
            tail8 = response9[0];
            tail9 = response9[1];

            return new List<(int, int)>() { head, tail1, tail2, tail3, tail4, tail5, tail6, tail7, tail8, tail9 };
        }

        public static void Part2(String[] lines)
        {
            Console.WriteLine("Commencing Day 09, Part 2...");

            var positions = new List<(int, int)>();
            var head = (0, 0);
            var tail1 = (0, 0);
            var tail2 = (0, 0);
            var tail3 = (0, 0);
            var tail4 = (0, 0);
            var tail5 = (0, 0);
            var tail6 = (0, 0);
            var tail7 = (0, 0);
            var tail8 = (0, 0);
            var tail9 = (0, 0);

            for (int i = 0; i < lines.Length; i++)
            {
                var command = lines[i].Split(" ")[0];
                var distance = Int32.Parse(lines[i].Split(" ")[1]);

                if (command == "R")
                {
                    for (int j = 0; j < distance; j++)
                    {
                        head.Item1++;
                        var response = travel2(head, tail1, tail2, tail3, tail4, tail5, tail6, tail7, tail8, tail9);
                        head = response[0];
                        tail1 = response[1];
                        tail2 = response[2];
                        tail3 = response[3];
                        tail4 = response[4];
                        tail5 = response[5];
                        tail6 = response[6];
                        tail7 = response[7];
                        tail8 = response[8];
                        tail9 = response[9];

                        positions.Add(tail9);
                    }
                }
                else if (command == "L")
                {
                    for (int j = 0; j < distance; j++)
                    {
                        head.Item1--;
                        var response = travel2(head, tail1, tail2, tail3, tail4, tail5, tail6, tail7, tail8, tail9);
                        head = response[0];
                        tail1 = response[1];
                        tail2 = response[2];
                        tail3 = response[3];
                        tail4 = response[4];
                        tail5 = response[5];
                        tail6 = response[6];
                        tail7 = response[7];
                        tail8 = response[8];
                        tail9 = response[9];

                        positions.Add(tail9);
                    }
                }
                else if (command == "U")
                {
                    for (int j = 0; j < distance; j++)
                    {
                        head.Item2++;
                        var response = travel2(head, tail1, tail2, tail3, tail4, tail5, tail6, tail7, tail8, tail9);
                        head = response[0];
                        tail1 = response[1];
                        tail2 = response[2];
                        tail3 = response[3];
                        tail4 = response[4];
                        tail5 = response[5];
                        tail6 = response[6];
                        tail7 = response[7];
                        tail8 = response[8];
                        tail9 = response[9];

                        positions.Add(tail9);
                    }
                }
                else if (command == "D")
                {
                    for (int j = 0; j < distance; j++)
                    {
                        head.Item2--;
                        var response = travel2(head, tail1, tail2, tail3, tail4, tail5, tail6, tail7, tail8, tail9);
                        head = response[0];
                        tail1 = response[1];
                        tail2 = response[2];
                        tail3 = response[3];
                        tail4 = response[4];
                        tail5 = response[5];
                        tail6 = response[6];
                        tail7 = response[7];
                        tail8 = response[8];
                        tail9 = response[9];

                        positions.Add(tail9);
                    }
                }
            }
            
            Console.WriteLine("Answer: " + positions.Distinct().Count());
        }
    }
}
