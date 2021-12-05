namespace AdventOfCode2021.Day2;

public class Day2 : Days
{
    private const string Filename = "day2-input.txt";
    private static readonly string[] Input = GetFileContents(Filename);

    public static int PartOne()
    {
        var horizontal = 0;
        var depth = 0;

        foreach (var value in Input)
        {
            var split = value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var direction = split[0];
            var number = Convert.ToInt32(split[1]);

            switch (direction)
            {
                case "forward":
                    {
                        horizontal += number;
                        break;
                    }
                case "up":
                    {
                        depth -= number;
                        break;
                    }
                case "down":
                    {
                        depth += number;
                        break;
                    }
            }
        }

        return horizontal * depth;
    }
    public static int PartTwo()
    {
        var horizontal = 0;
        var depth = 0;
        var aim = 0;

        foreach (var value in Input)
        {
            var split = value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var direction = split[0];
            var number = Convert.ToInt32(split[1]);

            switch (direction)
            {
                case "forward":
                    {
                        horizontal += number;
                        depth += aim * number;
                        break;
                    }
                case "up":
                    {
                        aim -= number;
                        break;
                    }
                case "down":
                    {
                        aim += number;
                        break;
                    }
            }
        }

        return horizontal * depth;
    }
}