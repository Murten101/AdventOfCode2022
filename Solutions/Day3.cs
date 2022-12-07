using AdventOfCode.Base;

namespace AdventOfCode.Solutions
{
    [Solution(3)]
    internal class Day3 : ISolution
    {
        string ISolution.Part1()
        {
            int total = 0;
            foreach (string line in File.ReadLines("Input/Day3.txt"))
            {
                var first = line.Substring(0, (int)(line.Length / 2));
                var last = line.Substring((int)(line.Length / 2), (int)(line.Length / 2));
                int largest = 0;
                foreach (var item in first)
                {
                    if (last.Contains(item))
                    {
                        var value = item > 90 ? item - 'a' + 1 : item - 'A' + 27;
                        if (value > largest)
                        {
                            largest = value;
                        }
                    }
                }
                total += largest;
            }
            return total.ToString();
        }

        string ISolution.Part2()
        {
            int total = 0;
            int count = 0;
            string[] bags = new string[3];
            foreach (string line in File.ReadLines("Input/Day3.txt"))
            {
                if (count == 2)
                {
                    bags[count] = line;
                    int largest = 0;
                    foreach (var item in bags[0])
                    {
                        if (bags[1].Contains(item) && bags[2].Contains(item))
                        {
                            var value = item > 90 ? item - 'a' + 1 : item - 'A' + 27;
                            if (value > largest)
                            {
                                largest = value;
                            }
                        }
                    }
                    total += largest;
                    bags = new string[3];
                    count = 0;
                }
                else
                {
                    bags[count] = line;
                    count++;
                }

            }
            return total.ToString();
        }
    }
}
