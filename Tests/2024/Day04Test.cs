using Solutions2024;

namespace Tests2024;

public class Day04Test
{
    private readonly string[] EXAMPLE_INPUT = [
        "MMMSXXMASM",
        "MSAMXMSMSA",
        "AMXSXMAAMM",
        "MSAMASMSMX",
        "XMASAMXAMM",
        "XXAMMXXAMA",
        "SMSMSASXSS",
        "SAXAMASAAA",
        "MAMMMXMMMM",
        "MXMXAXMASX",
    ];

    [Fact]
    public void Day04_part01_Example()
    {
        Day04 solver = new();
        int result = solver.SolvePart01(EXAMPLE_INPUT);
        Assert.Equal(18, result);
    }

    [Fact]
    public void Day04_part02_Example()
    {
        Day04 solver = new();
        int result = solver.SolvePart02(EXAMPLE_INPUT);
        Assert.Equal(9, result);
    }
}
