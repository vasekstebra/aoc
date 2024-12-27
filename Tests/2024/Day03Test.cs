using Solutions2024;

namespace Tests2024;

public class Day03Test
{
    private readonly string EXAMPLE_INPUT = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
    private readonly string EXAMPLE_INPUT_2 = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

    [Fact]
    public void Day03_part01_Example()
    {
        Day03 solver = new();
        int result = solver.SolvePart01([EXAMPLE_INPUT]);
        Assert.Equal(161, result);
    }

    [Fact]
    public void Day03_part02_Example()
    {
        Day03 solver = new();
        int result = solver.SolvePart02([EXAMPLE_INPUT_2]);
        Assert.Equal(48, result);
    }
}
