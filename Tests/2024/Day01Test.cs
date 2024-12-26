using Solutions2024;

namespace Tests2024;

public class Day01Test
{
    private readonly string[] EXAMPLE_INPUT = ["3 4", "4 3", "2 5", "1 3", "3 9", "3 3"];

    [Fact]
    public void Day01_part01_Example()
    {
        Day01 solver = new();
        int result = solver.SolvePart01(EXAMPLE_INPUT);
        Assert.Equal(11, result);
    }

    [Fact]
    public void Day01_part02_Example()
    {
        Day01 solver = new();
        int result = solver.SolvePart02(EXAMPLE_INPUT);
        Assert.Equal(31, result);
    }
}
