namespace AdventOfCode2021.Day6;

public class Day6 : Days
{
    private const string Filename = "day6-input.txt";
    private static readonly string[] Input = GetFileContents(Filename);

    public static string PartOne()
    {
        const int days = 80;
        var fishes = Input[0]
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(number => Convert.ToInt32(number))
            .ToList();

        for (var i = 0; i < days; i++)
        {
            var count = fishes.Count;
            for (var j = 0; j < count; j++)
            {
                if (fishes[j] == 0)
                {
                    fishes[j] = 6;
                    fishes.Add(8);
                }
                else
                {
                    fishes[j]--;
                }
            }
        }

        return fishes.Count.ToString();
    }

    public static string PartTwo()
    {
        const int days = 256;
        var numbers = new long[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        var ages = Input[0]
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        foreach (var age in ages)
        {
            numbers[age]++;
        }

        for (var i = 0; i < days; ++i)
        {
            var number = numbers[0];

            for (var j = 1; j < 9; ++j)
            {
                numbers[j - 1] = numbers[j];
            }

            numbers[8] = number;
            numbers[6] += number;
        }

        return numbers.Sum().ToString();
    }
}