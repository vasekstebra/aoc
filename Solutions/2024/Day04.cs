namespace Solutions2024;

public class Day04
{
    public int SolvePart01(string[] lines)
    {
        var count = 0;
        for (int y = 0; y < lines.Length; y++)
        {
            for (int x = 0; x < lines[0].Length; x++)
            {
                char c = lines[y][x];
                if (c == 'X')
                {
                    (int diffX, int diffY)[] directions = {
                        ( -1, 0 ),
                        ( 1, 0 ),
                        ( 0, 1 ),
                        ( 0, -1 ),
                        ( -1, -1 ),
                        ( 1, -1 ),
                        ( -1, 1 ),
                        ( 1, 1 ),
                    };
                    foreach (var direction in directions)
                    {
                        if (ContainsSubstring(lines, x + direction.diffX, y + direction.diffY, direction, "MAS"))
                        {
                            count++;
                        }
                    }
                }
            }
        }
        return count;
    }

    public int SolvePart02(string[] lines)
    {
        var count = 0;
        for (int y = 0; y < lines.Length - 2; y++)
        {
            for (int x = 0; x < lines[0].Length - 2; x++)
            {
                if (ContainsXMAS(lines, x, y))
                {
                    count++;
                }
            }
        }
        return count;
    }

    private bool ContainsSubstring(string[] lines, int x, int y, (int diffX, int diffY) direction, string text)
    {
        if (text.Length == 0)
        {
            return true;
        }
        if (x < 0 || y < 0 || x >= lines[0].Length || y >= lines.Length)
        {
            return false;
        }
        if (lines[y][x] != text[0])
        {
            return false;
        }
        return ContainsSubstring(lines, x + direction.diffX, y + direction.diffY, direction, text.Substring(1));
    }

    private bool ContainsXMAS(string[] lines, int x, int y)
    {
        if (lines[y + 1][x + 1] != 'A')
        {
            return false;
        }
        char topLeft = lines[y][x];
        char topRight = lines[y][x + 2];
        char bottomLeft = lines[y + 2][x];
        char bottomRight = lines[y + 2][x + 2];

        char[] chars = [topLeft, topRight, bottomLeft, bottomRight];
        if (chars.Count(c => c == 'S') != 2 || chars.Count(c => c == 'M') != 2)
        {
            return false;
        }
        return topLeft != bottomRight;
    }
}
