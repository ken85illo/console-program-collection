interface IProgram
{
    public string Title { get; }
    public void Run();
}

class Application
{
    private enum Program
    {
        Morse = 1,
        TempConverter,
        EncryptDecrypt,
        CompoundInterest,
        Quit,
    }

    public static void Main()
    {
        Program programIndex;
        while (true)
        {
            do
            {
                Console.WriteLine("|==============================|");
                Console.WriteLine("|  CONSOLE PROGRAMS COLLECTION |");
                Console.WriteLine("|==============================|\n");
                Console.WriteLine("Pick an application:");
                Console.WriteLine("1. Text-to-Morse Translator");
                Console.WriteLine("2. Temperature Converter");
                Console.WriteLine("3. Encrypt/Decrypt Message");
                Console.WriteLine("4. Compound Interest Calculator");
                Console.WriteLine("5. Quit");

                Console.Write("\nChoice: ");
                programIndex = (Program)(Console.ReadKey().KeyChar - '0');
                Console.WriteLine("\n");

                if (programIndex < Program.Morse || programIndex > Program.Quit)
                {
                    Console.WriteLine(
                        $"Please input a value from ({(int)Program.Morse}-{(int)Program.Quit})"
                    );
                }
            } while (programIndex < Program.Morse || programIndex > Program.Quit);

            IProgram? program = GetProgram(programIndex);

            if (program == null)
            {
                break;
            }

            bool repeat;
            char choice;

            do
            {
                Console.WriteLine($"===={program.Title}====");
                program.Run();

                Console.Write("\nRepeat Program? (Y/N): ");
                choice = char.ToUpper(Console.ReadKey().KeyChar);

                repeat = choice == 'Y';
                Console.WriteLine("\n");
            } while (repeat);
        }
        Console.WriteLine("Thank you for using the program!");
    }

    private static IProgram? GetProgram(Program program)
    {
        return program switch
        {
            Program.Morse => new MorseProgram(),
            Program.TempConverter => new TempProgram(),
            Program.EncryptDecrypt => new EncryptProgram("key.txt"),
            Program.CompoundInterest => new CIProgram(),
            Program.Quit => null,
            _ => null,
        };
    }
}
