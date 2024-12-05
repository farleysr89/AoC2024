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
                    if (!rules.Any(r => r.Item1 == pages[j] && r.Item2 == pages[i])) continue;
                    good = false;
                    break;
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
        var rules = new List<(int, int)>();
        var puzzle = _input.Split('\n');
        var badUpdates = new List<int[]>();
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
                    if (!rules.Any(r => r.Item1 == pages[j] && r.Item2 == pages[i])) continue;
                    badUpdates.Add(pages);
                    good = false;
                    break;
                }

                if (!good) break;
            }
        }

        var fixedUpdates = badUpdates.Sum(badUpdate => Reorder(rules, badUpdate));
        return new ValueTask<string>($"Solution to {ClassPrefix} {CalculateIndex()}, part 2 is " + fixedUpdates);
    }

    private static int Reorder(List<(int, int)> rules, int[] report)
    {
        while (true)
        {
            var change = false;
            for (var i = 0; i < report.Length - 1; i++)
            {
                for (var j = i + 1; j < report.Length; j++)
                {
                    var rule = rules.FirstOrDefault(r => r.Item1 == report[j] && r.Item2 == report[i]);
                    if (rule == default) continue;
                    change = true;
                    report[i] = rule.Item1;
                    report[j] = rule.Item2;
                    break;
                }
                if(change) break;
            }
            if(!change) break;
        }

        return report[report.Length / 2];
    }

}
