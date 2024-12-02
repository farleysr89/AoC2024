namespace AdventOfCode;

public sealed class Day02 : BaseDay
{
    private readonly List<string> _lines;

    public Day02()
    {
        var input = File.ReadAllText(InputFilePath);
        _lines = [..input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)];
    }

    public override ValueTask<string> Solve_1()
    {
        var safeReports = _lines.Select(line => line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)).Count(TestSafe);
        return new ValueTask<string>($"Solution to {ClassPrefix} {CalculateIndex()}, part 1 is " + safeReports);
    }

    public override ValueTask<string> Solve_2()
    {
        var safeReports = _lines.Select(line => line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()).Count(splitted => splitted.Where((t, i) => TestSafe(splitted[0..i].Concat(splitted[(i + 1)..]))).Any());
        return new ValueTask<string>($"Solution to {ClassPrefix} {CalculateIndex()}, part 2 is " + safeReports);
    }

    private static bool TestSafe(IEnumerable<int> input)
    {
        var safe = true;
        var x = -1;
        var sign = false;
        var start = false;
        foreach (var i in input)
        {
            if(x == -1)
            {
                x = i;
                continue;
            }

            if (!start)
            {
                sign = x < i;
                start = true;
            }
            if (((x - i < 0) != sign) || !(Math.Abs(i - x) >= 1 && Math.Abs(i - x) <= 3))
            {
                safe = false;
                break;
            }
            x = i;
        }
        return safe;
    }
}
