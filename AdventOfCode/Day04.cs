namespace AdventOfCode;

public sealed class Day04 : BaseDay
{
    private readonly string _input;

    public Day04()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        var count = 0;
        var puzzle = _input.Split('\n');
        for (var i = 0; i < puzzle.Length; i++)
        {
            for (var j = 0; j < puzzle[i].Length; j++)
            {
                if (puzzle[i][j] != 'X') continue;
                if (puzzle[i][j..].StartsWith("XMAS")) count++;
                if(j >= 3 && puzzle[i][(j-3)..].StartsWith("SAMX")) count++;
                if (i >= 3)
                {
                    if (puzzle[i-1][j] == 'M' && puzzle[i-2][j] == 'A' && puzzle[i-3][j] == 'S') count++;
                    if (j >= 3 && puzzle[i - 1][j - 1] == 'M' && puzzle[i - 2][j - 2] == 'A' &&
                        puzzle[i - 3][j - 3] == 'S') count++;
                    if (j <= puzzle[i].Length - 3 && puzzle[i - 1][j + 1] == 'M' && puzzle[i - 2][j + 2] == 'A' &&
                        puzzle[i - 3][j + 3] == 'S') count++;
                }
                if (i <= puzzle.Length - 4)
                {
                    if (puzzle[i+1][j] == 'M' && puzzle[i+2][j] == 'A' && puzzle[i+3][j] == 'S') count++;
                    if (j >= 3 && puzzle[i +1][j - 1] == 'M' && puzzle[i + 2][j - 2] == 'A' &&
                        puzzle[i + 3][j - 3] == 'S') count++;
                    if (j <= puzzle[i].Length - 3 && puzzle[i + 1][j + 1] == 'M' && puzzle[i + 2][j + 2] == 'A' &&
                        puzzle[i + 3][j + 3] == 'S') count++;
                }                
            }
        }

        return new ValueTask<string>($"Solution to {ClassPrefix} {CalculateIndex()}, part 1 is " + count);
    }

    public override ValueTask<string> Solve_2()
    {
        var results = 0;
        
        return new ValueTask<string>($"Solution to {ClassPrefix} {CalculateIndex()}, part 2 is " + results);
    }

}
