namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly List<int> _list1 = [];
    private readonly List<int> _list2 = [];

    public Day01()
    {
        var input = File.ReadAllText(InputFilePath);
        var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        foreach (var l in lines)
        {
            var entries = l.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToArray();
            _list1.Add(entries[0]);
            _list2.Add(entries[1]);
        }
    }

    public override ValueTask<string> Solve_1()
    { 
        var sortedList1 = _list1.OrderBy(x => x).ToList();
        var sortedList2 = _list2.OrderBy(x => x).ToList();
        if(sortedList1.Count != sortedList2.Count) throw new Exception("Something Broke!");
        var totalDiff = sortedList1.Select((t, i) => Math.Abs(t - sortedList2[i])).Sum();
        return new ValueTask<string>($"Solution to {ClassPrefix} {CalculateIndex()}, part 1 is " + totalDiff);
    }

    public override ValueTask<string> Solve_2()
    {
        var simScore = (from i in _list1 let count = _list2.Count(x => x == i) select i * count).Sum();
        return new ValueTask<string>($"Solution to {ClassPrefix} {CalculateIndex()}, part 2 is " + simScore);
    }
}
