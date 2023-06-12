// See https://aka.ms/new-console-template for more information

Console.WriteLine("Word Finder by Alex Toapanta");


var matrix = new List<string>()
{
    "abcdc",
    "fgwio",
    "chill",
    "pqnsd",
    "uvdxy"
};

var wordStream = new List<string>()
{
    "cold",
    "wind",
    "snow",
    "chill"
};

ValidateMatrix(matrix);

PrintWordStream(wordStream);
PrintMatrix(matrix);

var wordFinder = new WordFinder.WordFinder(matrix);
var results = wordFinder.Find(wordStream);

InterprateResults(results);

static void ValidateMatrix(IEnumerable<string> matrix)
{
    if (!WordFinder.WordFinder.IsValidMaxMatrixSize(matrix))
    {
        Console.WriteLine("Matrix is bigger than 64x64");
        return;
    }

    if (!WordFinder.WordFinder.IsValidMatrixRows(matrix))
    {
        Console.WriteLine("Some elements in the matrix have different lengths");
        return;
    }
}

static void InterprateResults(IEnumerable<string> results)
{
    if (results.Count() == 0)
    {
        Console.WriteLine("No matches found");
    }
    else
    {
        Console.WriteLine("Top 10 matches:");
        results.ToList().ForEach(match => Console.WriteLine(match));
    }
}

static void PrintMatrix(IEnumerable<string> matrix)
{
    Console.WriteLine("Matrix: ");
    matrix.ToList().ForEach(row => Console.WriteLine(BuildRow(row)));
}

static string BuildRow(string row)
{
    var rowString = string.Empty;
    foreach (var character in row)
    {
        rowString += $"{character} |";
    }

    return rowString;
}

static void PrintWordStream(IEnumerable<string> wordStream)
{
    Console.WriteLine("Word stream: ");
    wordStream.ToList().ForEach(word => Console.WriteLine($"- {word}"));
}