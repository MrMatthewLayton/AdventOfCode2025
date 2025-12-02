namespace SecretEntrance;

public sealed class BasicPasswordSolver(int current, params IEnumerable<string> rotations)
{
    private int current = current;

    public int Solve()
    {
        const int modulus = 100;
        int result = 0;

        foreach (string rotation in rotations)
        {
            int value = rotation[0] switch
            {
                'L' => -int.Parse(rotation.TrimStart('L')),
                'R' => +int.Parse(rotation.TrimStart('R')),
                _ => throw new InvalidOperationException("The instruction must begin with L or R")
            };

            current = ((current + value) % modulus + modulus) % modulus;

            if (current is 0) result++;
        }

        return result;
    }
}