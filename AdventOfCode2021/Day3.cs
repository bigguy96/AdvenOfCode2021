namespace AdventOfCode2021;

public class Day3 : Days
{
    private const string Filename = "day3-input.txt";
    private static readonly string[] Input = GetFileContents(Filename);
    private static readonly int MaxLength = Input[0].ToCharArray().Length;

    public static int PartOne()
    {
        var gamma = string.Empty;
        var epsilon = string.Empty;
        var bits = new char[Input.Length, MaxLength];

        for (var i = 0; i < Input.Length; i++)
        {
            var bit = Input[i];

            for (var j = 0; j < MaxLength; j++)
            {
                bits[i, j] = bit[j];
            }
        }

        for (var i = 0; i < MaxLength; i++)
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
        var epsilonNumber = Convert.ToInt32(epsilon, 2);

        return gammaNumber * epsilonNumber;
    }

    public static int PartTwo()
    {
        var oxygen = Input.ToList();
        var carbonDioxide = Input.ToList();

        for (var i = 0; i < MaxLength; i++)
        {
            var zeroes = oxygen.Count(s => s[i].Equals('0'));
            var ones = oxygen.Count(s => s[i].Equals('1'));

            if (oxygen.Count == 1)
            {
                break;
            }

            if (ones > zeroes)
            {
                oxygen = oxygen.Where(s => s[i].Equals('1')).ToList();
            }
            else if (ones == zeroes)
            {
                oxygen = oxygen.Where(s => s[i].Equals('1')).ToList();
            }
            else
            {
                oxygen = oxygen.Where(s => s[i].Equals('0')).ToList();
            }
        }

        for (var i = 0; i < MaxLength; i++)
        {
            var zeroes = carbonDioxide.Count(s => s[i].Equals('0'));
            var ones = carbonDioxide.Count(s => s[i].Equals('1'));

            if (carbonDioxide.Count == 1)
            {
                break;
            }
            
            if (zeroes < ones)
            {
                carbonDioxide = carbonDioxide.Where(s => s[i].Equals('0')).ToList();
            }
            else if (ones == zeroes)
            {
                carbonDioxide = carbonDioxide.Where(s => s[i].Equals('0')).ToList();
            }
            else
            {
                carbonDioxide = carbonDioxide.Where(s => s[i].Equals('1')).ToList();
            }
        }

        var oxygenDecimal = Convert.ToInt32(oxygen.Single(), 2);
        var carbonDioxideDecimal = Convert.ToInt32(carbonDioxide.Single(), 2);

        return oxygenDecimal * carbonDioxideDecimal;
    }
}

//https://stackoverflow.com/questions/37458052/how-to-convert-a-2d-array-to-a-2d-list-in-c-sharp