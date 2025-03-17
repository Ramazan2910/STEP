using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Exam;

public class Validator: IValidator
{
    public static void IsCorrectNaming(string word)
    {
        if (!Regex.IsMatch(word, @"^[A-Z][A-Za-z0-9]{3,}$")) throw new FormatException("Naming must start with an uppercase letter, use at least 4 characters, only letters and digits allowed!");
    }
    public static int IsCorrectDigit(string digit)
    {
        if(!int.TryParse(digit, out int number)) throw new FormatException("Incorrect input!");
        return number;
    }
    
    public static bool IsCorrectAnswer(string answer)
    {
        try
        {
            if (!Regex.IsMatch(answer, @"^[ABCDabcd]$")) throw new FormatException("Invalid input!");
            return true;
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
        return false;
    }


    public static bool IsStringNotNullOrEmpty(string question)
    {
        try
        {
            if(string.IsNullOrEmpty(question)) throw new FormatException("Invalid input!");
            return true;
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
        return false;
    }

    public bool CheckName(string name, int mode)
    {
        string[] expressions = new []{"name","surname","father name"};
        try
        {
            if (!Regex.IsMatch(name, @"^[A-Z][a-zA-Z]{2,}$")) throw new FormatException($"Incorrect input of {expressions[mode]}!");
            return true;
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
        return false;
    }

    public bool CheckAge(string age)
    {
        try
        {
            if(!int.TryParse(age,out int newAge) || (newAge < 6 || newAge > 120)) 
                throw new FormatException("Incorrect input of age !");
            return true;
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
        return false;
    }

    public bool CheckLogin(string login)
    {
        try
        {
            if(!Regex.IsMatch(login, @"^(?=.*\d)[a-zA-Z0-9_]{4,16}$")) 
                throw new FormatException("Incorrect input of login !");
            return true;
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
        return false;
    }

    public bool CheckPassword(string password)
    {
        try
        {
            if (!Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@#$%!])[A-Za-z\d@$!%*?&]{8,20}$"))
                throw new FormatException("Incorrect input of password !");
            return true;
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
        return false;
    }
    
}