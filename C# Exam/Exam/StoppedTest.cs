namespace Exam;

public class StoppedTest: IStoppedTest
{
    public int CurrentPosition { get; set; }
    public string[] UserAnswers { get; set; }
    
    public StoppedTest(){}

    public StoppedTest(int currentPosition, string[] userAnswers)
    {
        CurrentPosition = currentPosition;
        UserAnswers = userAnswers;
    }
    
    
}