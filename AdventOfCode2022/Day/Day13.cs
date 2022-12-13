using System.Text.Json.Nodes;

namespace AdventOfCode2022.Day
{
    public static class Day13
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\Day13.txt";
            var lines = File.ReadAllLines(fileInput);

            if (lines != null)
            {
                Part1(lines);
                Part2(lines);
            }
        }

        //return value > 0, right side smaller than left side
        //return value < 0, left side smaller than right side
        //There is also a case where both sides are the same except for length of array. If left side smaller than right, then return value < 0 and vice versa
        private static int Compare(JsonNode leftNode, JsonNode rightNode)
        {
            if (leftNode is JsonValue && rightNode is JsonValue)    //if items are both ints
            {
                return leftNode.GetValue<int>() - rightNode.GetValue<int>();
            }

            JsonArray leftArray;
            JsonArray rightArray;

            if (leftNode is JsonArray)  //if node is already an array, keep as an array. Else put in an array to compare
            { 
                leftArray = (JsonArray)leftNode; 
            }
            else 
            { 
                leftArray = new JsonArray(leftNode.GetValue<int>()); 
            }
            
            if (rightNode is JsonArray) 
            { 
                rightArray = (JsonArray)rightNode; 
            }
            else 
            { 
                rightArray = new JsonArray(rightNode.GetValue<int>()); 
            }

            //match up each value from the same index from each list
            //example: a = {1,2,3} , b = {3,2,1} , result = {(1,3),(2,2),(3,1)}
            var ListOfTuplesToCompare = leftArray.Zip(rightArray);  

            foreach (var (leftItem, rightItem) in ListOfTuplesToCompare)
            {
                var response = Compare(leftItem!, rightItem!);
                
                if (response != 0) 
                { 
                    return response; 
                }
            }

            return leftArray.Count - rightArray.Count;
        }

        public static void Part1(String[] lines)
        {
            Console.WriteLine("Commencing Day 13, Part 1...");

            var orderedIndexSum = 0;

            for (var i = 0; i < lines.Length; i += 3)
            {
                var left = JsonNode.Parse(lines[i]);
                var right = JsonNode.Parse(lines[i + 1]);

                var isOrdered = Compare(left!, right!);

                if (isOrdered < 0)
                {
                    orderedIndexSum += (i / 3) + 1;
                }
            }

            Console.WriteLine("Answer: " + orderedIndexSum);
        }

        public static void Part2(String[] lines)
        {
            Console.WriteLine("Commencing Day 13, Part 2...");

            var input = new List<string>() { "[[2]]", "[[6]]" };

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Length != 0)
                {
                    input.Add(lines[i]);
                }
            }

            var nodeList = input.ConvertAll(i => JsonNode.Parse(i));
            nodeList.Sort(Compare!);    //sort the list using the compare() function

            int key1 = -1;
            int key2 = -1;

            for (int i = 0; i < nodeList.Count; i++)
            {
                if (nodeList[i]!.ToJsonString() == "[[2]]")
                {
                    key1 = i + 1;
                }
                else if (nodeList[i]!.ToJsonString() == "[[6]]")
                {
                    key2 = i + 1;
                    break;
                }
            }

            Console.WriteLine("Answer: " + (key1 * key2));
        }
    }
}
