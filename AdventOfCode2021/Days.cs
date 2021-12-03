namespace AdventOfCode2021;

public abstract class Days
{
    private static readonly string MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

    protected static string[] GetFileContents(string filename)
    {
        var path = Path.Combine(MyDocuments, filename);
        return File.ReadAllLines(path);
    }
}