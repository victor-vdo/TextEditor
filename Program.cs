using System;
using System.IO;

internal class Program
{
    private static void Main(string[] args)
    {
        Menu();
    }
    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("Select an option:");
        Console.WriteLine("1 - Open a file");
        Console.WriteLine("2 - Create a file");
        Console.WriteLine("0 - Leave");
        short option = short.Parse(Console.ReadLine());

        switch(option)
        {
            case 0: System.Environment.Exit(0);
                break;
            case 1:
                Open();
                break; 
            case 2:
                Create();
                break;
            default:
                Menu();
                break;
        }
    }

    static void Open()
    {
        Console.Clear();
        Console.WriteLine("Type the path to open the file:");
        var path = Console.ReadLine();
        using(var file = new StreamReader(path))
        {
            string text = file.ReadToEnd();
            Console.WriteLine(text);
        }
        Console.WriteLine();
        Console.ReadLine();
        Menu();
    }

    static void Create()
    {
        Console.Clear();
        Console.WriteLine("Type your text below (ESC to leave).");
        Console.WriteLine("----------------");
        string text = "";

        do
        {
            text += Console.ReadLine();
            text += Environment.NewLine;
        }
        while(Console.ReadKey().Key != ConsoleKey.Escape);
        Save(text);
    }

    static void Save(string text)
    {
        Console.Clear();
        Console.WriteLine("Type the path to save the file:");
        var path = Console.ReadLine();
        using(var file = new StreamWriter(path))
        {
            file.Write(text);
        }
        Console.WriteLine($"File {path} saved successfully!");
        Console.ReadLine();
        Menu();
    }

}