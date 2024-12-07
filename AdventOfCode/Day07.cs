namespace AdventOfCode;

public sealed class Day07 : BaseDay
{
    private readonly string _input;

    public Day07()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        var lines = _input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
        long sum = 0;
        foreach (var l in lines)
        {
            var split = l.Split(':');
            var result = long.Parse(split[0]);
            var nums = split[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            long first = -1;
            var results = new List<long>();
            foreach (var num in nums)
            {
                if (first == -1)
                {
                    first = num;
                    results.Add(num);
                    continue;
                }
                var tmpResults = new List<long>();
                foreach (var r in results)
                {
                    tmpResults.Add(r + num);
                    tmpResults.Add(r * num);
                }
                results = tmpResults;
            }

            if (results.Contains(result)) sum+=result;
        }

        return new ValueTask<string>($"Solution to {ClassPrefix} {CalculateIndex()}, part 1 is " + sum);
    }

    public override ValueTask<string> Solve_2()
    {
        var lines = _input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
        long sum = 0;
        foreach (var l in lines)
        {
            var split = l.Split(':');
            var result = long.Parse(split[0]);
            var nums = split[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            long first = -1;
            var results = new List<long>();
            foreach (var num in nums)
            {
                if (first == -1)
                {
                    first = num;
                    results.Add(num);
                    continue;
                }
                var tmpResults = new List<long>();
                foreach (var r in results)
                {
                    if(r + num <= result) tmpResults.Add(r + num);
                    if(r * num <= result) tmpResults.Add(r * num);
                    var tmp = long.Parse(r + num.ToString());
                    if(tmp <= result) tmpResults.Add(tmp);
                }
                results = tmpResults;
            }

            if (results.Contains(result)) sum+=result;
        }
        return new ValueTask<string>($"Solution to {ClassPrefix} {CalculateIndex()}, part 2 is " + sum);
    }

}
