namespace AdventOfCode;

public sealed class Day06 : BaseDay
{
    private readonly string _input;
    private bool[][] _path;
    private List<(int,int)> _steps = [];

    public Day06()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        var loc = (0,0);
        var dir = ' ';
        var map = _input.Split('\n');
        _path = new bool[map.Length][];
        for (var i = 0; i < _path.Length; i++)
        {
            _path[i] = new bool[map[0].Length];
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
            _path[loc.Item1][loc.Item2] = true;
            if(!_steps.Contains((loc.Item1,loc.Item2))) _steps.Add((loc.Item1, loc.Item2));
            
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

        return new ValueTask<string>($"Solution to {ClassPrefix} {CalculateIndex()}, part 1 is " + _path.Sum(l => l.Count(c => c)));
    }

    public override ValueTask<string> Solve_2()
    {
        var loc = (0,0);
        var dir = ' ';
        var map = _input.Split('\n');
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

        var loops = _steps.Where(l => l.Item1 != loc.Item1 || l.Item2 != loc.Item2).Count(s => LoopTest(s, loc, map, dir));

        return new ValueTask<string>($"Solution to {ClassPrefix} {CalculateIndex()}, part 2 is " + loops);
    }

    private bool LoopTest((int,int) obstacle,(int,int) start, string[] map, char dir)
    {
        var loc = start;
        var stepDirs = new string[map.Length][];
        for (var i = 0; i < stepDirs.Length; i++)
        {
            stepDirs[i] = new string[map[0].Length];
            for (var j = 0; j < stepDirs[i].Length; j++)
            {
                stepDirs[i][j] = "";
            }
        }
        while (loc.Item1 >= 0 && loc.Item1 < map.Length && loc.Item2 >= 0 && loc.Item2 < map[0].Length)
        {
            _path[loc.Item1][loc.Item2] = true;
            if (stepDirs[loc.Item1][loc.Item2].Contains(dir)) return true;
            stepDirs[loc.Item1][loc.Item2] += dir;
            
            switch (dir)
            {
                case '^':
                    if (loc.Item1 - 1 < 0)
                    {
                        loc.Item1--;
                        continue;
                    }
                    if (map[loc.Item1 - 1][loc.Item2] == '#' || (loc.Item1 - 1 == obstacle.Item1 && loc.Item2 == obstacle.Item2))
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
                    if (map[loc.Item1][loc.Item2 - 1] == '#' || (loc.Item1 == obstacle.Item1 && loc.Item2 - 1 == obstacle.Item2))
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
                    if (map[loc.Item1][loc.Item2 + 1] == '#' || (loc.Item1 == obstacle.Item1 && loc.Item2 + 1 == obstacle.Item2))
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
                    if (map[loc.Item1 + 1][loc.Item2] == '#' || (loc.Item1 + 1 == obstacle.Item1 && loc.Item2 == obstacle.Item2))
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
        return false;
    }

}
