namespace AdventOfCode;

public sealed class Day08 : BaseDay
{
    private readonly string _input;

    public Day08()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        var lines = _input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
        var antennas = new Dictionary<char, List<(int,int)>>();
        var x = 0;
        foreach (var line in lines)
        {
            var y = -1;
            foreach (var ch in line)
            {
                y++;
                if(ch == '.') continue;
                if(!antennas.TryGetValue(ch, out var value)) antennas.Add(ch, [(x, y)]);
                else
                    value.Add((x, y));
            }

            x++;
        }

        var antinodes = new bool[lines.Length][];
        for (var i = 0; i < antinodes.Length; i++)
        {
            antinodes[i] = new bool[lines[i].Length];
        }
        foreach (var a in antennas)
        {
            for (var i = 0; i < a.Value.Count - 1; i++)
            {
                for (var j = i + 1; j < a.Value.Count; j++)
                {
                    var xSlope = a.Value[i].Item1 - a.Value[j].Item1;
                    var ySlope = a.Value[i].Item2 - a.Value[j].Item2;
                    var x1 = a.Value[i].Item1 + xSlope;
                    var y1 = a.Value[i].Item2 + ySlope;
                    var x2 = a.Value[j].Item1 - xSlope;
                    var y2 = a.Value[j].Item2 - ySlope;
                    if(x1 >= 0 && x1 < antinodes.Length && y1 >= 0 && y1 < antinodes[0].Length) 
                        antinodes[a.Value[i].Item1 + xSlope][a.Value[i].Item2 + ySlope] = true;
                    if(x2 >= 0 && x2 < antinodes.Length && y2 >= 0 && y2 < antinodes[0].Length)
                        antinodes[a.Value[j].Item1 - xSlope][a.Value[j].Item2 - ySlope] = true;
                }
            }
        }

        return new ValueTask<string>($"Solution to {ClassPrefix} {CalculateIndex()}, part 1 is " + antinodes.Sum(x => x.Count(b => b)));
    }

    public override ValueTask<string> Solve_2()
    {
        var lines = _input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
        var antennas = new Dictionary<char, List<(int,int)>>();
        var x = 0;
        foreach (var line in lines)
        {
            var y = -1;
            foreach (var ch in line)
            {
                y++;
                if(ch == '.') continue;
                if(!antennas.TryGetValue(ch, out var value)) antennas.Add(ch, [(x, y)]);
                else
                    value.Add((x, y));
            }

            x++;
        }

        var antinodes = new bool[lines.Length][];
        for (var i = 0; i < antinodes.Length; i++)
        {
            antinodes[i] = new bool[lines[i].Length];
        }
        foreach (var a in antennas)
        {
            for (var i = 0; i < a.Value.Count - 1; i++)
            {
                for (var j = i + 1; j < a.Value.Count; j++)
                {
                    antinodes[a.Value[i].Item1][a.Value[i].Item2] = true;
                    antinodes[a.Value[j].Item1][a.Value[j].Item2] = true;
                    var xSlope = a.Value[i].Item1 - a.Value[j].Item1;
                    var ySlope = a.Value[i].Item2 - a.Value[j].Item2;
                    var x1 = a.Value[i].Item1;
                    var y1 = a.Value[i].Item2;
                    while (true)
                    {
                        x1 += xSlope;
                        y1 += ySlope;

                        if (x1 >= 0 && x1 < antinodes.Length && y1 >= 0 && y1 < antinodes[0].Length)
                            antinodes[x1][y1] = true;
                        else break;
                    }

                    x1 = a.Value[i].Item1;
                    y1 = a.Value[i].Item2;
                    while (true)
                    {
                        x1 -= xSlope;
                        y1 -= ySlope;
                        if (x1 >= 0 && x1 < antinodes.Length && y1 >= 0 && y1 < antinodes[0].Length)
                            antinodes[x1][y1] = true;
                        else break;
                    }

                }
            }
        }

        return new ValueTask<string>($"Solution to {ClassPrefix} {CalculateIndex()}, part 2 is " + antinodes.Sum(x => x.Count(b => b)));
    }

}
