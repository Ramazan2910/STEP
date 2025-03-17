namespace NET_Operator_Overloading_User_Defined_Conversions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            MyList list1 = new MyList(new List<int>(){50,10,30,40,70});
            MyList list2 = new MyList(new List<int>(){50,20,90,40});
        
            MyList list3 = list1 + list2;
            Console.Write("Addition: ");
            for (int i = 0; i < list3.Length(); i++)
                Console.Write(list3[i] + " ");

            Console.WriteLine();
            
            list3 = list1 - list2;
            Console.Write("Subtraction: ");
            for (int i = 0; i < list3.Length(); i++)
                Console.Write(list3[i] + " ");

            Console.WriteLine();

            list3 = list2 * 2;
            Console.Write("Multiplication: ");
            for (int i = 0; i < list3.Length(); i++)
                Console.Write(list3[i] + " ");

            Console.WriteLine();
            
            Console.Write("Division: ");
            _ = list3 / 4;
            
            Console.WriteLine();

            if(list1 == list2) Console.WriteLine("Lists are equal");
            else if (list1 != list2) Console.WriteLine("Lists are not equal");
            
            if(list1) Console.WriteLine("Lists is not empty");

            Console.Write("Array: ");
            int[] temp = list1;
            foreach (int i in temp) Console.Write(i + " ");
            
            Console.WriteLine();

            Console.Write("Common elements: ");
            list3 = list1 & list2;
            for (int i = 0; i < list3.Length(); i++)
                Console.Write(list3[i] + " ");
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
        }
        
        
        
    }
}