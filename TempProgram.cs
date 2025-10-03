class TempProgram : IProgram
{
    private enum Type
    {
        Celsius = 1,
        Fahrenheit,
        Kelvin,
    }

    public string Title
    {
        get { return "TEMPERATURE CONVERTER"; }
    }

    public void Run()
    {
        string? input;
        bool valid;
        do
        {
            Console.Write("Input Value: ");
            input = Console.ReadLine();

            valid =
                input != null
                && !string.IsNullOrEmpty(input)
                && !string.IsNullOrWhiteSpace(input)
                && double.TryParse(input, out _);

            if (!valid)
            {
                Console.WriteLine("Please input a valid value!");
            }
            Console.WriteLine();
        } while (!valid);

        if (input == null)
        {
            return;
        }
        double value = double.Parse(input);

        Console.WriteLine("What's the unit of this value?");
        Console.WriteLine("1. Celsius");
        Console.WriteLine("2. Fahrenheit");
        Console.WriteLine("3. Kelvin\n");
        Type choice;
        do
        {
            Console.Write("Choice: ");
            choice = (Type)(Console.ReadKey().KeyChar - '0');
            Console.WriteLine("\n");
            if (choice < Type.Celsius || choice > Type.Kelvin)
            {
                Console.WriteLine(
                    $"Please input a value from ({(int)Type.Celsius}-{(int)Type.Kelvin})\n"
                );
            }
        } while (choice < Type.Celsius || choice > Type.Kelvin);

        ITemperature? temp = GetObject(value, choice);

        if (temp == null)
        {
            return;
        }

        switch (choice)
        {
            case Type.Celsius:
                Celsius celsius = (Celsius)temp;
                Console.WriteLine($"Celsius: {celsius.Value} °C\t<- Input");
                Console.WriteLine($"Fahrenheit: {celsius.ToFahrenheit().Value} °F");
                Console.WriteLine($"Kelvin: {celsius.ToKelvin().Value} °K");
                break;
            case Type.Fahrenheit:
                Fahrenheit fahrenheit = (Fahrenheit)temp;
                Console.WriteLine($"Fahrenheit: {fahrenheit.Value} °F\t<- Input");
                Console.WriteLine($"Celsius: {fahrenheit.ToCelsius().Value} °C");
                Console.WriteLine($"Kelvin: {fahrenheit.ToKelvin().Value} °K");
                break;
            case Type.Kelvin:
                Kelvin kelvin = (Kelvin)temp;
                Console.WriteLine($"Kelvin: {kelvin.Value} °K\t<- Input");
                Console.WriteLine($"Celsius: {kelvin.ToCelsius().Value} °C");
                Console.WriteLine($"Fahrenheit: {kelvin.ToFahrenheit().Value} °F");
                break;
        }
    }

    private static ITemperature? GetObject(double value, Type type)
    {
        return type switch
        {
            Type.Celsius => new Celsius(value),
            Type.Fahrenheit => new Fahrenheit(value),
            Type.Kelvin => new Kelvin(value),
            _ => null,
        };
    }
}

interface ITemperature
{
    public double Value { get; protected set; }
}

class Celsius(double value) : ITemperature
{
    public double Value { get; set; } = value;

    public Fahrenheit ToFahrenheit()
    {
        return new Fahrenheit(Value * (9.0 / 5.0f) + 32.0);
    }

    public Kelvin ToKelvin()
    {
        return new Kelvin(Value + 273.15);
    }
}

class Fahrenheit(double value) : ITemperature
{
    public double Value { get; set; } = value;

    public Celsius ToCelsius()
    {
        return new Celsius((Value - 32.0) * 5.0 / 9.0);
    }

    public Kelvin ToKelvin()
    {
        return new Kelvin((Value - 32.0) * 5.0 / 9.0 + 273.15);
    }
}

class Kelvin(double value) : ITemperature
{
    public double Value { get; set; } = value;

    public Celsius ToCelsius()
    {
        return new Celsius(Value - 273.15);
    }

    public Fahrenheit ToFahrenheit()
    {
        return new Fahrenheit((Value - 273.15) * 9.0 / 5.0 + 32.0);
    }
}
