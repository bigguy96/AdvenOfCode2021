namespace AdventOfCode2021.Day4;

public class Day4 : Days
{
    private const string Filename = "day4-input.txt";
    private static readonly string[] Input = GetFileContents(Filename);

    public static string PartOne()
    {
        var numbers = Input[0].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(number => Convert.ToInt32(number)).ToList();
        var boardNumbers = Input.Where(value => !string.IsNullOrEmpty(value)).Skip(1).ToList();
        var boards = new List<Board>();
        var currentIndex = 1;

        //create bingo boards from input.
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

        //create grouping of bingo boards by their names.
        var groupedBoards = boards.GroupBy(board => board.Name).ToList();

        var winner = false;
        var boardName = string.Empty;
        var winningNumber = 0;

        //loop through bingo numbers.
        foreach (var number in numbers)
        {
            //check if number is exits on bingo board, and set it as -1 (marked);
            for (var i = 0; i < groupedBoards.Count; i++)
            {
                var num = groupedBoards[i].Select(board => board.Numbers).ToList();

                for (var j = 0; j < num.Count; j++)
                {
                    for (var k = 0; k < 5; k++)
                    {
                        var n = num[j][k];
                        if (num[j][k] == number)
                        {
                            num[j][k] = -1;
                        }
                    }
                }
            }

            //check if there's a bingo.
            for (var i = 0; i < groupedBoards.Count; i++)
            {
                var num = groupedBoards[i].Select(board => board.Numbers).ToList();

                for (var j = 0; j < 5; j++)
                {
                    var totalRows = num[j][0] + num[j][1] + num[j][2] + num[j][3] + num[j][4];
                    var totalColumns = num[0][j] + num[1][j] + num[2][j] + num[3][j] + num[4][j];

                    if (totalRows != -5 && totalColumns != -5) continue;
                    
                    winner = true;
                    winningNumber = number;
                    boardName = groupedBoards[i].Key;
                    break;
                }
            }

            if (winner) break;
        }

        //get board total number.
        var boardTotal = groupedBoards
            .Where(grouping => grouping.Key.Equals(boardName))
            .Select(grouping => new { Total = grouping.SelectMany(board => board.Numbers).Where(number => number != -1).Sum() })
            .Single().Total;

        var finalScore = winningNumber * boardTotal;
        return $"Winning {boardName}; the last number drawn was: {winningNumber}; with a final score of: {finalScore}.";
    }
}