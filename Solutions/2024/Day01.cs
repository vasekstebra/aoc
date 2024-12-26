namespace Solutions2024;

public class Day01
{
    public int SolvePart01(string[] lines)
    {
        IEnumerable<(int, int)> parsedData = ParseLines(lines);
        var left = parsedData.Select(data => data.Item1).Order().ToList();
        var right = parsedData.Select(data => data.Item2).Order().ToList();
        return left.Select((_, i) => Math.Abs(left[i] - right[i])).Sum();
    }

    public int SolvePart02(string[] lines)
    {
        IEnumerable<(int, int)> parsedData = ParseLines(lines);
        var left = parsedData.Select(data => data.Item1).ToList();
        var right = parsedData.Select(data => data.Item2).ToList();
        return left.Select(x => x * right.Count(y => x == y)).Sum();
    }

    private IEnumerable<(int, int)> ParseLines(string[] lines)
    {
        return lines
            .Select(line =>
            {
                string[] splitted = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                return (int.Parse(splitted[0]), int.Parse(splitted[1]));
            });
    }

}
