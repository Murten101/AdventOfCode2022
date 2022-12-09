using AdventOfCode.Base;
using System.Numerics;
namespace AdventOfCode.Solutions
{
    [Solution(9)]
    internal class Day9 : ISolution
    {
        string ISolution.Part1()
        {
            Dictionary<Vector2, int> visited = new Dictionary<Vector2, int>();
            Vector2[] snek = new Vector2[2];
            for (int i = 0; i < snek.Length; i ++)
                snek[i] = new Vector2(0, 0);

            return snek.ToString();
        }

        string ISolution.Part2()
        {
            throw new NotImplementedException();
        }
    }
}
