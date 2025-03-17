namespace Exam;

public interface ITest
{
    
    string Title { get; set; }
    List<TestQuestion> Questions { get; set; }
    int CountOfQuestions { get; set; }
    
    
    static abstract Test GetTest(string filePath);
    static abstract void StopTest(string login, string testName, string[] userAnswers, int questionPosition);
    static abstract StoppedTest ContinueTest(string login, string testName);

}