//Task 1


int row = 3;
int col = 4;

int[] A = new int[5];
int [,] B = new int[row,col];

int sumA = 0;
int sumB = 0;

long multiplicationA = 1;
long multiplicationB = 1;

int sumOfEvenElementsOfA = 0;
int sumOfOddColumnsOfB = 0;

int maxB = int.MinValue;
int minB = int.MaxValue;

Console.WriteLine("Enter didgits in A matrix: ");
for (int i = 0; i < A.Length; i++)
{
    A[i] = Convert.ToInt32(Console.ReadLine());
    if(A[i]%2==0){ sumOfEvenElementsOfA += A[i]; }
    sumA += A[i];
    multiplicationA *= A[i];
}

int maxA = A.Max();
int minA = A.Min();

Console.Clear();

Console.WriteLine("Matrix A: ");

for (int i = 0; i < A.Length; i++)
{
    Console.Write(A[i] + " ");
}
Console.WriteLine();

Console.WriteLine("Matrix B: ");

Random rand = new Random();
for (int i = 0; i < row; i++)
{
    for (int j = 0; j < col; j++)
    {
        B[i, j] = rand.Next(1,40);
        Console.Write(B[i, j] + " ");
        if (j % 2 == 0)
        {
            sumOfOddColumnsOfB += B[i,j];
        }
        sumB += B[i, j];
        multiplicationB *= B[i, j];
        if (B[i,j]> maxB) { maxB = B[i,j]; } 
        if (B[i,j] < minB) { minB = B[i,j]; }
    }
    Console.WriteLine();
}   

Console.WriteLine($"Common max value -> {(maxA > maxB ? maxA : maxB)}");
Console.WriteLine($"Common min value -> {(minA > minB ? minB : minA)}");
Console.WriteLine($"Total sum of all elements -> {sumA + sumB}");
Console.WriteLine($"Total multiplication factor -> {multiplicationA * multiplicationB}");
Console.WriteLine($"The sum of even elements of array A -> {sumOfEvenElementsOfA}");
Console.WriteLine($"the sum of the odd columns of array B - > {sumOfOddColumnsOfB}");


//Task 2


Random random = new Random();

int[,] matrix = new int[5, 5];

int max = int.MinValue;
int min = int.MaxValue;
int sum = 0;
int count = 0;
bool flag = false;

for (int i = 0; i < 5; i++)
{
    for (int j = 0; j < 5; j++)
    {
        matrix[i, j] = random.Next(-100,100);
        if (matrix[i, j] < min) { min = matrix[i, j]; }
        if (matrix[i, j] > max) { max = matrix[i, j]; }
        Console.Write($"{matrix[i, j]} ");
    }
    Console.WriteLine();
}

for (int i = 0; i < 5; i++)
{
    for (int j = 0; j < 5; j++)
    {
        if (matrix[i, j] == max || matrix[i, j] == min)
        {
            flag = count == 0 ? true : false;
            count++;
            continue;
        }
        if (flag) { sum += matrix[i, j]; }
    }
}

Console.WriteLine($"Sum of array elements located between the minimum and maximum elements: {sum}");


// Task 3

using System.Text;

Console.Write("Enter text: ");
StringBuilder Text =  new StringBuilder(Console.ReadLine());

for (int i = 0; i < Text.Length; i++)
{
    Text[i] = (char)(Text[i] + 3);
}

Console.WriteLine(Text);


// Task 4 

Random random = new Random();

Console.Write("Enter row of first matrix: ");
int row1 = int.Parse(Console.ReadLine());
Console.Write("Enter column of first matrix: ");
int column1 = int.Parse(Console.ReadLine());
Console.Write("Enter row of second matrix: ");
int row2 = int.Parse(Console.ReadLine());
Console.Write("Enter column of second matrix: ");
int column2 = int.Parse(Console.ReadLine());*/
int[,] matrix2 = new int[3,3];

int[,] matrix1 = new int[3,3]; 
Console.Write("Enter number: ");
int num = Convert.ToInt32(Console.ReadLine());

for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        matrix1[i, j] = random.Next(1,30);
        Console.Write(matrix1[i, j] + " ");
    }
    Console.WriteLine();
}

for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        matrix1[i, j] *= num;
        Console.Write(matrix1[i, j] + " ");
    }
    Console.WriteLine();
}



Console.Write("Enter row of first matrix: ");
int row1 = int.Parse(Console.ReadLine());
Console.Write("Enter column of first matrix: ");
int column1 = int.Parse(Console.ReadLine());
Console.Write("Enter row of second matrix: ");
int row2 = int.Parse(Console.ReadLine());
Console.Write("Enter column of second matrix: ");
int column2 = int.Parse(Console.ReadLine());


if (row1 == row2 && column1 == column2)
{
    int[,] matrix1 = new int[row1,column1];
    int[,] matrix2 = new int[row2,column2];
    int[,] result = new int[row1,column1];

    Console.WriteLine("Matrix 1:");

    for (int i = 0; i < row1; i++)
    {
        for (int j = 0; j < column1; j++)
        {
            matrix1[i, j] = random.Next(1,30);
            Console.Write(matrix1[i, j] + " ");
        }
        Console.WriteLine();
    }

    Console.WriteLine("Matrix 2:");

    for (int i = 0; i < row2; i++)
    {
        for (int j = 0; j < column2; j++)
        {
            matrix2[i, j] = random.Next(1,30);
            Console.Write(matrix2[i, j] + " ");
        }
        Console.WriteLine();
    }

    Console.WriteLine("Result:");

    for (int i = 0; i < row1; i++)
    {
        for (int j = 0; j < column1; j++)
        {
            result[i, j] = matrix1[i, j] + matrix2[i, j];
            Console.Write(result[i, j] + " ");
        }
        Console.WriteLine();

    }
}
else
{
    Console.WriteLine("Matrices must be the same!");
}


