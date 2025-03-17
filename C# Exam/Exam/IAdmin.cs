namespace Exam;

public interface IAdmin
{
    
    // Modify User Part
    
    static abstract void DeleteUser(string filePath, string userLogin, List<User> usersList);
    static abstract void EditUser(string filePath, string userLogin, User newUser);
    
    // User Statistics Part
    
    static abstract List<Statistics> ByScore(int mode);
    static abstract List<Statistics> ByCategory(string category);
    static abstract List<Statistics> ByTest(string categoryName,string test);
    
    // Test Part
    
    static abstract bool AddCategory(string categoryName);
    static abstract bool DeleteCategory(string categoryName);
    static abstract void AddTest(string filePath, Test test);
    static abstract void DeleteTest(string filePath, string testName, string categoryName);
    static abstract void EditTest(string filePath, Test newTest);
    static abstract Test GetTest(string filePath);
    
}