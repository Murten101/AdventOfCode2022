using AdventOfCode;
using AdventOfCode.Base;
using System.Reflection;

Dictionary<int, ISolution> solutions = new();

foreach (var solution in GetSolutions(Assembly.GetExecutingAssembly()))
{
    var day = solution?.GetType().GetCustomAttribute<SolutionAttribute>()?.Day;
    if (day != null && solution != null)
    {
        solutions.Add((int)day, solution);
    }
}

static IEnumerable<ISolution?> GetSolutions(Assembly assembly)
{
    foreach (Type type in assembly.GetTypes())
    {
        if (type.GetCustomAttributes(typeof(SolutionAttribute), true).Length > 0)
        {
            yield return Activator.CreateInstance(type) as ISolution;
        }
    }
}
Console.WriteLine("    ___       __                 __           ____   ______          __   \r\n   /   | ____/ /   _____  ____  / /_   ____  / __/  / ____/___  ____/ /__ \r\n  / /| |/ __  / | / / _ \\/ __ \\/ __/  / __ \\/ /_   / /   / __ \\/ __  / _ \\\r\n / ___ / /_/ /| |/ /  __/ / / / /_   / /_/ / __/  / /___/ /_/ / /_/ /  __/\r\n/_/  |_\\__,_/ |___/\\___/_/ /_/\\__/   \\____/_/     \\____/\\____/\\__,_/\\___/ \r\n                                                                          ");
while (true)
{

    var input = Console.ReadLine()?.ToLower();
    switch (input?[0])
    {
        case 'r':
            RunSolution(input);
            break;
        case 'h':
            Console.WriteLine("Run solution: R <day>-<problem> (example: \"R 2-2\")");
            break;
        default:
            Console.WriteLine("Unknown command. use \"h\" for help");
            break;
    }
}

void RunSolution(string input)
{
    if (int.TryParse(input[2].ToString(), out int day) && int.TryParse(input[4].ToString(), out int problem))
    {
        if (day < 0 || day > solutions.Count)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Argument out of range: day = " + day);
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }
        if (problem == 1)
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(solutions[day].Part1());

            Console.ForegroundColor = ConsoleColor.White;
            return;
        }
        else if (problem == 2)
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(solutions[day].Part2());

            Console.ForegroundColor = ConsoleColor.White;
            return;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Argument out of range: problem = " + problem);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}