namespace Exam;

public interface IStatistics
{
    string CategoryName { get; set; }
    string TestName { get; set; }
    string UserLogin { get; set; }
    int CountOfCorrectAnswers { get; set; }
    int CountOfAllAnswers { get; set; }
    double Score { get; set; }

    void RecordStatistics();
    List<Statistics> GetUserStatistics(string login);
    void DeleteStatistics(string filter, int mode,string additionalFilter);
    void EditStatistics(string oldLogin, string newLogin);
    List<Statistics> GetAllStatistics();

}