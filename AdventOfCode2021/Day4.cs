namespace AdventOfCode2021;

public class Day4 : Days
{
    private const string Filename = "day4-input.txt";
    private static readonly string[] Input = GetFileContents(Filename);

    public static int PartOne()
    {
        var numbers = Input[0].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(number => Convert.ToInt32(number)).ToList();
        var boardNumbers = Input.Where(w=> !string.IsNullOrEmpty(w)).Skip(1).ToList();
        var boards = new List<Board>();
        var currentIndex = 1;

        foreach (var value in boardNumbers)
        {
            var board = new Board
            {
                Name = $"Board: {currentIndex}",
                Rows = new List<Rows>
                {
                    new()
                    {
                        Numbers = value.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s=>  Convert.ToInt32(s))
                    }
                }
            };

            boards.Add(board);

            if (boards.Count %5 == 0) currentIndex++;
        }

        var groupedBoards = boards.GroupBy(x => x.Name);

        foreach (var group in groupedBoards)
        {
            Console.WriteLine("\n");
            Console.WriteLine(group.Key);

            foreach (var board in group)
            {
                foreach (var row in board.Rows)
                {
                    Console.WriteLine(string.Join(" " , row.Numbers));
                }
            }
        }

        return 0;
    }
}

public class Board
{
    public string Name { get; set; }
    public IEnumerable<Rows> Rows { get; set; }
}

public class Rows
{
    public IEnumerable<int> Numbers { get; set; }
}