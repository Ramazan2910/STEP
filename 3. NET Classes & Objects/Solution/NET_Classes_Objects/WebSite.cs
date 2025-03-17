namespace NET_Classes_Objects;

public class WebSite
{
    public WebSite(string nameOfWebSite,string url,string description,string ipAddress)
    {
        NameOfWebSite = nameOfWebSite;
        Url = url;
        Description = description;
        IpAddress = ipAddress;
    }
    
    public string NameOfWebSite { get; set; }
    public string Url { get; set; }
    public string Description { get; set; }
    public string IpAddress { get; set; }
    
    public void OutputData()
    {
        Console.WriteLine($"Name of the website: {NameOfWebSite}");
        Console.WriteLine($"Url of the website: {Url}");
        Console.WriteLine($"Description of the website: {Description}");
        Console.WriteLine($"IP address of the website: {IpAddress}");
    }
}