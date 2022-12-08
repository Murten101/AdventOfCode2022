using AdventOfCode.Base;

namespace AdventOfCode.Solutions
{
    [Solution(8)]
    internal class Day8 : ISolution
    {
        const int WIDHT = 99, HEIGHT = 99;

        private int[,] GetTrees()
        {
            int[,] trees = new int[WIDHT, HEIGHT];
            var lines = File.ReadAllLines("Input/Day8.txt");
            for (int x = 0; x < HEIGHT; x++)
            {
                for (int y = 0; y < WIDHT; y++)
                {
                    trees[x, y] = int.Parse(lines[x][y].ToString());
                }
            }
            return trees;
        }
        private bool checkVisible(int x, int y, int[,] trees)
        {
            if (x == 0 || x == WIDHT - 1 || y == 0 || y == HEIGHT - 1) return true;
            int value = trees[x, y];
            //Up
            for (int i = 0; i < x; i++)
            {
                if (trees[i, y] >= value)
                {
                    break;
                }
                else if (i == x - 1)
                    return true;
            }
            //Down
            for (int i = HEIGHT - 1; i > x; i--)
            {
                if (trees[i, y] >= value)
                {
                    break;
                }
                else if (i == x + 1)
                    return true;
            }
            //Left
            for (int i = 0; i < y; i++)
            {
                if (trees[x, i] >= value)
                {
                    break;
                }
                else if (i == y - 1)
                    return true;
            }
            //Right
            for (int i = WIDHT - 1; i > y; i--)
            {
                if (trees[x, i] >= value)
                {
                    break;
                }
                else if (i == y + 1)
                    return true;
            }
            Console.WriteLine(x.ToString() + " " + y.ToString() + " : " + value.ToString());
            return false;
        }

        private int GetSceneScore(int x, int y, int[,] trees)
        {

            if (x == 0 || x == WIDHT - 1 || y == 0 || y == HEIGHT - 1) return 0;
            int Totalscore = 1;
            int value = trees[x, y];
            int currentScore = -1;
            //Up
            for (int i = 0; i < x; i++)
            {
                if (trees[i, y] >= value)
                {
                    currentScore = x - i;
                }
                if (i == x - 1)
                {
                    Totalscore *= currentScore == -1 ? x : currentScore;
                    currentScore = -1;
                    break;
                }
                    
            }
            
            //Down
            for (int i = HEIGHT - 1; i > x; i--)
            {
                if (trees[i, y] >= value)
                {
                    currentScore = i - x;
                }
                if (i == x + 1)
                {
                    Totalscore *= currentScore == -1 ? HEIGHT - x - 1: currentScore;
                    currentScore = -1;
                    break;
                }
            }
            //Left
            for (int i = 0; i < y; i++)
            {
                if (trees[x, i] >= value)
                {
                    currentScore = y - i;
                }
                if (i == y - 1)
                {
                    Totalscore *= currentScore == -1 ? y : currentScore;
                    currentScore = -1;
                    break;
                }
            }
            //Right
            for (int i = WIDHT - 1; i > y; i--)
            {
                if (trees[x, i] >= value)
                {
                    currentScore = i - y;
                }
                if (i == y + 1)
                {
                    Totalscore *= currentScore == -1 ? WIDHT - y - 1: currentScore;
                    currentScore = -1;
                    break;
                }
            }
            return Totalscore;
        }
        string ISolution.Part1()
        {
            int total = 0;
            var trees = GetTrees();
            for (int x = 0; x < HEIGHT; x++)
            {
                for (int y = 0; y < WIDHT; y++)
                {
                    if (checkVisible(x, y, trees))
                        total++;
                }
            }
            return total.ToString();
        }

        string ISolution.Part2()
        {
            int heighest = 0;
            var trees = GetTrees();
            for (int x = 0; x < HEIGHT; x++)
            {
                for (int y = 0; y < WIDHT; y++)
                {
                    int score = GetSceneScore(x, y, trees);
                    if (score > heighest)
                        heighest = score;
                }
            }
            return heighest.ToString();
        }
    }
}
