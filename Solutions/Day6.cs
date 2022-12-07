using AdventOfCode.Base;

namespace AdventOfCode.Solutions
{
    [Solution(6)]
    internal class Day6 : ISolution
    {
        string ISolution.Part1()
        {
            int offset = 0, i = 0;
            var sr = new StreamReader("Input/Day6.txt");
            char[] chars = new char[4];
            while (sr.Peek() != -1)
            {
                chars[offset] = (char)sr.Read();
                offset = (offset + 1) % 4;
                i++;
                if (chars.Distinct().Count() == 4 && i >= 4)
                {
                    return i.ToString();
                }
            }
            return "NO SOLUTION FOUND";
        }

        string ISolution.Part2()
        {
            int offset = 0, i = 0;
            var sr = new StreamReader("Input/Day6.txt");
            char[] chars = new char[14];
            while (sr.Peek() != -1)
            {
                chars[offset] = (char)sr.Read();
                offset = (offset + 1) % 14;
                i++;
                if (chars.Distinct().Count() == 14 && i >= 14)
                {
                    return i.ToString();
                }
            }

            return "NO SOLUTION FOUND";
        }
    }
}