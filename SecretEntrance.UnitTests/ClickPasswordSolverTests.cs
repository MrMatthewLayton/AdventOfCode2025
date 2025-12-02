namespace SecretEntrance.UnitTests;

public class ClickPasswordSolverTests
{
    [Theory(DisplayName = "ClickPasswordSolver.Solve should produce the expected result")]
    [InlineData("L68,L30,R48,L5,R60,L55,L1,L99,R14,L82", DataFormat.Literal, 6)]
    [InlineData("Input.txt", DataFormat.File, 6638)]
    public void ClickPasswordSolverSolveShouldProduceExpectedResult(string data, DataFormat format, int expected)
    {
        // Given
        const int current = 50;

        IEnumerable<string> rotations = format switch
        {
            DataFormat.Literal => data.Split(',', StringSplitOptions.RemoveEmptyEntries),
            DataFormat.File => File.ReadAllLines(data),
            _ => throw new ArgumentOutOfRangeException(nameof(format))
        };

        ClickPasswordSolver systemUnderTest = new(current, rotations);

        // When
        int actual = systemUnderTest.Solve();

        // Then
        Assert.Equal(expected, actual);
    }
}