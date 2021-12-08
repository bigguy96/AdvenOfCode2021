namespace AdventOfCode2021.Day6;

public class Day6 : Days
{
    private const string Filename = "day6-input.txt";
    private static readonly string[] Input = GetFileContents(Filename);

    public static string PartOne()
    {
        var fishes = Input[0]
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(number => Convert.ToInt32(number))
            .ToList();

        for (var i = 0; i < 18; i++)
        {
            var count = fishes.Count;
            for (var j = 0; j < count; j++)
            {
                if (fishes[j]== 0)
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


        return "";
    }
}