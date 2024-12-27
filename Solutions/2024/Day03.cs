using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Solutions2024;

public class Day03
{
    public int SolvePart01(string[] lines)
    {
        var data = string.Join("", lines);
        var pattern = @"(mul\(\d{1,3},\d{1,3}\))";
        var matches = Regex.Matches(data, pattern);

        return matches.Select(m => ExecuteInstruction(m.Value)).Sum();
    }

    public int SolvePart02(string[] lines)
    {
        var data = string.Join("", lines);
        var pattern = @"(mul\(\d{1,3},\d{1,3}\))";
        var doPattern = @"(do\(\))";
        var dontPattern = @"(don't\(\))";

        var matches = Regex.Matches(data, pattern);
        var doMatches = Regex.Matches(data, doPattern);
        var dontMatches = Regex.Matches(data, dontPattern);

        return matches.Where(m => IsEnabledInstruction(m, doMatches, dontMatches)).Select(m => ExecuteInstruction(m.Value)).Sum();
    }


    private int ExecuteInstruction(string instruction)
    {
        var p = @"mul\((\d{1,3}),(\d{1,3})\)";
        var match = Regex.Match(instruction, p);
        int x = int.Parse(match.Groups[1].Value);
        int y = int.Parse(match.Groups[2].Value);
        return x * y;
    }

    private bool IsEnabledInstruction(Match instruction, IEnumerable<Match> doMatches, IEnumerable<Match> dontMatches)
    {
        var lastDo = LastIndexBefore(instruction.Index, doMatches);
        var lastDont = LastIndexBefore(instruction.Index, dontMatches);
        var x = IsDontBefore(instruction.Index, dontMatches);
        return !IsDontBefore(instruction.Index, dontMatches) || lastDo > lastDont;
    }

    private bool IsDontBefore(int index, IEnumerable<Match> dontMatches)
    {
        return dontMatches.Any(m => m.Index < index);
    }

    private int LastIndexBefore(int index, IEnumerable<Match> matches)
    {
        return matches.Select(m => m.Index).Where(i => i < index).LastOrDefault();
    }

    private int SolvePart2Alternative(string[] lines)
    {
        var data = string.Join("", lines);
        var p = @"(mul\(\d{1,3},\d{1,3}\))|(do\(\))|(don't\(\))";

        var x = Regex.Matches(data, p);
        bool enabled = true;
        int s = 0;
        foreach (Match m in x)
        {
            if (m.Value == "don't()")
            {
                enabled = false;
            }
            else if (m.Value == "do()")
            {
                enabled = true;
            }
            else if (enabled)
            {
                s += ExecuteInstruction(m.Value);
            }
        }
        return s;
    }
}
