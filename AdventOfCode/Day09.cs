namespace AdventOfCode;

public sealed class Day09 : BaseDay
{
    private readonly string _input;

    public Day09()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        return new ValueTask<string>($"Solution to {ClassPrefix} {CalculateIndex()}, part 1 is " + 0);
    }

    public override ValueTask<string> Solve_2()
    {
        return new ValueTask<string>($"Solution to {ClassPrefix} {CalculateIndex()}, part 2 is " + 0);
    }

}
