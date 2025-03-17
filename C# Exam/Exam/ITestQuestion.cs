namespace Exam;

public interface ITestQuestion
{
    string Question { get; set; }
    List<string> Answers { get; set; }
    string CorrectAnswer { get; set; }
}