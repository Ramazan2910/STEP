namespace Exam;

public interface ILogin
{
    bool CheckOfLoginAndPassword(int mode, string login, string password);
}