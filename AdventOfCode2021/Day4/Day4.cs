using System.Net.Http.Headers;

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
        foreach (var number in numbers)
        {
            for (var i = 0; i < groupedBoards.Count; i++)
            {
                Console.WriteLine($"\n\n{groupedBoards[i].Key}");
                var num = groupedBoards[i].Select(board => board.Numbers).ToList();
                var total = 0;

                for (var j = 0; j < num.Count; j++)
                {
                    Console.WriteLine("");
                    for (var k = 0; k < 5; k++)
                    {
                        if (num[j][k] == number)
                        {
                            num[j][k] = -1;
                        }

                        total += num[j][k];

                        if (total == -5)
                        {
                            winner = true;
                            Console.WriteLine("WINNER!!!");
                            break;
                        }

                        Console.Write($"{num[j][k]} ");
                    }
                }
            }

            if (winner)
            {
                break;
            }
        }

        //foreach (var group in groupedBoards)
        //{
        //    Console.WriteLine("\n");
        //    Console.WriteLine(group.Key);

        //    foreach (var board in group)
        //    {
        //        Console.WriteLine(string.Join(" ", board.Numbers));
        //    }
        //}

        //var winner = false;
        //var message = string.Empty;
        //var winningBoard = new Board();
        //foreach (var number in numbers)
        //{
        //    foreach (var board in groupedBoards.SelectMany(groupedBoard => groupedBoard))
        //    {
        //        for (var i = 0; i < board.Numbers.Count; i++)
        //        {
        //            if (board.Numbers[i] == number)
        //            {
        //                board.Numbers[i] = -1;
        //            }
        //        }

        //        if (board.Numbers.Sum() != -5) continue;
        //        winner = true;
        //        winningBoard = board;
        //        message = $"Board {board.Name} won!";
        //        break;
        //    }

        //    foreach (var board in groupedBoards.SelectMany(groupedBoard => groupedBoard))
        //    {
        //        var r = board;
        //    }

        //    if (!winner) continue;
        //    Console.WriteLine($"{message} with number: {number}");
        //    break;
        //}

        return 0;
    }
}