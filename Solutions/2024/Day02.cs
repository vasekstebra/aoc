namespace Solutions2024;

public class Day02
{
    public int SolvePart01(string[] lines)
    {
        return ParseData(lines).Where(l => IsSafe(l)).Count();
    }

    public int SolvePart02(string[] lines)
    {
        return ParseData(lines).Where(x => IsSafe(x, true)).Count();
    }

    private IEnumerable<List<int>> ParseData(string[] lines)
    {
        return lines.Select(l => l.Split(" ").Select(int.Parse).ToList());
    }

    private bool IsSafe(List<int> parsed, bool tolerance = false)
    {
        int currentOrdering = GetOrdering(parsed[0], parsed[1]);
        for (int i = 0; i < parsed.Count - 1; i++)
        {
            int x = parsed[i];
            int y = parsed[i + 1];
            if (ChangedOrdering(x, y, currentOrdering) || DiffOutOfRange(x, y))
            {
                if (!tolerance)
                {
                    return false;
                }
                else
                {
                    return IsSafeWithoutElement(parsed, i);
                }
            }
        }
        return true;
    }

    private int GetOrdering(int first, int second)
    {
        if (first > second)
        {
            return 1;
        }
        else if (first == second)
        {
            return 0;
        }
        return -1;
    }

    private bool ChangedOrdering(int first, int second, int currentOrdering)
    {
        return currentOrdering != GetOrdering(first, second);
    }

    private bool DiffOutOfRange(int first, int second)
    {
        int diff = Math.Abs(first - second);
        return diff < 1 || diff > 3;
    }

    private bool IsSafeWithoutElement(List<int> parsed, int i)
    {
        var x = parsed.Where((_, j) => j != i - 1).ToList();
        var y = parsed.Where((_, j) => j != i).ToList();
        var z = parsed.Where((_, j) => j != i + 1).ToList();
        return IsSafe(x) || IsSafe(y) || IsSafe(z);
    }

}
