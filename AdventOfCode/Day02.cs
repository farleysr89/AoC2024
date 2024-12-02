namespace AdventOfCode;

public class Day02 : BaseDay
{
    private readonly string _input;
    private List<string> _lines = [];

    public Day02()
    {
        _input = File.ReadAllText(InputFilePath);
        _lines = new List<string>(_input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries));
        // foreach (var l in lines)
        // {
        //     var entries = l.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToArray();
        //     _list1.Add(entries[0]);
        //     _list2.Add(entries[1]);
        // }
    }

    public override ValueTask<string> Solve_1()
    {
        var safeReports = 0;
        foreach (var line in _lines)
        {
            var safe = true;
            var splitted = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            var x = -1;
            var sign = false;
            var start = false;
            foreach (var i in splitted)
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

            if (safe) safeReports++;
        }
        return new($"Solution to {ClassPrefix} {CalculateIndex()}, part 1 is " + safeReports);
    }

    public override ValueTask<string> Solve_2()
    {
        var simScore = 0;

        return new($"Solution to {ClassPrefix} {CalculateIndex()}, part 2 is " + simScore);
    }
}
