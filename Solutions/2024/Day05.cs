namespace Solutions2024;

public class Day05
{
    public int SolvePart01(string[] lines)
    {
        List<string> orderingRules = lines.Where(l => l.Contains("|")).ToList();
        List<string[]> updates = lines.Skip(orderingRules.Count + 1).Select(l => l.Split(",")).ToList();
        var data = MapRules(orderingRules);

        return updates.Where(u => IsOrdered(u, data)).Select(u => int.Parse(u[u.Length / 2])).Sum();
    }

    public int SolvePart02(string[] lines)
    {
        List<string> orderingRules = lines.Where(l => l.Contains("|")).ToList();
        List<string[]> updates = lines.Skip(orderingRules.Count + 1).Select(l => l.Split(",")).ToList();
        var data = MapRules(orderingRules);

        return updates.Where(u => !IsOrdered(u, data)).Select(u => Order(u, data)).Select(u => int.Parse(u[u.Length / 2])).Sum();
    }

    private Dictionary<string, List<string>> MapRules(List<String> rules)
    {
        return rules.GroupBy(rule => rule.Split("|")[1], rule => rule.Split("|")[0])
            .ToDictionary(x => x.Key, x => x.ToList());
    }

    private bool IsOrdered(string[] updates, Dictionary<string, List<string>> rules)
    {
        HashSet<string> encountered = new();
        return updates.All(u =>
        {
            encountered.Add(u);
            return IsItemInOrder(u, updates, encountered, rules);
        });
    }

    private string[] Order(string[] updates, Dictionary<string, List<string>> rules)
    {
        List<string> ordered = new();

        Queue<string> candidates = new(updates);

        while (candidates.Count > 0)
        {
            var candidate = candidates.Dequeue();
            if (IsItemInOrder(candidate, updates, ordered, rules))
            {
                ordered.Add(candidate);
            }
            else
            {
                candidates.Enqueue(candidate);
            }
        }

        return ordered.ToArray();
    }

    private bool IsItemInOrder(string item, string[] items, IEnumerable<string> encountered, Dictionary<string, List<string>> rules)
    {
        var predecessors = rules.GetValueOrDefault(item);
        return predecessors == null || predecessors.All(p => !items.Contains(p) || encountered.Contains(p));
    }
}
