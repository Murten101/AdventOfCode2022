using AdventOfCode.Base;

namespace AdventOfCode.Solutions
{
    [Solution(7)]
    internal class Day7 : ISolution
    {
        class Dir {
            public Dir parent = null;
            public List<Dir> Dirs;
            public int value;
            public string name;
            public Dir(Dir parent, string name = "", int value = 0) {
                Dirs = new List<Dir>();
                this.parent = parent;
                this.value = value;
                this.name = name;
            }
            public int GetValue() {
                int total = 0;
                Dirs.ForEach((d) => { total += d.GetValue(); });
                return total + value;
            }
        }
        int freeSpace = 0;
        int total = int.MaxValue;
        private void DoThingPart1(Dir dir)
        {
            int value = dir.GetValue();
            total += value <= 100000 ? value : 0;
            foreach(Dir d in dir.Dirs)
            {
                if (d.name != "")
                    DoThingPart1(d);
            }
        }
        private void DoThingPart2(Dir dir)
        {
            int value = dir.GetValue();
            if (freeSpace + value >= 30000000 && value < total)
            {
                total = value;
            }
            foreach (Dir d in dir.Dirs)
            {
                if (d.name != "")
                    DoThingPart2(d);
            }
        }
        string ISolution.Part1(){
            Dir root = new Dir(null);
            Dir current = root;
            foreach (string line in File.ReadLines("Input/Day7.txt")){
                switch (line[0])
                {
                    case '$':
                        if (line[2] != 'c') continue;
                        if (line[5] == '/'){
                            current = root;
                            continue;
                        }
                        if (line[5] == '.')
                        {
                            current = current.parent;
                            continue;
                        }
                        current = current.Dirs.Where((dir) => { return line.Split(' ').Last() == dir.name; }).First();
                        break;
                    case 'd':
                        current.Dirs.Add(new Dir(current, line.Split(' ').Last()));
                        break;
                    default:
                        current.Dirs.Add(new Dir(current, "", int.Parse(line.Split(' ').First())));
                        break;
                }     
            }
            DoThingPart1(root);
            return total.ToString();
        }

        string ISolution.Part2()
        {
            Dir root = new Dir(null);
            Dir current = root;
            foreach (string line in File.ReadLines("Input/Day7.txt"))
            {
                switch (line[0])
                {
                    case '$':
                        if (line[2] != 'c') continue;
                        if (line[5] == '/')
                        {
                            current = root;
                            continue;
                        }
                        if (line[5] == '.')
                        {
                            current = current.parent;
                            continue;
                        }
                        current = current.Dirs.Where((dir) => { return line.Split(' ').Last() == dir.name; }).First();
                        break;
                    case 'd':
                        current.Dirs.Add(new Dir(current, line.Split(' ').Last()));
                        break;
                    default:
                        current.Dirs.Add(new Dir(current, "", int.Parse(line.Split(' ').First())));
                        break;
                }
            }
            freeSpace = 70000000 - root.GetValue();
            DoThingPart2(root);
            return total.ToString();
        }
    }
}
