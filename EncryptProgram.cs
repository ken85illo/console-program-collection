using System.Text;

class EncryptProgram : IProgram
{
    private enum Mode
    {
        Encryption = 1,
        Decryption,
    };

    private readonly string chars =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 !#$%&'()*+,-./:;<=>?@[\\]^_{|}~\"`";
    private readonly string key;

    public EncryptProgram(string path)
    {
        if (File.Exists(path))
        {
            key = File.ReadAllText(path);
            return;
        }

        char[] charArr = chars.ToCharArray();
        Random rand = new();

        for (int i = 0; i < charArr.Length; i++)
        {
            int randIdx = rand.Next(charArr.Length);
            (charArr[randIdx], charArr[i]) = (charArr[i], charArr[randIdx]);
        }

        key = new string(charArr);
        File.WriteAllText(path, key);
    }

    public string Title
    {
        get { return "ENCRYPTION/DECRYPTION PROGRAM"; }
    }

    public void Run()
    {
        Console.WriteLine("Pick a mode: ");
        Console.WriteLine("1. Encryption");
        Console.WriteLine("2. Decryption");

        Mode choice;
        do
        {
            Console.Write("Choice: ");
            choice = (Mode)(Console.ReadKey().KeyChar - '0');
            Console.WriteLine();
            if (choice < Mode.Encryption || choice > Mode.Decryption)
            {
                Console.WriteLine(
                    $"Please input a value from ({(int)Mode.Encryption}-{(int)Mode.Decryption})"
                );
            }
        } while (choice < Mode.Encryption || choice > Mode.Decryption);

        Console.Write("\nMessage: ");
        string? message = Console.ReadLine();

        if (message == null)
        {
            return;
        }

        if (choice == Mode.Encryption)
        {
            Console.WriteLine($"Encrypted Message: {Encrypt(message)}");
        }
        else
        {
            Console.WriteLine($"Decrypted Message: {Decrypt(message)}");
        }
    }

    private string Encrypt(string text)
    {
        StringBuilder strb = new();

        foreach (char ch in text)
        {
            int charIdx = chars.IndexOf(ch);
            strb.Append(key[charIdx]);
        }

        return strb.ToString();
    }

    private string Decrypt(string text)
    {
        StringBuilder strb = new();

        foreach (char ch in text)
        {
            int charIdx = key.IndexOf(ch);
            strb.Append(chars[charIdx]);
        }

        return strb.ToString();
    }
}
