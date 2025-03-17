using System.Text.Json;

namespace Exam;

public class Registration: IRegistration
{
    private string _adminLogInPasswordFile = "AdminLogInPassword.json";
    private string _userLogInPasswordFile = "UserLogInPasswordFile.json";
    
    public void Register(int mode, string[] registrationData)
    {
        if (mode == 1)
        {
            Admin tempAdmin = new Admin(registrationData[0], registrationData[1], registrationData[2], Convert.ToInt32(registrationData[3]), registrationData[4], PasswordHelper.HassPassword(registrationData[5]));
            
            List<Admin> admins = new List<Admin>();
            if (File.Exists(_adminLogInPasswordFile))
            {
                string json = File.ReadAllText(_adminLogInPasswordFile);
                admins = JsonSerializer.Deserialize<List<Admin>>(json) ?? new List<Admin>();
            }
            
            // Unique Login checking 
            foreach (var admin in admins)
                if(admin.LogIn == registrationData[4])throw new Exception("Login already exists !");
            
            // Adding new Admin
            admins.Add(tempAdmin);
            string jsonString = JsonSerializer.Serialize(admins);
            File.WriteAllText(_adminLogInPasswordFile, jsonString);
        }
        else if (mode == 2)
        {
            User tempUser = new User(registrationData[0], registrationData[1], registrationData[2], Convert.ToInt32(registrationData[3]), registrationData[4], PasswordHelper.HassPassword(registrationData[5]));
            
            List<User> users = new List<User>();
            if (File.Exists(_userLogInPasswordFile))
            {
                string json = File.ReadAllText(_userLogInPasswordFile);
                users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            }

            // Unique Login checking 
            foreach (var user in users) 
                if (user.LogIn == registrationData[4]) throw new ArgumentException("Login already exists !");
            
            // Adding new User
            users.Add(tempUser);
            string jsonString = JsonSerializer.Serialize(users);
            File.WriteAllText(_userLogInPasswordFile, jsonString);
            
        }
    }
}