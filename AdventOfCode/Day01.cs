namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly string _input;
    private List<int> _list1 = [];
    private List<int> _list2 = [];

    public Day01()
    {
        _input = File.ReadAllText(InputFilePath);
        var lines = _input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
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
        var totalDiff = 0;
        for (var i = 0; i < sortedList1.Count; i++)
        {
            totalDiff += Math.Abs(sortedList1[i] - sortedList2[i]);
        }
        return new($"Solution to {ClassPrefix} {CalculateIndex()}, part 1 is " + totalDiff);
    }

    public override ValueTask<string> Solve_2()
    {
        var simScore = 0;
        foreach (var i in _list1)
        {
            var count = _list2.Count(x => x == i);
            simScore += i * count;
        }
        return new($"Solution to {ClassPrefix} {CalculateIndex()}, part 2 is " + simScore);
    }
}
