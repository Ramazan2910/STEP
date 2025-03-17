namespace Exam;

public class TestQuestion: ITestQuestion
{
    public string Question { get; set; }
    public List<string> Answers { get; set; }
    public string CorrectAnswer { get; set; }
    
    public TestQuestion(){}

    public TestQuestion(string question, List<string> answers, string correctAnswer)
    {
        Question = question;
        Answers = answers;
        CorrectAnswer = correctAnswer;
    }

    public override string ToString()
    {
        string answers = string.Join(", ", Answers);

        return $"Question: {Question}\nAnswers: [{answers}]\nCorrect Answer: {CorrectAnswer}";
    }

}