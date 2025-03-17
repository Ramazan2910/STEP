using System.Text.Json;

namespace Exam;

public class Login
{
    private string _adminLogInPasswordFile = "AdminLogInPassword.json";
    private string _userLogInPasswordFile = "UserLogInPasswordFile.json";


    public bool CheckOfLoginAndPassword(int mode, string login, string password)
    {
        if (mode == 1)
        {
            if(!File.Exists(_adminLogInPasswordFile)) throw new FileNotFoundException("There is not a single admin in the system !");

            string json = File.ReadAllText(_adminLogInPasswordFile);
            var admins = JsonSerializer.Deserialize<List<Admin>>(json) ?? new List<Admin>();

            foreach (var admin in admins)
            {
                if (admin.LogIn == login && PasswordHelper.VerifyPassword(password,admin.Password))
                    return true;
            }
            throw new FormatException("Wrong Login or Password!");
        }

        if (mode == 2)
        {
            if(!File.Exists(_userLogInPasswordFile)) throw new FileNotFoundException("There is not a single user in the system !");

            string json = File.ReadAllText(_userLogInPasswordFile);
            var users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();

            foreach (var user in users)
            {
                if (user.LogIn == login && PasswordHelper.VerifyPassword(password,user.Password))
                    return true;
            }
            throw new FormatException("Wrong Login or Password !");
        }
        return false;
    }
}