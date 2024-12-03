namespace AdventOfCode;

public sealed class Day03 : BaseDay
{
    private readonly string _input;

    public Day03()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        var results = 0;
        var indices = GetIndices(_input);

        foreach (var index in indices)
        {
            var firstFound = false;
            var firstNum = "";
            var secondNum = "";
            var currIndex = index + 4;
            while (true)
            {
                if (int.TryParse(_input[currIndex].ToString(),out var currNum))
                {
                    if (!firstFound) firstNum += _input[currIndex];
                    else secondNum += _input[currIndex];
                }
                else if (_input[currIndex] == ',')
                {
                    if (firstNum == "") break;
                    if (!firstFound) firstFound = true;
                    else break;
                }
                else if (_input[currIndex] == ')')
                {
                    if (firstNum != "" && secondNum != "") results += int.Parse(firstNum) * int.Parse(secondNum);
                    break;
                }
                else break;

                currIndex++;
            }
        }
        return new ValueTask<string>($"Solution to {ClassPrefix} {CalculateIndex()}, part 1 is " + results);
    }

    public override ValueTask<string> Solve_2()
    {
        var results = 0;
        var indices = GetIndices(_input);
        var doIndices = GetDoIndices(_input);
        var dontIndices = GetDontIndices(_input);

        foreach (var index in indices)
        {
            if (!dontIndices.Any(i => i < index) ||
                (dontIndices.LastOrDefault(i => i < index) < doIndices.LastOrDefault(i => i < index)))
            {
            }
            else continue;

            var firstFound = false;
            var firstNum = "";
            var secondNum = "";
            var currIndex = index + 4;
            while (true)
            {
                if (int.TryParse(_input[currIndex].ToString(),out var currNum))
                {
                    if (!firstFound) firstNum += _input[currIndex];
                    else secondNum += _input[currIndex];
                }
                else if (_input[currIndex] == ',')
                {
                    if (firstNum == "") break;
                    if (!firstFound) firstFound = true;
                    else break;
                }
                else if (_input[currIndex] == ')')
                {
                    if (firstNum != "" && secondNum != "") results += int.Parse(firstNum) * int.Parse(secondNum);
                    break;
                }
                else break;

                currIndex++;
            }
        }
        return new ValueTask<string>($"Solution to {ClassPrefix} {CalculateIndex()}, part 2 is " + results);
    }

    private static List<int> GetIndices(string input)
    {
        var indices = new List<int>();
        for (var i = 0; i < input.Length - 8; i++)
        {
            if(input.IndexOf("mul(",i, StringComparison.Ordinal) == i) indices.Add(i);
        }

        return indices;
    }
    private static List<int> GetDoIndices(string input)
    {
        var indices = new List<int>();
        for (var i = 0; i < input.Length - 3; i++)
        {
            if(input.IndexOf("do()",i, StringComparison.Ordinal) == i) indices.Add(i);
        }

        return indices;
    }
    private static List<int> GetDontIndices(string input)
    {
        var indices = new List<int>();
        for (var i = 0; i < input.Length - 6; i++)
        {
            if(input.IndexOf("don't()",i, StringComparison.Ordinal) == i) indices.Add(i);
        }

        return indices;
    }
}
