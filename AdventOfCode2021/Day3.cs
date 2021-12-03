namespace AdventOfCode2021;

public class Day3 : Days
{
    private const string Filename = "day3-input.txt";
    private static readonly string[] Input = GetFileContents(Filename);

    public static int PartOne()
    {
        var gamma = string.Empty;
        var epsilon = string.Empty;
        var maxLength = Input[0].ToCharArray().Length;
        var bits = new char[Input.Length, maxLength];

        for (var i = 0; i < Input.Length; i++)
        {
            var bit = Input[i];

            for (var j = 0; j < maxLength; j++)
            {
                bits[i, j] = bit[j];
            }
        }

        for (var i = 0; i < maxLength; i++)
        {
            var zeroes = 0;
            var ones = 0;

            for (var j = 0; j < Input.Length; j++)
            {
                var value = bits[j, i];
                if (value.Equals('0'))
                {
                    zeroes++;
                }
                else
                {
                    ones++;
                }
            }

            if (ones > zeroes)
            {
                gamma += "1";
                epsilon += "0";
            }
            else
            {
                epsilon += "1";
                gamma += "0";
            }
        }

        var gammaNumber = Convert.ToInt32(gamma, 2);
        var epsilonNumber = Convert.ToInt32(epsilon,2);

        return gammaNumber * epsilonNumber;
    }
}