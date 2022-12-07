using AdventOfCode.Base;

namespace AdventOfCode.Solutions
{
    [Solution(4)]
    internal class Day4 : ISolution
    {
        string ISolution.Part1()
        {
            int total = 0;
            foreach (string line in File.ReadLines("Input/Day4.txt"))
            {
                string[] a = line.Split(',')[0].Split('-'), b = line.Split(',')[1].Split('-');
                if ((int.Parse(a[0]) >= int.Parse(b[0]) && int.Parse(a[1]) <= int.Parse(b[1]) || int.Parse(b[0]) >= int.Parse(a[0]) && int.Parse(b[1]) <= int.Parse(a[1])))
                    total++;
            }
            return total.ToString();
        }

        string ISolution.Part2()
        {
            int total = 0;
            foreach (string line in File.ReadLines("Input/Day4.txt"))
            {
                string[] a = line.Split(',')[0].Split('-'), b = line.Split(',')[1].Split('-');
                if ((int.Parse(a[0]) >= int.Parse(b[0]) && (int.Parse(a[0]) <= int.Parse(b[1])) || (int.Parse(a[1]) <= int.Parse(b[1]) && (int.Parse(a[1]) >= int.Parse(b[0])) || (int.Parse(b[0]) >= int.Parse(a[0]) && (int.Parse(b[0]) <= int.Parse(a[1])) || (int.Parse(b[1]) <= int.Parse(a[1]) && (int.Parse(b[1]) >= int.Parse(a[0])))))))
                    total++;
            }
            return total.ToString();
        }
    }
}
