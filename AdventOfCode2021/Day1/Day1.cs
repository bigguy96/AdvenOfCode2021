namespace AdventOfCode2021.Day1;

public class Day1 : Days
{
    public static int GetSum(int start)
    {
        const string filename = "day1-input.txt";
        var numbers = GetFileContents(filename).Select(value => Convert.ToInt32(value)).ToList();
        var count = 0;

        for (var i = start; i < numbers.Count; i++)
        {
            var previous = numbers[i - start];
            var current = numbers[i];

            if (current > previous) count++;
        }

        return count;
    }
}