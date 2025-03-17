using System.Text;
using System.Text.Json;

namespace Exam;

public class Test: ITest
{
    public string Title { get; set; }
    public List<TestQuestion> Questions { get; set; }
    public int CountOfQuestions { get; set; }
    
    private static string _stoppedTest = ".StoppedTest";

    public Test(){}
    public Test(string title, List<TestQuestion> questions, int countOfQuestions)
    {
        Title = title;
        Questions = questions;
        CountOfQuestions = countOfQuestions;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Title: {Title}");
        sb.AppendLine($"Count of Questions: {CountOfQuestions}");
        sb.AppendLine("Questions:");

        for (int i = 0; i < Questions.Count; i++)
        {
            sb.AppendLine($"  {i + 1}. {Questions[i]}");
        }

        return sb.ToString();
    }

    public static Test operator +(Test test, Test newTest)
    {
        Test concatenatedTest  = new Test
        {
            Title = test.Title,
            CountOfQuestions = test.CountOfQuestions + newTest.CountOfQuestions,
            Questions = new List<TestQuestion>()
        };
        
        for (int i = 0; i < test.CountOfQuestions; i++)
            concatenatedTest.Questions.Add(test.Questions[i]);
        
        for (int i = 0; i < newTest.CountOfQuestions; i++)
            concatenatedTest.Questions.Add(newTest.Questions[i]);
        
        return concatenatedTest;
    }
    
    
    
    public static Test GetTest(string filePath)
    {
        string json = File.ReadAllText(filePath);
        var test = JsonSerializer.Deserialize<Test>(json);
        
        return test;
    }

    public static void StopTest(string login, string testName, string[] userAnswers, int questionPosition)
    {
        if(!Directory.Exists(_stoppedTest)) Directory.CreateDirectory(_stoppedTest);
        
        string filePath = _stoppedTest + "\\" + testName + login +".json";

       StoppedTest stoppedTest = new StoppedTest(questionPosition, userAnswers);
       
       string json = JsonSerializer.Serialize(stoppedTest);
       File.WriteAllText(filePath, json);
    }

    public static StoppedTest ContinueTest(string login, string testName)
    {
        string filePath = _stoppedTest + "\\" + testName+ login + ".json";
        if (!File.Exists(filePath)) return null;
        
        
        string json = File.ReadAllText(filePath);
        StoppedTest? stoppedTest = JsonSerializer.Deserialize<StoppedTest>(json)??new StoppedTest();
        
        File.Delete(filePath);
        return stoppedTest;
    }
    
}