namespace Exam;

public interface IPasswordHelper
{
    static abstract string HassPassword(string password);
    static abstract bool VerifyPassword(string password, string hash);
    
}