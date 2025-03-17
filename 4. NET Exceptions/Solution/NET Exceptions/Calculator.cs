using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NET_Exceptions;

public class Calculator
{
    private int _counter = 0;
    
    private string[] _systems = {"base number system","number system for translation"};
    public string? Number { get; set; }
    public int BaseFrom { get; set; } = 0;
    public int BaseTo { get; set; } = 0;
    public int ChoiceOfSystem()
    {
        int choice;
        Console.WriteLine($"Please select a {_systems[_counter]}: ");
        Console.WriteLine("1. Binary");
        Console.WriteLine("2. Octal");
        Console.WriteLine("3. Decimal");
        Console.WriteLine("4. Hexadecimal");
        Console.Write("Enter a number: ");
        if (!int.TryParse(Console.ReadLine(), out choice))
        {
            throw new InvalidNumberException("\nIncorrect number input! Please try again! \n");
        }
        
        Console.WriteLine();
        
        if (choice < 1 || choice > 4) 
            throw new InvalidNumberException ("You need to select a number from the system! Please try again! \n");
        else
        {
            _counter++;
            return NumberSystem(choice);
        }
    }
    public static int NumberSystem(int number)
    {
        int temp = 0;
        switch (number)
        {
            case 1:
                temp = 2;
                break;
            case 2:
                temp = 8;
                break;
            case 3:
                temp = 10;
                break;
            case 4:
                temp = 16;
                break;
        }
        return temp;
    }
    public void Translation()
    {
        int decimalValue = Convert.ToInt32(this.Number, this.BaseFrom);
        
        string result = Convert.ToString(decimalValue, this.BaseTo);
        
        Console.Write($"Number {Number} from {BaseFrom}-th system to ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"{result}");
        Console.ResetColor();
        Console.WriteLine($" in {BaseTo}-th system \n");
    }
    public static bool IsCorrectBinary(string number)
    {
        foreach (var i in number)
        {
            if (i != '0' && i != '1') return false;
        }
        return true;
    }
    public static bool IsCorrectOctal(string number)
    {
        foreach (var i in number)
        {
            if (i < '0' || i > '7') return false;
        }
        return true;
    }
    public static bool IsCorrectHex(string number)
    {
        foreach (var i in number)
        {
            if (!((i >= '0' && i <= '9') || (i >= 'A' && i <= 'F') || (i >= 'a' && i <= 'f'))) return false;
        }
        return true;
    }



}