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
        var array = new long[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        var fishes = Input[0]
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        foreach (var fish in fishes)
        {
            array[fish]++;
        }

        for (var i = 80; i < days; ++i)
        {
            var cycle = array[0];

            for (var j = 1; j < 9; ++j)
            {
                array[j - 1] = array[j];
            }

            array[8] = cycle;
            array[6] += cycle;
        }

        return array.Sum().ToString();
    }
}