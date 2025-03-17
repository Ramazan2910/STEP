namespace Exam;

interface IValidator
{ 
    static abstract void IsCorrectNaming(string word);
    static abstract int IsCorrectDigit(string digit);
    static abstract bool IsCorrectAnswer(string answer);
    static abstract bool IsStringNotNullOrEmpty(string answer);

    
    bool CheckName(string name, int mode);
    bool CheckAge (string age);
    bool CheckLogin (string login);
    bool CheckPassword (string password);
}