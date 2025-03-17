using System.Text.Json;

namespace Exam;

public class Statistics: IStatistics
{
    public string CategoryName { get; set; }
    public string TestName { get; set; }
    public string UserLogin { get; set; }
    
    public int CountOfCorrectAnswers { get; set; }
    public int CountOfAllAnswers { get; set; }
    public double Score { get; set; }

    
    
    private string _statisticsFilePath = "StatisticsFile.json";
    
    public Statistics(){}

    public Statistics(string categoryName, string testName, string userLogin, int countOfCorrectAnswers, int countOfAllAnswers ,double score)
    {
        CategoryName = categoryName;
        TestName = testName;
        UserLogin = userLogin;
        CountOfCorrectAnswers = countOfCorrectAnswers;
        CountOfAllAnswers = countOfAllAnswers;
        Score = score;
    }

    public override string ToString()
    {
        return $"Category: {CategoryName} | Test: {TestName} | User: {UserLogin} | Ratio of correct answers to all: {CountOfCorrectAnswers}/{CountOfAllAnswers} | Score: {Score}";
    }

    public void RecordStatistics()
    {
        List<Statistics> statsList = GetAllStatistics();
        
        
        statsList.Add(this);
        string newJson = JsonSerializer.Serialize(statsList);
        File.WriteAllText(_statisticsFilePath, newJson);
    }

    public List<Statistics> GetUserStatistics(string login)
    {
        List<Statistics> allStats = GetAllStatistics();
        
        if(allStats == null || !allStats.Any()){throw new NullReferenceException("Statistics are missing!");}

        var userStats = new List<Statistics>();

        foreach (var stats in allStats)
            if (stats.UserLogin == login) { userStats.Add(stats); }
        
        return userStats;
    }

    public void DeleteStatistics(string filter, int mode, string additionalFilter)
    {
        List<Statistics> allStats = GetAllStatistics();
        
        if(allStats == null || !allStats.Any()){throw new NullReferenceException("Statistics are missing!");}
        
        List<Statistics> newStats = new List<Statistics>();

        if (mode == 1)
        {
            foreach (var stat in allStats)
            {
                if(stat.CategoryName == filter){ continue;}
                newStats.Add(stat);
            }
        }
        else if (mode == 2)
        {
            foreach (var stat in allStats)
            {
                if(stat.TestName == filter && stat.CategoryName == additionalFilter){ continue;}
                newStats.Add(stat);
            }
        }
        else if (mode == 3)
        {
            foreach (var stat in allStats)
            {
                if(stat.UserLogin == filter){ continue;}
                newStats.Add(stat);
            }
        }
        
        string json = JsonSerializer.Serialize(newStats);
        File.WriteAllText(_statisticsFilePath, json);
    }

    public void EditStatistics(string oldLogin, string newLogin)
    {
        List<Statistics> allStats = GetAllStatistics();
        
        if(allStats == null || !allStats.Any()){throw new NullReferenceException("Statistics are missing!");}

        for (int i = 0; i < allStats.Count; i++)
        {
            if(allStats[i].UserLogin == oldLogin)
                allStats[i].UserLogin = newLogin;
        }
        
        string json = JsonSerializer.Serialize(allStats);
        File.WriteAllText(_statisticsFilePath, json);
    }
    
    public List<Statistics> GetAllStatistics()
    {
        List<Statistics> statsList = new List<Statistics>();
            
        if (File.Exists(_statisticsFilePath))
        {
            string json = File.ReadAllText(_statisticsFilePath);
            statsList = JsonSerializer.Deserialize<List<Statistics>>(json) ?? new List<Statistics>();
        }

        return statsList;
    }
}