Console.Write("Enter row of first matrix: ");
int row1 = int.Parse(Console.ReadLine());
Console.Write("Enter column of first matrix: ");
int column1 = int.Parse(Console.ReadLine());
Console.Write("Enter row of second matrix: ");
int row2 = int.Parse(Console.ReadLine());
Console.Write("Enter column of second matrix: ");
int column2 = int.Parse(Console.ReadLine());

int[,] matrix1 = new int[row1,column1];
int[,] matrix2 = new int[row2,column2];

int flag = 0;

if (column1 == row2)
{
    flag = 1;
}
else if (column2 == row1)
{
    flag = 2;
}
else
{
    Console.WriteLine("\nThe incorrect size of matrices!");
}

if (flag > 0)
{
    Console.WriteLine("\nMatrix1: ");

    for (int i = 0; i < row1; i++)
    {
        for (int j = 0; j < column1; j++)
        {
            matrix1[i, j] = random.Next(1,10);
            Console.Write(matrix1[i, j] + " ");
        }
        Console.WriteLine();
    }

    Console.WriteLine("\nMatrix2: ");
    for (int i = 0; i < row2; i++)
    {
        for (int j = 0; j < column2; j++)
        {
            matrix2[i, j] = random.Next(1,10);
            Console.Write(matrix2[i, j] + " ");
        }
        Console.WriteLine();
    }
}
if (flag == 1)
{
    int [,] newMatrix = new int[row1,column2];

    for (int i = 0; i < row1; i++)
    {
        for (int j = 0; j < column2; j++)
        {
            int temp = 0;
            for (int k = 0; k < row2; k++)
            {
                temp += matrix1[i, k] * matrix2[k, j];
            }
            newMatrix [i, j] = temp;
        }
    }

    Console.WriteLine("\nNew matrix: ");
    
    for (int i = 0; i < row1 ; i++)
    {
        for (int j = 0; j < column2; j++)
        {
            Console.Write(newMatrix[i, j] + " ");
        }
        Console.WriteLine();
    }
    
    
}
else if (flag == 2)
{
    int [,] newMatrix = new int[row2,column1];
    
    for (int i = 0; i < row2; i++)
    {
        for (int j = 0; j < column1; j++)
        {
            int temp = 0;
            for (int k = 0; k < row1; k++)
            {
                temp += matrix2[i, k] * matrix1[k, j];
            }
            newMatrix [i, j] = temp;
        }
    }

    Console.WriteLine("\nNew matrix: ");
    
    for (int i = 0; i < row2 ; i++)
    {
        for (int j = 0; j < column1; j++)
        {
            Console.Write(newMatrix[i, j] + " ");
        }
        Console.WriteLine();
    }
}

// Task 5


Console.Write("Enter the arithmetic expression: ");
string input = Console.ReadLine()!;

char[] oper = new char[20];
int counter = 0;

for (int i = 0; i < input.Length; i++)
{
    if (input[i] == '+' || input[i] == '-')
    {
        oper[counter] = input[i];
        Console.Write(oper[counter]);
        counter++;
    }
    
}
Console.WriteLine();


string[] values = input.Split(new []{'+','-'});
int[] valuesInt = new int[values.Length];
int result = 0;
counter = 0;
for (int i = 0; i < values.Length; i++)
{
    
    values[i] = values[i].Trim();
    valuesInt[i] = Convert.ToInt32(values[i]);
    
    if (i == 0)
    {
        result += valuesInt[i];
        continue;
    }
    
    if (oper[counter] == '+')
    {
        result += valuesInt[i];
        counter++;
    }
    else if(oper[counter] == '-')
    {
        result -= valuesInt[i];
        counter++;
    }
}

Console.WriteLine(result);


// Task 6


Console.Write("Enter the test: ");
string input = Console.ReadLine()!;

char[] oper = new char[20];
int counter = 0;

for (int i = 0; i < input.Length; i++)
{
    if (input[i] == '.' || input[i] == '?' || input[i] == '!')
    {
        oper[counter] = input[i];
        Console.Write(oper[counter]);
        counter++;
    }
}

Console.WriteLine();

string[] sentences = input.Split(new []{'.','!','?'}, StringSplitOptions.RemoveEmptyEntries);
counter = 0;

for (int i = 0; i < sentences.Length; i++)
{
    sentences[i] = sentences[i].Trim();
    if (!string.IsNullOrEmpty(sentences[i]))
    {
        sentences[i] = char.ToUpper(sentences[i][0]) + sentences[i].Substring(1);
        Console.Write($"{sentences[i]}{oper[counter++]} ");
    }
    else
    {
        counter++;
    }
}

// Task 7

string poem = @"
    To be, or not to be, that is the question,
    Whether 'tis nobler in the mind to suffer
    The slings and arrows of outrageous fortune,
    Or to take arms against a sea of troubles,
    And by opposing end them? To die: to sleep;
    No more; and by a sleep to say we end
    The heart-ache and the thousand natural shocks
    That flesh is heir to, 'tis a consummation
    Devoutly to be wish'd. To die, to sleep";
    
string changedPoem = poem.Replace("die","***");
Console.WriteLine(changedPoem);
    