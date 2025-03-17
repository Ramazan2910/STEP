namespace NET_Classes_Objects;

public class Store
{
    public Store(string nameOfStore,string address,string descriptionOfStoreProfile, string phoneNumber, string email)
    {
        NameOfStore = nameOfStore;
        Address = address;
        DescriptionOfStoreProfile = descriptionOfStoreProfile;
        PhoneNumber = phoneNumber;
        Email = email;
    }
    
    public string? NameOfStore{ get; set; }
    public string? Address { get; set; }
    public string? DescriptionOfStoreProfile { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }


    public void OutputData()
    {
        Console.WriteLine($"Name of store: {NameOfStore}");
        Console.WriteLine($"Address: {Address}");
        Console.WriteLine($"Description of store: {DescriptionOfStoreProfile}");
        Console.WriteLine($"Phone number: {PhoneNumber}");
        Console.WriteLine($"Email: {Email}");
    }
    
    
}