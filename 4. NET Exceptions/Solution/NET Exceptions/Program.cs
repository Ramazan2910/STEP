namespace NET_Exceptions;

class Program
{
    static void Main(string[] args)
    {
        bool flag = true;
        while (flag)
        {
            try
            {
                // Проверка правильности ввода систем исчисления 
                
                Calculator calc = new Calculator();
                do
                {
                    try
                    {
                        calc.BaseFrom = calc.ChoiceOfSystem();
                    }
                    catch (InvalidNumberException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                } while (calc.BaseFrom == 0);

                do
                {
                    try
                    {
                        calc.BaseTo = calc.ChoiceOfSystem();
                    }
                    catch (InvalidNumberException  e)
                    {
                        Console.WriteLine(e.Message);
                        
                    }
                } while (calc.BaseTo == 0);
                
                // Ввод и проверка числа в базовой системе исчисления
                
                
                Console.Write("Please enter a number: ");
                calc.Number = Console.ReadLine();
                if (calc.Number == "*")
                {
                    flag = false;
                    continue;
                }
                Console.WriteLine();

                // Проверка числа
                
                switch (calc.BaseFrom)
                {
                    case 2:
                        if (!string.IsNullOrEmpty(calc.Number))
                        {
                            if (!Calculator.IsCorrectBinary(calc.Number))
                                throw new InvalidNumberException ("The number is not Binary! \n");
                            else
                            {
                                calc.Translation();
                            }
                                
                        }
                        else throw new NullReferenceException();
                        break;
                    case 8:
                        if (!string.IsNullOrEmpty(calc.Number))
                        {
                            if (!Calculator.IsCorrectOctal(calc.Number))
                                throw new InvalidNumberException ("The number is not Octal! \n");
                            else
                                calc.Translation();
                        }
                        else throw new NullReferenceException();
                        break;
                    case 10:
                        if (!string.IsNullOrEmpty(calc.Number))
                        {
                            if (!int.TryParse(calc.Number, out int num) || num < 0)
                                throw new InvalidNumberException ("The number is not Decimal! \n");
                            else
                                calc.Translation();
                        }
                        else throw new NullReferenceException();
                        break;
                    case 16:
                        if (!string.IsNullOrEmpty(calc.Number))
                        {
                            if (!Calculator.IsCorrectHex(calc.Number))
                                throw new InvalidNumberException ("The number is not Hexadecimal! \n");
                            else
                                calc.Translation();
                        }
                        else throw new NullReferenceException();
                        break;
                }

            }
            catch (InvalidNumberException  e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

       
    }
}