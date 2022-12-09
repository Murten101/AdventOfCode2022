using AdventOfCode.Base;
using System;

namespace AdventOfCode.Solutions
{
    [Solution(1)]
    internal class Day1 : ISolution
    {
        string ISolution.Part1() => File.ReadAllText("Input/Day1.txt").Split("\r\n\r\n").OrderBy((s) => s.Split("\r\n").Sum((num) => -int.Parse(num))).ToList()[0].Split("\r\n").Sum((num) => int.Parse(num)).ToString();

        string ISolution.Part2() => File.ReadAllText("Input/Day1.txt").Split("\r\n\r\n").OrderBy((s) => s.Split("\r\n").Sum((num) => -int.Parse(num))).ToList().Take(3).Sum((s) => s.Split("\r\n").Sum((num) => int.Parse(num))).ToString();
    }
}