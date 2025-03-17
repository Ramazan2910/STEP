// Task 1
/*
Console.WriteLine("Enter number: ");
var str = Console.ReadLine();

int num1 = Convert.ToInt32(str);

if (num1 > 100 && num1 < 1)
{
    Console.WriteLine("Incorrect digit");
}
else
{
    if ((num1 % 3 == 0) && (num1 % 5 == 0))
    {
        Console.WriteLine("FizzBuzz");
    }
    else if (num1 % 5 == 0)
    {
        Console.WriteLine("Buzz");
    }
    else if (num1 % 3 == 0)
    {
        Console.WriteLine("Fizz");
    }
    else
    {
        Console.WriteLine($"Your number -> {num1}");
    }    
}*/


// Task 2
/*
Console.WriteLine("Enter digit: ");
var str = Console.ReadLine();
Console.WriteLine("Enter percent: ");
var str2 = Console.ReadLine();

int number1 = Convert.ToInt32(str);
int number2 = Convert.ToInt32(str2);


if (number2 > 100 || number2 <= 0 || number1 < 0)
{
    Console.WriteLine("Incorrect percent or number! ");
}
else
{
    var temp = (number1)* number2/100;
    Console.WriteLine($"Your percentage: {temp}");
}*/



//Task 3

/*
Console.WriteLine("Enter first number: ");
var str = Console.ReadLine();
int number1 = Convert.ToInt32(str);

if (number1 <= 0)
{
    Console.WriteLine("Incorrect input!");
}
else
{
    Console.WriteLine("Enter second number: ");
    var str2 = Console.ReadLine();
    Console.WriteLine("Enter third number: ");
    var str3 = Console.ReadLine();
    Console.WriteLine("Enter fourth number: ");
    var str4 = Console.ReadLine();
    int ?result1;


    int number2 = Convert.ToInt32(str2);
    int number3 = Convert.ToInt32(str3);
    int number4 = Convert.ToInt32(str4);
    
    result1 = (number1*1000)+ (number2*100) + (number3*10) + (number4); 
    Console.WriteLine("New number: " + result1);
}
*/



// Task 4

/*
Console.WriteLine("Enter number: ");
string str = Console.ReadLine()!;

if (str.Length == 6)
{
    Console.WriteLine("Enter first number: ");
    var num1 = Console.ReadLine();
    Console.WriteLine("Enter second number: ");
    var num2 = Console.ReadLine();
    
    int number1 = Convert.ToInt32(num1) - 1;
    int number2 = Convert.ToInt32(num2) - 1;

    if (number1 <= 0 || number1 > 6 ||number2 <= 0 || number2 > 6)
    {
        Console.WriteLine("You entered a incorrect number");
    }
    else
    {
        string result = "";

        for (int i = 0; i < str.Length; i++)
        {
            if (i == number1)
            {
                result += str[number2];
                continue;
            }
            else if (i == number2)
            {
                result += str[number1];
                continue;
            }
            result += str[i];
        }
        Console.WriteLine(result);
    }
}
else
{
    Console.WriteLine("Incorrect data!");
}

*/


// Task  5

/*
Console.WriteLine("Enter year: ");
var str = Console.ReadLine();
Console.WriteLine("Enter month: ");
var str2 = Console.ReadLine();
Console.WriteLine("Enter day: ");
var str3 = Console.ReadLine();

int year = Convert.ToInt32(str);
int month = Convert.ToInt32(str2);
int day = Convert.ToInt32(str3);

if (month == 2)
{
    if (year % 4 == 0)
    {
        if (day > 29)
        {
            Console.WriteLine("Incorrect date!");
        }
        else
        {
            if ((month > 0 && month < 13) && (day > 0 && day < 32))
            {

                DateTime startTime = new DateTime(year, month, day);


                if (startTime.Month > 2 & startTime.Month < 6)
                {
                    Console.WriteLine("Spring");
                }
                else if (startTime.Month > 5 & startTime.Month < 9)
                {
                    Console.WriteLine("Summer");
                }
                else if (startTime.Month > 8 & startTime.Month < 12)
                {
                    Console.WriteLine("Autumn");
                }
                else if (startTime.Month > 0 & startTime.Month < 3 | startTime.Month == 12)
                {
                    Console.WriteLine("Winter");
                }

                Console.WriteLine(startTime.DayOfWeek);

            }
            else
            {
                Console.WriteLine("Incorrect date!");
            }
        }
    }
    else if (year % 4 != 0)
    {
        if (day > 28)
        {
            Console.WriteLine("Incorrect date!");
        }
        else
        {
            if ((month > 0 && month < 13) && (day > 0 && day < 32))
            {

                DateTime startTime = new DateTime(year, month, day);


                if (startTime.Month > 2 & startTime.Month < 6)
                {
                    Console.WriteLine("Spring");
                }
                else if (startTime.Month > 5 & startTime.Month < 9)
                {
                    Console.WriteLine("Summer");
                }
                else if (startTime.Month > 8 & startTime.Month < 12)
                {
                    Console.WriteLine("Autumn");
                }
                else if (startTime.Month > 0 & startTime.Month < 3 | startTime.Month == 12)
                {
                    Console.WriteLine("Winter");
                }

                Console.WriteLine(startTime.DayOfWeek);

            }
            else
            {
                Console.WriteLine("Incorrect date!");
            }
        }
    }
}
else
{
    if ((month > 0 && month < 13) && (day > 0 && day < 32))
    {

        DateTime startTime = new DateTime(year, month, day);


        if (startTime.Month > 2 & startTime.Month < 6)
        {
            Console.WriteLine("Spring");
        }
        else if (startTime.Month > 5 & startTime.Month < 9)
        {
            Console.WriteLine("Summer");
        }
        else if (startTime.Month > 8 & startTime.Month < 12)
        {
            Console.WriteLine("Autumn");
        }
        else if (startTime.Month > 0 & startTime.Month < 3 | startTime.Month == 12)
        {
            Console.WriteLine("Winter");
        }

        Console.WriteLine(startTime.DayOfWeek);

    }
    else
    {
        Console.WriteLine("Incorrect date!");
    }
}
*/

// Task 6
/*

Console.WriteLine("1.Fahrenheit\n2.Celsius");
Console.WriteLine("Enter your choice: ");

var str = Console.ReadLine()!;

if (str[0] == '1')
{
    var far = Console.ReadLine()!;
    int fahrenheit = int.Parse(far);
    var temp = (fahrenheit - 32)/1.8;
    Console.WriteLine($"Fahrenheit: {temp:F1}");
}
else if (str[0] == '2')
{
    var cel = Console.ReadLine()!;
    int celsius = int.Parse(cel);
    var temp = (celsius * 1.8) + 32;
    Console.WriteLine($"Celsius: {temp:F1}");
}*/

// Task 7

/*
Console.WriteLine("Enter first number: ");
var str = Console.ReadLine();
Console.WriteLine("Enter second number: ");
var str2 = Console.ReadLine();

int number1 = Convert.ToInt32(str);
int number2 = Convert.ToInt32(str2);

if (number1 > number2)
{
    int temp = number1;
    number1 = number2;
    number2 = temp;
}

for (int i = number1; i < number2; i++)
{
    if (i % 2 == 0)
    {
        Console.WriteLine(i);
    }
}*/