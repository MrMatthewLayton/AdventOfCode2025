namespace SecretEntrance;

internal static class Program
{
    private static void Main()
    {
        const int modulus = 100;
        int current = 50;
        int zeroCount = 0;

        foreach (string line in File.ReadAllLines("Input.txt"))
        {
            int rotation = line[0] switch
            {
                'L' => -int.Parse(line.TrimStart('L')),
                'R' => +int.Parse(line.TrimStart('R')),
                _ => throw new InvalidOperationException("Line must begin with L or R")
            };
            
            current = ((current + rotation) % modulus + modulus) % modulus;

            if (current is 0)
                zeroCount++;
        }

        Console.WriteLine(zeroCount);
    }
}