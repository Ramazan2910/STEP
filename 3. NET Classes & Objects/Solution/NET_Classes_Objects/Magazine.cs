namespace NET_Classes_Objects;

public class Magazine
{
    public Magazine(string nameOfMagazine,int yearOfFoundation, string descriptionOfMagazine, string phoneNumber, string email)
    {
        NameOfMagazine = nameOfMagazine;
        YearOfFoundation = yearOfFoundation;
        DescriptionOfMagazine = descriptionOfMagazine;
        PhoneNumber = phoneNumber;
        Email = email;
    }
    
    public string? NameOfMagazine { get; set; }
    public int YearOfFoundation { get; set; }
    public string? DescriptionOfMagazine { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    
    
    public void OutputData()
    {
        Console.WriteLine($"Name of the Magazine: {NameOfMagazine}");
        Console.WriteLine($"Year of the Foundation: {YearOfFoundation}");
        Console.WriteLine($"Description of the Magazine: {DescriptionOfMagazine}");
        Console.WriteLine($"Phone Number: {PhoneNumber}");
        Console.WriteLine($"Email: {Email}");
    }
}