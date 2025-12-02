namespace SecretEntrance.UnitTests;

public sealed class BasicPasswordSolverTests
{
    [Theory(DisplayName = "BasicPasswordSolver.Solve should produce the expected result")]
    [InlineData("L68,L30,R48,L5,R60,L55,L1,L99,R14,L82", DataFormat.Literal, 3)]
    [InlineData("Input.txt", DataFormat.File, 1129)]
    public void BasicPasswordSolverSolveShouldProduceExpectedResult(string data, DataFormat format, int expected)
    {
        // Given
        const int current = 50;

        IEnumerable<string> rotations = format switch
        {
            DataFormat.Literal => data.Split(',', StringSplitOptions.RemoveEmptyEntries),
            DataFormat.File => File.ReadAllLines(data),
            _ => throw new ArgumentOutOfRangeException(nameof(format))
        };

        BasicPasswordSolver systemUnderTest = new(current, rotations);

        // When
        int actual = systemUnderTest.Solve();

        // Then
        Assert.Equal(expected, actual);
    }
}