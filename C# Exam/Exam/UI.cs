namespace Exam;
class Ui
{
    private string _adminLogInPasswordFile = "AdminLogInPassword.json";
    private string _userLogInPasswordFile = "UserLogInPasswordFile.json";
    private string _stoppedTest = ".StoppedTest";

    // Cleaning console methods 
    public static void ClearAndWait() { Console.ReadKey(); Console.Clear(); }
    public static void OnlyClear() { Console.Clear(); }
    
    /*private delegate void CleaningDelegate();*/
    
    private void HighlightAWord(string word)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(word);
        Console.ResetColor();
    }
    
    
    // Program starting method
    
    public void Run()
    {
        bool flag = true;
        while (flag)
        {
            try
            {
                if (!Directory.Exists(_stoppedTest)) Directory.CreateDirectory(_stoppedTest);
                int accountType = Validator.IsCorrectDigit(AccountTypeSelection());

                OnlyClear();

                if (accountType == 1)
                {
                    //Log in or Sign up
                    string signUpOrLogin = SignUpOrLogIn(accountType);
                    while (signUpOrLogin == " ") { signUpOrLogin = SignUpOrLogIn(accountType); }

                    if (signUpOrLogin == "3") continue;

                    ClearAndWait();
                    // Admin main menu
                    AdminMainMenu();
                }
                else if (accountType == 2)
                {
                    //Log in or Sign up
                    string signUpOrLogin = SignUpOrLogIn(accountType);
                    while (signUpOrLogin == " ") { signUpOrLogin = SignUpOrLogIn(accountType); }

                    if (signUpOrLogin == "3") continue;

                    ClearAndWait();
                    // User main menu
                    UserMainMenu(signUpOrLogin);
                }
                else if (accountType == 3) flag = false; 
                else OnlyClear();
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                ClearAndWait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); 
                ClearAndWait();
            }
        }
    }
    
    
    // Beginning of Common Part 
    
    private string AccountTypeSelection()
    {
        InscriptionsAndSigns.TestingSystem();
        Console.WriteLine("Accounts menu");
        InscriptionsAndSigns.DashedLine();
        Console.WriteLine("1.Admin");
        Console.WriteLine("2.User");
        Console.WriteLine("3.Exit");
        Console.Write("Select type of account: ");
        return Console.ReadLine() ?? string.Empty;
    }
    
    
    // Sig up or Log in Part
    
    private string SignUpOrLogIn(int mode)
    {
        string[] expressions = new []{"Admin","User"};
        try
        {
            InscriptionsAndSigns.TestingSystem();
            Console.WriteLine("Sign up or log in menu");
            InscriptionsAndSigns.DashedLine();
            Console.WriteLine("1.Sign up");
            Console.WriteLine("2.Log in");
            Console.WriteLine("3.Exit");
            Console.Write("Your choice: ");
            int signUpOrLogIn = Validator.IsCorrectDigit(Console.ReadLine() ?? string.Empty);

            switch (signUpOrLogIn)
            {
                case 1:
                    string[] registration = SignUpPanel();
                    Registration reg = new Registration();
                    reg.Register(mode, registration);
                    Console.WriteLine($"{expressions[mode - 1]} successfully registered !");
                    return registration[4];
                case 2:
                    string[] loginPassword = LoginPanel();
                    Validator validator = new Validator();
                    if (validator.CheckLogin(loginPassword[0]) && validator.CheckPassword(loginPassword[1]))
                    {
                        Login loginCheck = new Login();
                        if (loginCheck.CheckOfLoginAndPassword(mode, loginPassword[0], loginPassword[1]))
                            Console.WriteLine($"{expressions[mode - 1]} successfully logged in !");
                        return loginPassword[0];
                    }
                    ClearAndWait();
                    return " ";
                case 3:
                    OnlyClear();
                    return "3";
                default:
                    OnlyClear();
                    break;
            }
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
            ClearAndWait();
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
            ClearAndWait();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message); 
            ClearAndWait();
        }
        return " ";
    }
    private string[] SignUpPanel()
    {
        Validator validator = new Validator();
            
        string name;
        do
        {
            Console.Write("Enter name: ");
            name = Console.ReadLine() ?? string.Empty;
        } while (!validator.CheckName(name,0));

            
        string surname;
        do
        {
            Console.Write("Enter surname: ");
            surname = Console.ReadLine() ?? string.Empty;
        } while (!validator.CheckName(surname,1));
            
            
        string father;
        do
        {
            Console.Write("Enter father name: ");
            father = Console.ReadLine() ?? string.Empty;
        } while (!validator.CheckName(father,2));
            
            
        string age;
        do
        {
            Console.Write("Enter age: ");
            age = Console.ReadLine() ?? string.Empty;
        } while (!validator.CheckAge(age));
            
        string login;
            
        Console.Write("Login: 4–16 characters, must include at least one number, letters, numbers, underscores. For example: ");
        HighlightAWord("user_123\n");
        do
        {
            Console.Write("Enter login: ");
            login = Console.ReadLine()?? string.Empty;
        } while (!validator.CheckLogin(login));
            
            
        string password;
            
        Console.Write("Password: 8–20 characters, at least 1 letter, 1 number, 1 special character For Example: ");
        HighlightAWord("Password@1\n");
        do
        {
            Console.Write("Enter password: ");
            password = Console.ReadLine() ?? string.Empty;
        } while (!validator.CheckPassword(password));
            
        return new [] { name, surname, father, age, login, password };
    }
    private string[] LoginPanel()
    {
        Console.Write("Enter login: ");
        string login = Console.ReadLine() ?? string.Empty;
        Console.Write("Enter password: ");
        string password = Console.ReadLine() ?? string.Empty;
        
        return new []{login,password};
    }
    
    // Ending of common Part
    
    
    // User Part
    
    
    private void UserMainMenu(string login)
    {
        
        bool userFlag = true;
        while (userFlag)
        {
            try
            {
                int userChoiceMainMenu = Validator.IsCorrectDigit(UserChoiceMainMenu());
                

                if (userChoiceMainMenu == 1)
                {
                    TakeTestMenu(login);
                    ClearAndWait();
                }
                else if (userChoiceMainMenu == 2)
                {
                    ShowUserStatistics(login);
                    ClearAndWait();
                }
                else if (userChoiceMainMenu == 3)
                {
                    userFlag = false; 
                    OnlyClear();
                }
                else OnlyClear();
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                ClearAndWait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); 
                ClearAndWait();
            }
        }
    }
    private string UserChoiceMainMenu()
    {
        InscriptionsAndSigns.UserPanel();
        Console.WriteLine("User menu");
        InscriptionsAndSigns.DashedLine();
        Console.WriteLine("1.Take the test");
        Console.WriteLine("2.See my test results");
        Console.WriteLine("3.Exit");
        Console.Write("Your choice: ");
        return Console.ReadLine() ?? string.Empty;
    }


    private void TakeTestMenu(string login)
    {
        try
        {
            string[] filePathAndFileName = GetFilePathAndFileNameAndCategoryName(2,true);
            string filePath = filePathAndFileName[0];
            string fileName = filePathAndFileName[1];
            string categoryName = filePathAndFileName[2];
        
            var test = Test.GetTest(filePath);
        
            var numbres = TakingTestMenu(test, login);
            double score = numbres[0];
            int correctAnswer = (int)numbres[1];
            
            Statistics stats = new Statistics(categoryName,fileName,login,correctAnswer,test.CountOfQuestions,score);
            Console.WriteLine($"\n{stats}\n");
            stats.RecordStatistics();
        }
        catch(ReturnToUserMainMenuxception e) { Console.WriteLine(e.Message); }
        catch(FormatException e){Console.WriteLine(e.Message);}
        catch(InvalidOperationException e) {Console.WriteLine(e.Message);}
        catch (Exception e) { Console.WriteLine(e); }
        
    }
    private double[] TakingTestMenu(Test test, string login)
    {
        StoppedTest stoppedTest = Test.ContinueTest(login, test.Title);
        
        string[] answersSimbols = new []{"A","B","C","D"};
        string[] userAnswers = new string[test.CountOfQuestions];
        int loopCount = 0;
        
        if (stoppedTest != null)
        {
            userAnswers = stoppedTest.UserAnswers;
            loopCount = stoppedTest.CurrentPosition;
        }
        
        Console.WriteLine(test.Title);

        for (int i = loopCount; i < test.CountOfQuestions; i++)
        {
            Console.WriteLine($"Question {i+1}: {test.Questions[i].Question}");
            for (int j = 0; j < 4; j++)
            {
                Console.WriteLine($"{answersSimbols[j]}.{test.Questions[i].Answers[j]}");
            }
            
            do
            {
                Console.Write("Choice answer: ");
                userAnswers[i] = Console.ReadLine()?? string.Empty;
                if (userAnswers[i] == "0")
                {
                    Test.StopTest(login, test.Title, userAnswers, i);
                    throw new ReturnToUserMainMenuxception("Test closing...");
                }
            } while (!Validator.IsCorrectAnswer(userAnswers[i]));
            userAnswers[i] = userAnswers[i].ToUpper();
        }

        int countOfCorrectAnswers = 0;
        for (int i = 0; i < test.CountOfQuestions; i++)
        {
            if(userAnswers[i] == test.Questions[i].CorrectAnswer) 
                countOfCorrectAnswers++;
        }
        
        double score = (12.0 * countOfCorrectAnswers) / test.CountOfQuestions;
        
        return [score , countOfCorrectAnswers];
    }
    
    
    private void ShowUserStatistics(string login)
    {
        try
        {
            Statistics stats = new Statistics();
            List<Statistics> userStatistics = stats.GetUserStatistics(login);
            
            InscriptionsAndSigns.DashedLine();
            Console.WriteLine("Your statistics: \n");
            
            for (int i = 0; i < userStatistics.Count; i++)
                Console.WriteLine($"{i+1}. {userStatistics[i]}");
            
        }
        catch (NullReferenceException e) { Console.WriteLine(e.Message); }
        catch (Exception e) { Console.WriteLine(e); }
    }

    
    
    // Admin Part
    
    private void AdminMainMenu()
    {
        bool adminFlag = true;
        while (adminFlag)
        {
            try
            {
                int adminMainMenu = Validator.IsCorrectDigit(AdminMainChoiceMenu());
                
                OnlyClear();
                
                if (adminMainMenu == 1)
                {
                    AdminModifyMenu();
                    OnlyClear();
                }
                else if (adminMainMenu == 2)
                {
                    AdminStatisticMenu();
                    OnlyClear();
                }
                else if (adminMainMenu == 3)
                {
                    AdminTestMenu();
                    OnlyClear();
                }
                else if (adminMainMenu == 4)
                {
                    adminFlag = false; 
                    OnlyClear();
                }
                else OnlyClear();
            }
            catch(FormatException e) { Console.WriteLine(e.Message); ClearAndWait();}
            catch (Exception e) { Console.WriteLine(e); ClearAndWait();}
        }
    }
    private string AdminMainChoiceMenu()
    {
        InscriptionsAndSigns.AdminPanel();
        Console.WriteLine("Admin main menu");
        InscriptionsAndSigns.DashedLine();
        Console.WriteLine("1.Modify user");
        Console.WriteLine("2.Show statistic");
        Console.WriteLine("3.Tests");
        Console.WriteLine("4.Exit");
        Console.Write("Your choice: ");
        return Console.ReadLine() ?? string.Empty;
    }

    // Admin User Modify Part
    
    private void AdminModifyMenu()
    {
        bool adminFlag = true;
        while (adminFlag)
        {
            try
            {
                int adminModifyMenu = Validator.IsCorrectDigit(AdminModifyChoiceMenu());
                switch (adminModifyMenu)
                {
                    case 1:
                        string[] registration = SignUpPanel();
                        Registration reg = new Registration();
                        reg.Register(2, registration);
                        Console.WriteLine("User successfully registered !");
                        ClearAndWait();
                        break;
                    case 2:
                        var users = User.GetUsers(_userLogInPasswordFile);
                        for (int i = 0; i < users.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {users[i].LogIn}");
                        }

                        Console.Write("Your choice: ");
                        int deleteUserCount = Validator.IsCorrectDigit(Console.ReadLine() ?? string.Empty) - 1;

                        if (deleteUserCount < 1 || deleteUserCount > users.Count)
                            throw new InvalidOperationException("User doesn't exist!");

                        Admin.DeleteUser(_userLogInPasswordFile, users[deleteUserCount].LogIn, users);
                        Console.WriteLine("User successfully deleted !");

                        ClearAndWait();
                        break;
                    case 3:
                        users = User.GetUsers(_userLogInPasswordFile);
                        for (int i = 0; i < users.Count; i++)
                            Console.WriteLine($"{i + 1}. {users[i].LogIn}");

                        Console.Write("Your choice: ");
                        deleteUserCount = Validator.IsCorrectDigit(Console.ReadLine() ?? string.Empty) - 1;

                        if (deleteUserCount < 0 || deleteUserCount > users.Count)
                            throw new InvalidOperationException("User doesn't exist!");

                        string oldUserLogin = users[deleteUserCount].LogIn;

                        User newUser = ChangingUser(users[deleteUserCount]);

                        Admin.EditUser(_userLogInPasswordFile, oldUserLogin, newUser);
                        Console.WriteLine("User successfully edited !");

                        ClearAndWait();
                        break;
                    case 4:
                        users = User.GetUsers(_userLogInPasswordFile);

                        if (users.Count <= 0) throw new InvalidOperationException("Users doesn't exist!");

                        Console.WriteLine();
                        for (int i = 0; i < users.Count; i++)
                            Console.WriteLine($"{i + 1}. {users[i]}");

                        Console.WriteLine();
                        ClearAndWait();
                        break;
                    case 5:
                        adminFlag = false;
                        break;
                    default:
                        OnlyClear();
                        break;
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                ClearAndWait();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                ClearAndWait();
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                ClearAndWait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ClearAndWait();
            }
        }
    }
    private string AdminModifyChoiceMenu()
    {
        InscriptionsAndSigns.AdminPanel();
        Console.WriteLine("Admin user modify menu");
        InscriptionsAndSigns.DashedLine();
        Console.WriteLine("1.Add user");
        Console.WriteLine("2.Delete user");
        Console.WriteLine("3.Edit user");
        Console.WriteLine("4.Show user");
        Console.WriteLine("5.Exit");
        Console.Write("Your choice: ");
        return Console.ReadLine()?? string.Empty;
    }
    private User ChangingUser(User user)
    {
        Validator validator = new Validator();
        bool adminFlag = true;
        try
        {
            while (adminFlag)
            {
                Console.WriteLine("\t\tModify panel");
                Console.Write("Enter ");
                HighlightAWord("0");
                Console.WriteLine(" if you don't want to change parameter!");
                bool flag = true;
                bool insideFlag = false;
                string name;
                do
                {
                    Console.Write("Change name: ");
                    name = Console.ReadLine()?? string.Empty;
                    if (name == "0"){ flag = false; break; }

                    insideFlag = validator.CheckName(name,0);
                    
                    if (name == user.Name)
                    {
                        Console.WriteLine("Enter new data!");
                        insideFlag = false;
                    }
                } while (!insideFlag);
                if(flag) user.Name = name;

                
                flag = true;
                insideFlag = false;
                string surname;
                do
                {
                    Console.Write("Change surname: ");
                    surname = Console.ReadLine()?? string.Empty;
                    if (surname == "0"){ flag = false; break; }

                    insideFlag = validator.CheckName(surname,1);
                    
                    if (surname == user.Surname)
                    {
                        Console.WriteLine("Enter new data!");
                        insideFlag = false;
                    }
                } while (!insideFlag);
                if(flag) user.Surname = surname;
                
                
                flag = true;
                insideFlag = false;
                string father;
                do
                {
                    Console.Write("Change father name: ");
                    father = Console.ReadLine()?? string.Empty;
                    if (father == "0"){ flag = false; break; }

                    insideFlag = validator.CheckName(father,2);
                    
                    if (father == user.FatherName)
                    {
                        Console.WriteLine("Enter new data!");
                        insideFlag = false;
                    }
                } while (!insideFlag);
                if(flag) user.FatherName = father;
                
                
                flag = true;
                insideFlag = false;
                string age;
                do
                {
                    Console.Write("Change age: ");
                    age = Console.ReadLine()?? string.Empty;
                    if (age == "0"){ flag = false; break; }
                    
                    insideFlag = validator.CheckAge(age);

                    if (insideFlag)
                    {
                        if (Convert.ToInt32(age) == user.Age)
                        {
                            Console.WriteLine("Enter new data!");
                            insideFlag = false;
                        }
                    }
                    
                } while (!insideFlag);
                if(flag) user.Age = Convert.ToInt32(age);
                
               
                flag = true;
                insideFlag = false;
                string login;
                do
                {
                    Console.Write("Change login: ");
                    login = Console.ReadLine()?? string.Empty;
                    if (login == "0"){ flag = false; break; }
                    
                    insideFlag = validator.CheckLogin(login);
                    
                    if (login == user.LogIn)
                    {
                        Console.WriteLine("Enter new data!");
                        insideFlag = false;
                    }
                } while (!insideFlag);
                if(flag) user.LogIn = login;
                
                
                flag = true;
                insideFlag = false;
                string password;
                do
                {
                    Console.Write("Change password: ");
                    password = Console.ReadLine()?? string.Empty;
                    if (password == "0"){ flag = false; break; }
                    
                    insideFlag = validator.CheckPassword(password);
                    
                    if (PasswordHelper.VerifyPassword(password, user.Password)) 
                    {
                        Console.WriteLine("Enter new data!");
                        insideFlag = false;
                    }
                } while (!insideFlag);
                if(flag) user.Password = PasswordHelper.HassPassword(password);
                
                return user;
            }
        }
        catch (FormatException e) { Console.WriteLine(e.Message); }
        catch (Exception e) { Console.WriteLine(e); }
        return null;
    }

    
    // Admin Statistics Part
    
     private void AdminStatisticMenu()
    {
        bool adminFlag = true;
        while (adminFlag)
        {
            try
            {
                int adminstatisticChoiceMenu = Validator.IsCorrectDigit(AdminStatisticChoiceMenu());
                switch (adminstatisticChoiceMenu)
                {
                    case 1:
                        var stats = Admin.ByScore(1);
                        for (int i = 0; i < stats.Count; i++)
                            Console.WriteLine($"{i + 1}.{stats[i]}");
                        
                        ClearAndWait();
                        break;
                    case 2:
                        stats = Admin.ByScore(2);
                        for (int i = 0; i < stats.Count; i++)
                            Console.WriteLine($"{i + 1}.{stats[i]}");
                        
                        ClearAndWait();
                        break;
                    case 3:
                        var filePathAndFileNameAndCategoryName = GetFilePathAndFileNameAndCategoryName(0, false);
                        string categoryName = filePathAndFileNameAndCategoryName[2];

                        stats = Admin.ByCategory(categoryName);

                        for (int i = 0; i < stats.Count; i++)
                            Console.WriteLine($"{i + 1}.{stats[i]}");
                        
                        ClearAndWait();
                        break;
                    case 4:
                        string[] filePathFileNameCategoryName = GetFilePathAndFileNameAndCategoryName(2, true);
                        string tesName = filePathFileNameCategoryName[1];
                        categoryName = filePathFileNameCategoryName[2];

                        stats = Admin.ByTest(categoryName, tesName);

                        for (int i = 0; i < stats.Count; i++)
                            Console.WriteLine($"{i + 1}.{stats[i]}");
                        
                        ClearAndWait();
                        break;
                    case 5:
                        adminFlag = false;
                        break;
                    default:
                        OnlyClear();
                        break;
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
                ClearAndWait();
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                ClearAndWait();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                ClearAndWait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ClearAndWait();
            }
        }

    }

    private string AdminStatisticChoiceMenu()
    {
        InscriptionsAndSigns.AdminPanel();
        Console.WriteLine("Admin statistics menu");
        InscriptionsAndSigns.DashedLine();
        Console.WriteLine("1.According to score by increase");
        Console.WriteLine("2.According to score in descending order");
        Console.WriteLine("3.According to category");
        Console.WriteLine("4.According to test");
        Console.WriteLine("5.Exit");
        Console.Write("Your choice: ");
        return Console.ReadLine() ?? string.Empty;
    }

    
    // Admin Test Part 
    
    private void AdminTestMenu()
    {
        bool adminFlag = true;
        while (adminFlag)
        {
            try
            {
                int adminTestMenu = Validator.IsCorrectDigit(AdminTestChoiceMenu());

                

                string categoryName;
                switch (adminTestMenu)
                {
                    case 1:
                        Console.Write("Enter the name of category: ");
                        categoryName = Console.ReadLine() ?? string.Empty;
                        Validator.IsCorrectNaming(categoryName);
                        if (Admin.AddCategory(categoryName))
                            Console.WriteLine("Category successfully added!");
                        ClearAndWait();
                        break;
                    case 2:
                        string[] filePathAndFileNameAndCategoryName = GetFilePathAndFileNameAndCategoryName(0, false);
                        categoryName = filePathAndFileNameAndCategoryName[2];

                        Admin.DeleteCategory(categoryName);

                        Console.WriteLine("Category successfully deleted!");
                        ClearAndWait();
                        break;
                    case 3:
                        filePathAndFileNameAndCategoryName = GetFilePathAndFileNameAndCategoryName(1, true);
                        string filePath = filePathAndFileNameAndCategoryName[0];

                        Test test = CreatingATest(filePathAndFileNameAndCategoryName[1]);
                        Admin.AddTest(filePath, test);
                        Console.WriteLine("Test successfully added!");
                        ClearAndWait();
                        break;
                    case 4:
                        filePathAndFileNameAndCategoryName = GetFilePathAndFileNameAndCategoryName(2, true);
                        filePath = filePathAndFileNameAndCategoryName[0];
                        string testName = filePathAndFileNameAndCategoryName[1];
                        categoryName = filePathAndFileNameAndCategoryName[2];

                        Admin.DeleteTest(filePath, testName, categoryName);
                        Console.WriteLine("Test successfully deleted!");
                        ClearAndWait();
                        break;
                    case 5:
                        filePathAndFileNameAndCategoryName = GetFilePathAndFileNameAndCategoryName(2, true);
                        filePath = filePathAndFileNameAndCategoryName[0];

                        Test newTest = CreatingATest(filePathAndFileNameAndCategoryName[1]);

                        Admin.EditTest(filePath, newTest);
                        Console.WriteLine("Test successfully edited!");

                        ClearAndWait();
                        break;
                    case 6:
                        filePathAndFileNameAndCategoryName = GetFilePathAndFileNameAndCategoryName(2, true);
                        filePath = filePathAndFileNameAndCategoryName[0];

                        Console.WriteLine(Admin.GetTest(filePath));

                        ClearAndWait();
                        break;
                    case 7:
                        adminFlag = false;
                        break;
                    default:
                        OnlyClear();
                        break;
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                ClearAndWait();
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                ClearAndWait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); 
                ClearAndWait();
            }
            
        }
    }
    private string AdminTestChoiceMenu()
    {
        InscriptionsAndSigns.AdminPanel();
        Console.WriteLine("Admin test menu");
        InscriptionsAndSigns.DashedLine();
        Console.WriteLine("1.Add category");
        Console.WriteLine("2.Delete category");
        Console.WriteLine("3.Add test");
        Console.WriteLine("4.Delete test");
        Console.WriteLine("5.Edit test");
        Console.WriteLine("6.Show test");
        Console.WriteLine("7.Exit");
        Console.Write("Your choice: ");
        return Console.ReadLine()?? string.Empty;
    }
    
    private string[] GetFilePathAndFileNameAndCategoryName(int firstGate, bool secondGate)
    {
       // Getting actual folders names  
        var dirs = Directory.GetDirectories(Directory.GetCurrentDirectory());
        for (int i = 0; i < dirs.Length; i++)
            dirs[i] = Path.GetFileName(dirs[i]);
    
    
        if(dirs.Length < 2) throw new InvalidOperationException("Categories doesn't exist!");
        Console.WriteLine("Categories:");
        for(int i = 0; i < dirs.Length - 1; i++)
            Console.WriteLine($"{i+1}.{dirs[i+1]}");
        Console.Write("\nChoice category: ");
        int categoryCount = Validator.IsCorrectDigit(Console.ReadLine()?? string.Empty);
    
        if(categoryCount < 1 || categoryCount>dirs.Length - 1) throw new InvalidOperationException("Category doesn't exist!");
        string categoryName = dirs[categoryCount];
        
        

        if (firstGate == 1 && secondGate)
        {
            Console.Write("Enter the name of test: ");
            string testName = Console.ReadLine()??string.Empty;
            Validator.IsCorrectNaming(testName);

            string filePath = categoryName + "\\" + testName + ".json";
            if(File.Exists(filePath)) throw new InvalidOperationException($"Test {testName} already exist!");
            
            return new []{filePath,testName,categoryName};
        }
        else if (firstGate == 2 && secondGate)
        {
            var files = Directory.GetFiles(categoryName);
            for (int i = 0; i < files.Length; i++)
                files[i] = Path.GetFileName(files[i]);
            
            if(files.Length == 0) throw new InvalidOperationException("This category is empty!");
            Console.WriteLine("\nFiles:");
            for (int i = 0; i < files.Length; i++)
                Console.WriteLine($"{i + 1}.{files[i]}");
            Console.Write("\nChoice the test: ");
            int testCount = Validator.IsCorrectDigit(Console.ReadLine()?? string.Empty) - 1;

            if(testCount < 0 || testCount>files.Length) throw new InvalidOperationException("File doesn't exist!");
            
            string testName = files[testCount];
            string filePath = categoryName + "\\" + testName;
            
            return new []{filePath,testName,categoryName};
        }
        
        return new [] {"","",categoryName};
    }
    private Test CreatingATest(string testName)
    {
        bool testFlag = true;
        while (testFlag)
        {
            try
            {
                int countQuestions;
                bool countQuestionsFlag = true;
                do
                {
                    Console.Write("Enter the number of questions in the test: ");
                    countQuestions = Validator.IsCorrectDigit(Console.ReadLine()?? string.Empty);
                    countQuestionsFlag = false;
                } while (countQuestionsFlag);
        
                var testQuestions = new List<TestQuestion>();

                for (int i = 0; i < countQuestions; i++)
                {
                    var question = new TestQuestion();
                    do
                    {
                        Console.Write($"Enter the {i + 1} question: ");
                        question.Question = Console.ReadLine()?? string.Empty;
                    } while (!Validator.IsStringNotNullOrEmpty(question.Question));
                    
                    
                    var answers = new List<string>(4);
                    string[] answersSimbols = new []{"A","B","C","D"};
                    for (int j = 0; j < 4; j++)
                    {
                        string tempAnswer;
                        do
                        {
                            Console.Write($"Enter answer {answersSimbols[j]}: ");
                            tempAnswer = Console.ReadLine()?? string.Empty;
                            
                        } while (!Validator.IsStringNotNullOrEmpty(tempAnswer));
                        answers.Add(tempAnswer);
                    }
                    
                    
                    question.Answers = answers;
                    string tempCorrectAnswer;
                    do
                    {
                        Console.Write("Enter the correct answer: ");
                        tempCorrectAnswer = Console.ReadLine()?? string.Empty;
                    } while (!Validator.IsCorrectAnswer(tempCorrectAnswer));
                    question.CorrectAnswer = tempCorrectAnswer.ToUpper();

                    
                    testQuestions.Add(question);
                }
                        
                Test test = new Test(testName,testQuestions,countQuestions);

                return test;
            }
            catch (InvalidOperationException e){ Console.WriteLine(e.Message); }
            catch (FormatException e){ Console.WriteLine(e.Message); }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
        return null;
    }
    
    
}