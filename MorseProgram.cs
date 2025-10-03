using System.Text;

class MorseProgram : IProgram
{
    public string Title
    {
        get { return "MORSE CODE TRANSLATOR"; }
    }

    public void Run()
    {
        Console.Write("Input Text: ");
        string? input = Console.ReadLine();

        Console.Write("Morse Code: ");

        if (input != null)
        {
            Console.WriteLine(new Morse(input).Code);
        }
    }
}

class Morse
{
    // csharpier-ignore
    private static readonly Dictionary<char, string> MorseMap = new()
    {
        { 'A', ".-" },     { 'B', "-..." },   { 'C', "-.-." },
        { 'D', "-.." },    { 'E', "." },      { 'F', "..-." },
        { 'G', "--." },    { 'H', "...." },   { 'I', ".." },
        { 'J', ".---" },   { 'K', "-.-" },    { 'L', ".-.." },
        { 'M', "--" },     { 'N', "-." },     { 'O', "---" },
        { 'P', ".--." },   { 'Q', "--.-" },   { 'R', ".-." },
        { 'S', "..." },    { 'T', "-" },      { 'U', "..-" },
        { 'V', "...-" },   { 'W', ".--" },    { 'X', "-..-" },
        { 'Y', "-.--" },   { 'Z', "--.." },   { '0', "-----" },
        { '1', ".----" },  { '2', "..---" },  { '3', "...--" },
        { '4', "....-" },  { '5', "....." },  { '6', "-...." },
        { '7', "--..." },  { '8', "---.." },  { '9', "----." },
        { ' ', "/" },
    };

    public string Code { get; private set; }

    public Morse(string text)
    {
        StringBuilder strb = new();

        foreach (char c in text.ToUpper())
        {
            if (!MorseMap.ContainsKey(c))
            {
                continue;
            }

            strb.Append(MorseMap[c] + " ");
        }

        Code = strb.ToString();
    }
}
