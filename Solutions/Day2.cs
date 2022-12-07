using AdventOfCode.Base;

namespace AdventOfCode.Solutions
{
    [Solution(2)]
    internal class Day2 : ISolution
    {
        string ISolution.Part1()
        {
            throw new NotImplementedException();
        }

        string ISolution.Part2()
        {
            int total = 0;
            foreach (var line in File.ReadLines("Input/Day2.txt"))
            {
                var (a, b) = (line[0], line[2]);
                char c = b == 'Y' ? a : b == 'X' ? (char)('A' + ((a - 'A' + 2) % 3)) : (char)('A' + ((a - 'A' + 1) % 3));
                total += c - 'A' + 1 + (b - 'X') * 3;
            }
            return total.ToString();
        }
    }
}
