﻿namespace AdventOfCode2021.Day4;

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

            for (var i = 0; i < groupedBoards.Count; i++)
            {
                var num = groupedBoards[i].Select(board => board.Numbers).ToList();

                for (var index = 0; index < 5; index++)
                {
                    var totalRows = num[index][0] + num[index][1] + num[index][2] + num[index][3] + num[index][4];
                    var totalColumns = num[0][index] + num[1][index] + num[2][index] + num[3][index] + num[4][index];

                    if (totalRows == -5 || totalColumns == -5)
                    {
                        winner = true;
                        winningNumber = number;
                        boardName = groupedBoards[i].Key;
                        break;
                    }
                }
            }

            if (winner) break;
        }

        var boardTotal = groupedBoards
            .Where(grouping => grouping.Key.Equals(boardName))
            .Select(grouping => new { Total = grouping.SelectMany(board => board.Numbers).Where(number => number != -1).Sum() })
            .Single().Total;

        var finalScore = winningNumber * boardTotal;
        return $"Winning {boardName}; the last number drawn was: {winningNumber}; with a final score of: {finalScore}.";
    }
}