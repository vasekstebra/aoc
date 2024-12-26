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
        int order = Ordering(parsed[0], parsed[1]);
        for (int i = 0; i < parsed.Count - 1; i++)
        {
            int diff = Math.Abs(parsed[i] - parsed[i + 1]);
            if (Ordering(parsed[i], parsed[i + 1]) != order)
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
            if (diff < 1 || diff > 3)
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

    private int Ordering(int first, int second)
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
    private bool IsSafeWithoutElement(List<int> parsed, int i)
    {
        var x = parsed.Where((_, j) => j != i - 1).ToList();
        var y = parsed.Where((_, j) => j != i).ToList();
        var z = parsed.Where((_, j) => j != i + 1).ToList();
        return IsSafe(x) || IsSafe(y) || IsSafe(z);
    }

}
