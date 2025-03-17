using System.Text.Json;

namespace Exam;

public class User: IHuman,IUser
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string FatherName { get; set; }
    public int Age { get; set; }
    public string LogIn { get; set; }
    public string Password { get; set; }
    
    public User() {}
    
    public User(string name, string surname, string fathername, int age, string logIn, string password)
    {
        Name = name;
        Surname = surname;
        FatherName = fathername;
        Age = age;
        LogIn = logIn;
        Password = password;
    }
    
    public override string ToString()
    {
        return $"Name: {Name}, Surname: {Surname}, Father name: {FatherName}, Age: {Age}, Login: {LogIn}";
    }
    
    public static List<User> GetUsers(string filePath)
    {
        List<User> users = new List<User>();

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            users = JsonSerializer.Deserialize<List<User>>(json)?? new List<User>();
        }
        return users;
    }
    
}