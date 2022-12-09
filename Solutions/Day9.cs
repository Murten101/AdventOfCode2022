using AdventOfCode.Base;
using System.Numerics;

namespace AdventOfCode.Solutions
{
    [Solution(9)]
    internal class Day9 : ISolution
    {
        readonly Dictionary<Vector2, int> visited = new();
        private static void MoveSnek(ref Vector2 snek, Vector2 snekLead)
        {
            var dif = snek - snekLead;
            if (Math.Abs(dif.X) == 2 && snek.Y != snekLead.Y)
            {
                snek -= new Vector2(0, Math.Clamp(dif.Y, -1, 1));
                dif = snek - snekLead;
            }
            if(Math.Abs(dif.Y) == 2 && snek.X != snekLead.X)
            {
                snek -= new Vector2(Math.Clamp(dif.X, -1, 1), 0);
                dif = snek - snekLead;
            }

            var clampedDif = new Vector2(Math.Clamp(dif.X, -1, 1), Math.Clamp(dif.Y, -1, 1));
            snek -= dif - clampedDif;
        }
        private static void MoveSnekHead(ref Vector2 head, char dir)
        {
            head += dir switch
            {
                'D' => new Vector2(0, -1),
                'U' => new Vector2(0,  1),
                'L' => new Vector2(-1, 0),
                'R' => new Vector2(1, 0),
                _ => throw new Exception("Shit is fucked")
            };
        }
        string ISolution.Part1()
        {
            Vector2[] snek = new Vector2[2];
            snek.Initialize();
            visited.Add(snek[1], 0);
            foreach (string line in File.ReadLines("Input/Day9.txt"))
            {
                for (int c = 0; c < int.Parse(line.Split(' ').Last()); c++)
                {
                    MoveSnekHead(ref snek[0], line[0]);
                    for (int i = 1; i < snek.Length; i++)
                    {
                        MoveSnek(ref snek[i], snek[i - 1]);
                    }
                    visited.TryAdd(snek[1], 0);
                }
            }
            
            return visited.Count.ToString();
        }

        string ISolution.Part2()
        {
            Vector2[] snek = new Vector2[10];
            for (int i = 0; i < 10; i++)
            {
                snek[i] = new Vector2(16, 12);
            }
            visited.Add(snek[1], 0);
            foreach (string line in File.ReadLines("Input/Day9.txt"))
            {
                for (int c = 0; c < int.Parse(line.Split(' ').Last()); c++)
                {
                    MoveSnekHead(ref snek[0], line[0]);
                    for (int i = 1; i < snek.Length; i++)
                    {
                        MoveSnek(ref snek[i], snek[i - 1]);
                    }
                    visited.TryAdd(snek[9], 0);
                }
            }

            return visited.Count.ToString();
        }
    }
}
