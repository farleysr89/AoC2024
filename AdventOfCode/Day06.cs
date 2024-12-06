namespace AdventOfCode;

public sealed class Day06 : BaseDay
{
    private readonly string _input;

    public Day06()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        var loc = (0,0);
        var dir = ' ';
        var map = _input.Split('\n');
        var path = new bool[map.Length][];
        for (var i = 0; i < path.Length; i++)
        {
            path[i] = new bool[map[0].Length];
        }
        var x = 0;
        foreach (var line in map)
        {
            var y = 0;
            foreach(var c in line)
            {
                if(c is '^' or '<' or '>' or 'v')
                {
                    loc = (x, y);
                    dir = c;
                    break;
                }

                y++;
            }

            if (dir != ' ') break;
            x++;
        }

        while (loc.Item1 >= 0 && loc.Item1 < map.Length && loc.Item2 >= 0 && loc.Item2 < map[0].Length)
        {
            path[loc.Item1][loc.Item2] = true;
            switch (dir)
            {
                case '^':
                    if (loc.Item1 - 1 < 0)
                    {
                        loc.Item1--;
                        continue;
                    }
                    if (map[loc.Item1 - 1][loc.Item2] == '#')
                    {
                        dir = '>';
                        continue;
                    }

                    loc.Item1--;
                    break;
                case '<':
                    if (loc.Item2 - 1 < 0)
                    {
                        loc.Item2--;
                        continue;
                    }
                    if (map[loc.Item1][loc.Item2 - 1] == '#')
                    {
                        dir = '^';
                        continue;
                    }

                    loc.Item2--;
                    break;
                case '>':
                    if (loc.Item2 + 1 == map[0].Length)
                    {
                        loc.Item2++;
                        continue;
                    }
                    if (map[loc.Item1][loc.Item2 + 1] == '#')
                    {
                        dir = 'v';
                        continue;
                    }

                    loc.Item2++;
                    break;
                case 'v':
                    if (loc.Item1 + 1 == map.Length)
                    {
                        loc.Item1++;
                        continue;
                    }
                    if (map[loc.Item1 + 1][loc.Item2] == '#')
                    {
                        dir = '<';
                        continue;
                    }

                    loc.Item1++;
                    break;
                default:
                    throw new Exception("Invalid direction:" + dir);
            }
        }

        return new ValueTask<string>($"Solution to {ClassPrefix} {CalculateIndex()}, part 1 is " + path.Sum(l => l.Count(c => c)));
    }

    public override ValueTask<string> Solve_2()
    {
        var loc = (0,0);
        var dir = ' ';
        var map = _input.Split('\n');
        var path = new bool[map.Length][];
        for (var i = 0; i < path.Length; i++)
        {
            path[i] = new bool[map[0].Length];
        }
        var x = 0;
        foreach (var line in map)
        {
            var y = 0;
            foreach(var c in line)
            {
                if(c is '^' or '<' or '>' or 'v')
                {
                    loc = (x, y);
                    dir = c;
                    break;
                }

                y++;
            }

            if (dir != ' ') break;
            x++;
        }
        return new ValueTask<string>($"Solution to {ClassPrefix} {CalculateIndex()}, part 2 is " + 0);
    }

}
