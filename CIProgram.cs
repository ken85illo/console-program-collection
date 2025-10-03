class CIProgram : IProgram
{
    public string Title
    {
        get { return "COMPOUND INTEREST CALCULATOR"; }
    }

    public void Run()
    {
        string? input;
        double principal,
            rate,
            time;

        input = TryInput("Principal Amount");
        if (input == null)
        {
            return;
        }
        principal = double.Parse(input);

        input = TryInput("Rate");
        if (input == null)
        {
            return;
        }
        rate = double.Parse(input);

        input = TryInput("Time Span");
        if (input == null)
        {
            return;
        }
        time = double.Parse(input);

        double amount = CalculateAmount(principal, rate, time);
        double compoundInterest = amount - principal;
        Console.WriteLine($"\nAmount: {amount}");
        Console.WriteLine($"Compound Interest: {compoundInterest}");
    }

    private static string? TryInput(string label)
    {
        string? input;
        bool valid;
        do
        {
            Console.Write($"{label}: ");
            input = Console.ReadLine();

            valid =
                input != null
                && !string.IsNullOrEmpty(input)
                && !string.IsNullOrWhiteSpace(input)
                && double.TryParse(input, out _);

            if (!valid)
            {
                Console.WriteLine("Please input a valid value!");
                Console.WriteLine();
            }
        } while (!valid);

        return input;
    }

    private static double CalculateAmount(double principal, double rate, double time)
    {
        return principal * Math.Pow(1 + rate / 100, time);
    }
}
