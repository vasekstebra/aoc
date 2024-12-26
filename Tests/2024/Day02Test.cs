using Solutions2024;

namespace Tests2024;

public class Day02Test
{
    private readonly string[] EXAMPLE_INPUT = ["7 6 4 2 1", "1 2 7 8 9", "9 7 6 2 1", "1 3 2 4 5", "8 6 4 4 1", "1 3 6 7 9"];

    [Fact]
    public void Day02_part01_Example()
    {
        Day02 solver = new();
        int result = solver.SolvePart01(EXAMPLE_INPUT);
        Assert.Equal(2, result);
    }

    [Fact]
    public void Day02_part02_Example()
    {
        Day02 solver = new();
        int result = solver.SolvePart02(EXAMPLE_INPUT);
        Assert.Equal(4, result);
    }
}
