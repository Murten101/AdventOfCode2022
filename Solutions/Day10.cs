using AdventOfCode.Base;

namespace AdventOfCode.Solutions
{
    [Solution(10)]
    internal class Day10 : ISolution
    {

        int x = 1;
        int total = 0;
        int i = 0;
        private void Tick()
        {
            if (i % 40 == 0 && i != 0)
            {
                total += i * x;
            }
            ++i;
        }
        private void TickAndDraw()
        {
            if (i % 40 == 0 && i != 0)
            {
                Console.WriteLine();
            }
            if (Math.Abs(x - (i % 40)) <= 1)
            {
                Console.Write('#');
            }
            else
            {
                Console.Write(' ');
            }
            ++i;
        }
        string ISolution.Part1()
        {
            foreach (var line in File.ReadLines("Input/Day10.txt"))
            {
                switch (line[0])
                {
                    case 'a':
                        Tick();
                        Tick();
                        x += int.Parse(line.Split(' ')[1]);
                        break;
                    case 'n':
                        Tick();
                        break;
                }
            }
            return total.ToString();
        }

        string ISolution.Part2()
        {
            foreach (var line in File.ReadLines("Input/Day10.txt"))
            {
                switch (line[0])
                {
                    case 'a':
                        TickAndDraw();
                        TickAndDraw();
                        x += int.Parse(line.Split(' ')[1]);
                        break;
                    case 'n':
                        TickAndDraw();
                        break;
                }
            }
            return "";
        }
    }
}
