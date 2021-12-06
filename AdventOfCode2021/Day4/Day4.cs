namespace AdventOfCode2021.Day4;

public class Day4 : Days
{
    private const string Filename = "day4-input.txt";
    private static readonly string[] Input = GetFileContents(Filename);

    public static int PartOne()
    {
        var numbers = Input[0].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(number => Convert.ToInt32(number)).ToList();
        var boardNumbers = Input.Where(value => !string.IsNullOrEmpty(value)).Skip(1).ToList();
        var boards = new List<Board>();
        var currentIndex = 1;

        foreach (var number in boardNumbers)
        {
            var board = new Board
            {
                Name = $"Board: {currentIndex}",
                Numbers = number.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(value => Convert.ToInt32(value)).ToList()
            };

            boards.Add(board);

            if (boards.Count % 5 == 0) currentIndex++;
        }

        var groupedBoards = boards.GroupBy(board => board.Name).ToList();

        var winner = false;
        var boardName = string.Empty;
        var winningNumber = 0;
        foreach (var number in numbers)
        {
            for (var i = 0; i < groupedBoards.Count; i++)
            {
                boardName = groupedBoards[i].Key;
                var num = groupedBoards[i].Select(board => board.Numbers).ToList();
                var total = 0;

                for (var j = 0; j < num.Count; j++)
                {
                    for (var k = 0; k < 5; k++)
                    {
                        if (num[j][k] == number)
                        {
                            num[j][k] = -1;
                        }

                        total += num[j][k];

                        if (total != -5) continue;
                        winner = true;
                        break;
                    }
                }
            }

            if (!winner) continue;
            winningNumber = number;
            break;
        }

        var boardTotal = groupedBoards
                             .Where(grouping => grouping.Key.Equals(boardName))
                             .Select(grouping => new { Total = grouping.SelectMany(board => board.Numbers).Where(number => number != -1).Sum() })
                             .Single().Total;

        var finalScore = winningNumber * boardTotal;
        Console.WriteLine($"\n\nWinning {boardName} with the last number drawn was: {winningNumber} with the board final score of : {finalScore}\n\n");

        return finalScore;
    }
}