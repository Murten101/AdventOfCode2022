using AdventOfCode.Base;
using System.Collections;

namespace AdventOfCode.Solutions
{
    [Solution(5)]
    internal class Day5 : ISolution
    {
        private Stack[] ParseInput(IEnumerable<string> file)
        {
            Stack[] crates = new Stack[9] { new Stack(), new Stack(), new Stack(), new Stack(), new Stack(), new Stack(), new Stack(), new Stack(), new Stack() };
            List<string> map = file.Take(8).ToList();
            for (int i = 7; i >= 0; i--)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (map[i][1 + x * 4] != ' ')
                        crates[x].Push(map[i][1 + x * 4]);
                }
            }
            return crates;
        }
        string ISolution.Part1()
        {
            var file = File.ReadLines("Input/Day5.txt");
            var crates = ParseInput(file);
            foreach (var line in file.Skip(10)){
                List<int> instructions = line.Split(' ').Where((str) => str.All(char.IsDigit)).Select(int.Parse).ToList();
                for (int i = 0; i < instructions[0]; i++){
                    var crate = crates[instructions[1] - 1].Pop();
                    crates[instructions[2] - 1].Push(crate);
                }
            }
            string result = "";
            foreach (Stack stack in crates){
                if (stack.Peek() == null) continue;
                    result += stack.Peek();
            }
            return result;
        }

        string ISolution.Part2()
        {
            var file = File.ReadLines("Input/Day5.txt");
            var crates = ParseInput(file);
            foreach (var line in file.Skip(10)){
                List<int> instructions = line.Split(' ').Where((str) => str.All(char.IsDigit)).Select(int.Parse).ToList();
                object[] poppedCrates = new object[instructions[0]];
                for (int i = 0; i < instructions[0]; i++){
                    poppedCrates[i] = crates[instructions[1] - 1].Pop();
                }
                for (int i = instructions[0] - 1; i >= 0; i--) {
                    crates[instructions[2] - 1].Push(poppedCrates[i]);
                }
            }
            string result = "";
            foreach (Stack stack in crates){
                if (stack.Peek() == null) continue;
                result += stack.Peek();
            }
            return result;
        }
    }
}
