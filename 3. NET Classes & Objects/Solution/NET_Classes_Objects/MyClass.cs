namespace NET_Classes_Objects;

public class MyClass
{
    public void Square(char simbol, int sizeOfSquare)
    {
        for (int i = 0; i < sizeOfSquare; i++)
        {
            for (int j = 0; j < sizeOfSquare; j++)
            {
                Console.Write(simbol+" ");
            }
            Console.WriteLine();
        }
    }

    public bool PalindromeCheck(string palindrome)
    {
        int reverse = palindrome.Length - 1;
        for (int i = 0; i < palindrome.Length/2; i++)
        {
            if (palindrome[i] != palindrome[reverse--]) return false;
        }
        return true;
    }

    public int[] MassiveFilter(int [] original, int [] filter)
    {
        int counter = 0;
        int[] temp = new int[original.Length];
        for (int i = 0; i < original.Length; i++)
        {
            bool flag = true;
            for (int j = 0; j < filter.Length; j++)
            {
                if (original[i] == filter[j]) {
                    flag = false;
                    break;
                }
            }
            if (flag) temp[counter++] = original[i];
        }
        
        original = new int[counter];
        for (int i = 0; i < counter; i++)
        {
            original[i] = temp[i];
        }
        
        return original;
    }
}