namespace AdventOfCode;

public sealed class Day05 : BaseDay
{
    private readonly string _input;

    public Day05()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        var count = 0;
        var validUpdates = 0;
        var rules = new List<(int, int)>();
        var puzzle = _input.Split('\n');
        foreach (var line in puzzle)
        {
            count++;
            if (line == "\r") break;
            var rule = line.Split('|');
            rules.Add((int.Parse(rule[0]), int.Parse(rule[1])));
        }

        foreach (var line in puzzle[count..])
        {
            var pages = line.Split(",").Select(int.Parse).ToArray();
            var good = true;
            for (var i = 0; i < pages.Length - 1; i++)
            {
                for (var j = i + 1; j < pages.Length; j++)
                {
                    if (rules.Any(r => r.Item1 == pages[j] && r.Item2 == pages[i]))
                    {
                        good = false;
                        break;
                    }
                }
                if(!good) break;
            }
            if(good) validUpdates+=(pages[(pages.Length / 2)]);
        }

        return new ValueTask<string>($"Solution to {ClassPrefix} {CalculateIndex()}, part 1 is " + validUpdates);
    }

    public override ValueTask<string> Solve_2()
    {
        var count = 0;
        var validUpdates = 0;
        var rules = new List<(int, int)>();
        var puzzle = _input.Split('\n');
        foreach (var line in puzzle)
        {
            count++;
            if (line == "\r") break;
            var rule = line.Split('|');
            rules.Add((int.Parse(rule[0]), int.Parse(rule[1])));
        }

        foreach (var line in puzzle[count..])
        {
            var pages = line.Split(",").Select(int.Parse).ToArray();
            var good = true;
            for (var i = 0; i < pages.Length - 1; i++)
            {
                for (var j = i + 1; j < pages.Length; j++)
                {
                    if (rules.Any(r => r.Item1 == pages[j] && r.Item2 == pages[i]))
                    {
                        good = false;
                        break;
                    }
                }
                if(!good) break;
            }
            if(good) validUpdates+=(pages[(pages.Length / 2)]);
        }

        return new ValueTask<string>($"Solution to {ClassPrefix} {CalculateIndex()}, part 2 is " + validUpdates);
    }

}
