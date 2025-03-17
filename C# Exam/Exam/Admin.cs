using System.Text.Json;
using System.Text.Json.Serialization;

namespace Exam;

public class Admin: IHuman,IAdmin
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string FatherName { get; set; }
    public int Age { get; set; }
    public string LogIn { get; set; }
    public string Password { get; set; }

    public Admin() { }
    public Admin(string name, string surname, string fathername, int age, string logIn, string password)
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
        return $"Name: {Name}, Surname: {Surname}, Father name: {FatherName}, Age: {Age}, Login: {LogIn}, Password: {Password}";
    }
    
    // Modify User Part
    
    public static void DeleteUser(string filePath, string userLogin, List<User> usersList)
    {
        Statistics st = new Statistics();
        var newUsersList = new List<User>();
        
        foreach (var user in usersList)
        {
            if (user.LogIn == userLogin) continue;
            newUsersList.Add(user);
        }
        
        string json = JsonSerializer.Serialize(newUsersList);
        File.WriteAllText(filePath, json);
        st.DeleteStatistics(userLogin,3,"");
    }

    public static void EditUser(string filePath, string userLogin, User newUser)
    {
        Statistics st = new Statistics();
        var usersList = User.GetUsers(filePath);

        for (int i = 0; i < usersList.Count; i++)
        {
            if(usersList[i].LogIn == userLogin) usersList[i] = newUser;
        }
        
        string json = JsonSerializer.Serialize(usersList);
        File.WriteAllText(filePath, json);
        st.EditStatistics(userLogin, newUser.LogIn);
    }
    
    
    
    
    // User Statistics Part
    
    public static List<Statistics> ByScore(int mode)
    {
        Statistics st = new Statistics();
        var statsList = st.GetAllStatistics();
        
        if(statsList == null || !statsList.Any()){throw new NullReferenceException("Statistics are missing!");}

        if (mode == 1) { statsList = new List<Statistics>(statsList.OrderBy(stat => stat.Score)); }
        else if (mode == 2) { statsList = new List<Statistics>(statsList.OrderByDescending(stat => stat.Score)); }
        
        return statsList;
    }

    public static List<Statistics> ByCategory(string category)
    {
        Statistics st = new Statistics();
        var statsList = st.GetAllStatistics();
        if(statsList == null || !statsList.Any()){throw new NullReferenceException("Statistics are missing!");}
        
        var newStatsList = new List<Statistics>();

        foreach (var stat in statsList)
            if(stat.CategoryName == category) newStatsList.Add(stat);
        
        return newStatsList;
    }
    
    public static List<Statistics> ByTest(string categoryName,string test)
    {
        Statistics st = new Statistics();
        var statsList = st.GetAllStatistics();
        
        if(statsList == null || !statsList.Any()){throw new NullReferenceException("Statistics are missing!");}
        
        var newStatsList = new List<Statistics>();

        foreach (var stat in statsList)
            if(stat.CategoryName == categoryName && stat.TestName == test) newStatsList.Add(stat);
        
        return newStatsList;
    }
    
    
    // Test part
    public static bool AddCategory(string categoryName)
    {
        if (Directory.Exists(categoryName)) throw new InvalidOperationException($"Category {categoryName} already exists!");
        Directory.CreateDirectory(categoryName);
        return true;
    }

    public static bool DeleteCategory(string categoryName)
    {
        Statistics st = new Statistics();
        if (!Directory.Exists(categoryName)) throw new InvalidOperationException($"Category {categoryName} does not exist!");
        Directory.Delete(categoryName, true);
        st.DeleteStatistics(categoryName, 1,"");
        return true;
    }

    public static void AddTest(string filePath, Test test)
    {
        string json = JsonSerializer.Serialize(test);
        File.WriteAllText(filePath, json);
    }

    public static void DeleteTest(string filePath, string testName, string categoryName)
    {
        Statistics st = new Statistics();
        File.Delete(filePath);
        st.DeleteStatistics(testName,2,categoryName);
    }

    public static void EditTest(string filePath, Test newTest)
    {
        string json = File.ReadAllText(filePath);
        var test = JsonSerializer.Deserialize<Test>(json);

        if (test != null)
        {
            Test concatTest = test + newTest; 
            string newJson = JsonSerializer.Serialize(concatTest);
            File.WriteAllText(filePath, newJson);
        }
    }
    
    public static Test GetTest(string filePath)
    {
        string json = File.ReadAllText(filePath);
        var test = JsonSerializer.Deserialize<Test>(json);

        return test;
    }
}