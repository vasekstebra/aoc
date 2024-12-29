using Solutions2024;

namespace Tests2024;

public class Day05Test
{
    [Fact]
    public void Part01Example()
    {
        Day05 solver = new();
        int result = solver.SolvePart01(File.ReadAllLines("2024/exampleinput05.txt"));
        Assert.Equal(143, result);
    }

    [Fact]
    public void Part02Example()
    {
        Day05 solver = new();
        int result = solver.SolvePart02(File.ReadAllLines("2024/exampleinput05.txt"));
        Assert.Equal(123, result);
    }
}
