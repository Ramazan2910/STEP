namespace NET_Operator_Overloading_User_Defined_Conversions;

public class MyList
{
    public List<int> IntList { get; set; }
    public MyList(List<int> intList)
    {
        IntList = intList;
    }

    public MyList(int size)
    {
        IntList = new List<int>(size);
        for (int i = 0; i < size; i++)
        {
            IntList.Add(0);
        }
    }
    
    public static MyList operator +(MyList list1, MyList list2)
    {
        MyList newList = new MyList(list1.IntList.Concat(list2.IntList).ToList());
        return newList;
    }

    public static MyList operator -(MyList list1, MyList list2)
    {
        MyList newList = new MyList(list1.IntList.Except(list2.IntList).ToList());
        return newList;
    }

    public static MyList operator *(MyList list, int factor)
    {
        MyList newList = list;
        for (int i = 0; i < factor - 1; i++)
            newList = newList + list;
        
        return newList;
    }

    public static int operator /(MyList list, int divider)
    {
        if (list.Length() % divider != 0)
        {
            throw new ArgumentOutOfRangeException(null,"Cannot divide MyList");
        }
        else
        {
            int newSize = list.Length() / divider;
            int countOfIteration = 1;
            int boarder = 0;
            while (countOfIteration <= divider)
            {
                int insideCounter = 0;
                MyList newList = new MyList(newSize);
                Console.Write("{ ");
                for (int i = boarder; i < newSize * countOfIteration; i++)
                {
                    newList[insideCounter] = list[i];
                    Console.Write(newList[insideCounter++] + " ");
                }
                Console.Write("}, ");
                boarder = newSize * countOfIteration;
                countOfIteration++;
            }
        }

        return 1;
    }
    

    public static bool operator ==(MyList list1, MyList list2)
    {
        return list1.IntList.SequenceEqual(list2.IntList);
    }

    public static bool operator !=(MyList list1, MyList list2)
    {
        return !(list1 == list2);
    }

    public int this[Index index]
    {
        get { return IntList[index]; }
        set { IntList[index] = value; }
    }
    
    public MyList this[Range range] => new MyList(IntList[range.Start..range.End]);


    public static bool operator true(MyList list)
    {
        return list.Length() != 0;
    }

    public static bool operator false(MyList list)
    {
        return list.Length() == 0;
    }

    public static implicit operator int[](MyList list)
    {
        return list.IntList.ToArray();
    }

    public static MyList operator &(MyList list1, MyList list2)
    {
        // Это на всякий случай :)
        /*int[] temp = new int[list1.Length()];
        int counter = 0;
        for (int i = 0; i < list1.Length(); i++)
        {
            for (int j = 0; j < list2.Length(); j++)
            {
                if (list1[i] == list2[j])
                {
                    temp[counter] = list1[i];
                    counter++;
                    break;
                }
            }
        }
        
        MyList newlist = new MyList(counter);
        for (int i = 0; i < counter; i++)
        {
            newlist[i] = temp[i];
        }
        
        return newlist;*/
        
        return new MyList(list1.IntList.Intersect(list2.IntList).ToList());
    }

    public int Length(){return IntList.Count;}
    
    
}