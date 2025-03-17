namespace NET_Classes_Objects;

class Program
{
    static void Main(string[] args)
    {
        MyClass myClass = new MyClass();
        // Task 1
        
        /*
        Console.Write("Enter simbol: ");
        char simbol = Convert.ToChar(Console.ReadLine()!);
        Console.Write("Enter size of square: ");
        int sizeOfSquare = Convert.ToInt32(Console.ReadLine());
        myClass.Square('*', 5);*/
        
        // Task 2

        /*Console.Write("Enter your number to check if it is a palindrome: ");
        string palindrome = Console.ReadLine()!;
        Console.WriteLine(myClass.PalindromeCheck(palindrome));*/
        
        
        // Task 3 
        
        /*int [] mas = myClass.MassiveFilter(new []{1,2,6,-1,88,7,6,18}, new []{6,88,7});
        foreach (int m in mas) Console.Write(m + " ");*/
       
        
        // Task 4
        
        /*WebSite website = new WebSite("Metanit","metanit.com","booking","127.0.0.1");
        website.OutputData();   
        website.Description = "directory";
        website.OutputData();*/
        
        
        // Task 5

        /*Magazine magazine = new Magazine("Euronews",2005,"Sport","+999999999","hello15@gmail.com");
        magazine.OutputData();
        magazine.PhoneNumber = "88005553535";
        magazine.OutputData();*/

        // Task 6

        /*Store store = new Store("Araz","Baku","Grocery", "1545112","arazstore12@gmail.com");
        store.OutputData();
        store.PhoneNumber = "55555555";
        store.OutputData();*/
    }
}