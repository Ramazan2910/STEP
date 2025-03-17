using System.Text;

namespace Exam;
using System.Security.Cryptography;

public class PasswordHelper:IPasswordHelper
{

    public static string HassPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashedBytes = sha256.ComputeHash(passwordBytes);

            StringBuilder hashstring = new StringBuilder();
            foreach (var b in hashedBytes) hashstring.Append(b.ToString("x2"));
            
            return hashstring.ToString();
        }
    }

    public static bool VerifyPassword(string password, string hash)
    {
        string passwordHash = HassPassword(password);
        return passwordHash == hash;
    }
    
    
}