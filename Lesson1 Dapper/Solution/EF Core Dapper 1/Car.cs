namespace EF_Core_Dapper_1;

public class Car
{
    public string Brand{ get; set; }
    public string Model{ get; set; }
    public int Year{ get; set; }
    public float Price{ get; set; }


    public override string ToString()
    {
        return $"{Brand},{Model},{Year},{Price}";
    }

    public Car (){}
    public Car(string brand, string model, int year, float price) { Brand = brand; Model = model; Year = year; Price = price; }
}