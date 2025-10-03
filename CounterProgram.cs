class CounterProgram : IProgram
{
    public string Title
    {
        get { return "CHARACTER + WORD COUNTER"; }
    }

    public void Run()
    {
        Console.Write("Input Text: ");
        string? input = Console.ReadLine();

        if (input == null)
        {
            return;
        }

        Console.WriteLine($"\nCharacters: {CountChars(input)}");
        Console.WriteLine($"Words: {CountWords(input)}");
    }

    private static int CountWords(string text)
    {
        char[] delimiters = [' ', '\t', '.', ',', '!', '?', ';'];
        return text.Split(delimiters).Length;
    }

    private static int CountChars(string text)
    {
        return text.Length;
    }
}
