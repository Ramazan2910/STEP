## Нужные расширения 
- Microsoft.Data.SqlClient - для работы с SQL 
- Dapper - логичкно для работы с Dapper
- Mircosoft.Extensions.Configuration.Json - для удобной работы с json файлами
 

# База ADO.NET и Dapper
**Дисклеймер если в названии подзаголовка есть ADO.NET это означает что данный код является частью ADO.NET**

- connectionString 
- Sqlconnection
- Open () ADO.NET
- SqlQuery 
- SQlCommand ADO.NET
- ExecuteReader

## ConnectionString
Это строка  подключения к Базе данных 

```csharp
var connectionString = "Data Source = localhost; Initial Catalogy = NameOfDB; Trust Server Certificate = true;"
```

## Sqlconnection 
Подключение к Базе данных

```csharp
using var connection = new Sqlconnection(connectionString)
```

Так как `Sqlconnection` наследуется от `Dbconnectoin` а тот от `IDisposable` можно или даже нужно использовать `using` для автоматического закрытия подключения

## Open ADO.NET
Нужен для открытия соединения с БД если ты используешь `ADO.NET`

```csharp
connection.Open()
```

Но если ты используешь `Dapper` или `Entity Framework`, они автоматически открывают и закрывают соединение.

## SqlQuery
SQL Запросы 

```csharp
var sql = "SELECT * FROM Users"
```

## SQlCommand ADO.NET
Используется для подключения запроса `sql` к `connection`

```csharp
using var command = new SQlCommand(sql, connection)
```

## ExecuteReader ADO.NET
Выполняет и считываает данные по заданному запросу 

```csharp
using var reader = command.ExecuteReader();

// Команда Read читает до конца все данные

while (reader.Read())
{
    // Одно и тоже просто во втором случаи выводит то количество столбцов которое нужно
    Console.WriteLine(reader["userName"]);
    Console.WriteLine(reader.GetString(0));
}
```


# База Dapper

- Правильная запись connectionString
- Подключение к БД 
- Запросы с помощью Dapper
  - Запросы не возвращающих данные
  - Запросы возвращающие данные
- Relationships (SplitOn)
  - One-To-Many 
  - Many To Many


## Правильная запись connectionString
Теперь, как правильно записывать `connectionString` ибо если оставлять его в коде то кто-то другой с легкостью сможет подключиться в вашей БД. Первое что надо сделать создать `appsettings.json` там будет записана строка подключения к нашему БД. Второе надо сделать так чтобы этот файл `appsettings.json` также добавлялся в папку bin при каждом запуске. Для этого надо зайти в `file properties` этого файла и в сторке `Copy to output directory` выбрать `Copy if newer`. И третий шаг надо добавить файл `appsettings.json` в файл `.gitignore` чтобы когда вы выполняли `push` в `GitHub` файл оставался только на вашем компьютере.


А вот теперь можно и записать сам `connectionString`. Вот пример: 

```json
{
  "ConnectionStrings" : {
    "Default": "Data Source=localhost; Initial Catalog=Auth_24_2;Integrated Security=True; Trust Server Certificate=true;",
    "Ecommerce": "Data Source=localhost; Initial Catalog=Ecommerce_3; Integrated Security=True; Trust Server Certificate=true;"
  }
}

// Integrated Security=True; Это подойдет, если SQL Server настроен на аутентификацию через Windows.
```

## Подключение к БД 

Чтобы подключиться к БД нам нужно спрева считать `connectionString` из файла `appsettings.json` для этого вместо Десериализации мы устанавливаем раширение под названием `Mircosoft.Extensions.Configuration.Json` 

Вот код как можно подключится к БД 

```csharp
var configBuilder = new ConfigurationBuilder(); // создаем конйигурацию 

configBuilder.AddJsonFile("appsettings.json"); // добавляем туда файл

var config = configBuilder.Build(); 

var connectionString = config.GetConnectionString("Default"); // выбераем нужный нам connectionString

```

## Запросы с помощью Dapper

## 1. Dapper Query

Данный тип запроса часто используется чтобы возвращать одну строчку или один столбец

```csharp
// Подключение остается тем же самым

using var connection = new SqlConnection(connectionString);

var commandString = "select * from Users";

connection.Open();

//Тоже самое что и SQlCommand просто здесь сразу выполняется запрос и сразу записывается в переменную
var res = connection.Query<User>(commandString); // Класс User полностью соответствует таблице User в БД 


foreach(var user in res) // благодаря тому что переменная IQueryable мы можем его вывести с помощью foreach
{
    Console.WriteLine(user);
}

```

## 2. Dapper ExecuteScalar

Агрегатные функции выполняютс с помошью `ExecuteScalar`

```csharp
var commandString = "select count(*) from Users";

using var connection = new SqlConnection(connectionString);
connection.Open();

var count = connection.ExecuteScalar<int>(commandString);
Console.WriteLine(count);
```

## 3. Dapper QuerySingle (Параметризованные запросы)

```csharp
var commandString = "select * from Users where userName = 'alice_smith'";

using var connection = new SqlConnection(connectionString); 
connection.Open(); 

var user = connection.QuerySingle<User>(commandString);
Console.WriteLine(user);
```

Параметризованные запросы - это запросы, в которых мы можем передавать параметры.

Они нужны для того чтобы избежать SQL инъекций. Такой тип атаки добавляет в запрос SQL код, который
может изменить запрос и выполнить его.

В случае параметра мы можем передать значение, которое будет вставлено в запрос. Таким образом мы
можем избежать SQL инъекций.

```csharp
var commandString = "select * from Users where userName = @userName";

using var connection = new SqlConnection(connectionString);
connection.Open();

var user = connection.QuerySingle<User>(commandString, new {userName = "alice_smith"});

Console.WriteLine(user);

```

В примере выше мы видим что вместо значения мы передаем параметр `@userName`. 
Это позволяет нам избежать SQL инъекций. Даже если человек напишет `drop table Users`,
то это не повлияет на наш запрос. Он попытается найти пользователя с именем `drop table Users`.


## 4. Dapper Multiple Rows

Этот запрос выводит сразу все данные с подходящим параметром

```csharp
var sql = "SELECT * FROM Product WHERE CategoryID = @categoryID";

var products = connection.Query(sql, new { categoryID = 1 }).ToList(); // ToList() приводит IEnumerable<T> к List<T>


foreach(var product in products)
{
	Console.WriteLine($"ProductID: {product.ProductID}; Name: {product.Name}");
}	
```

## 5. Dapper QueryMultiple 

```csharp 
var commandString = "select * from Users where userName = @userName;" +
     "select * from UserRoles where userNameRef = @userName;";

using var connection = new SqlConnection(connectionString);
connection.Open();

using var multi = connection.QueryMultiple(commandString, new {userName = "emily_clark"});

var user = multi.Read<User>().Single();

var userRoles = multi.Read<UserRole>();

Console.WriteLine(user);

foreach(var userRole in userRoles)
{
  Console.WriteLine(userRole);
}
```


## 6. (Non-Query Commands With Dapper) Запросы не возвращающие данные

Execute() – это метод библиотеки Dapper, который используется для выполнения не возвращающих данных SQL-запросов (INSERT, UPDATE, DELETE).

Он не возвращает данные, а просто выполняет запрос.
Возвращает количество затронутых строк (int).

Примеры: 
## 1.1 INSERT in ADO.NET

```csharp 
  using var connection = new SqlConnection(connectionString);

  connection.Open();
  var sqlQuery = "insert into Roles values(N'Editor');";

  var command = new SqlCommand(sqlQuery, connection);

  int ExecutedRows = command.ExecuteNonQuery();
```

## 1.2 INSERT in Dapper

```csharp

// First Example

using (var connection = new SqlConnection(connectionString))
{
    string sql = "INSERT INTO Cars (Brand, Model, Year, Price) VALUES (@Brand, @Model, @Year, @Price)";
    
    var parameters = new { Brand = "Toyota", Model = "Camry", Year = 2022, Price = 30000 };

    int rowsAffected = connection.Execute(sql, parameters);

    Console.WriteLine($"Добавлено записей: {rowsAffected}");
}

// Second Example with List of Users 

  using var connection = new SqlConnection(connectionString);

  connection.Open();

  var users = new List<User>()
  {
      new User("Evin_123", "Elvin_1234", "profbat018@gmail.com"),
      new User("Ramazan_123", "Ramazan_1234", "ramazan@gmail.com")
  };


  var sqlQuery = "insert into Users(userName, password, email) values(@UserName, @Password, @Email);";

  var affectedRows = connection.Execute(sqlQuery, users);
  
```

## 2. UPDATE

```csharp
using (var connection = new SqlConnection(connectionString))
{
    string sql = "UPDATE Cars SET Price = @NewPrice WHERE Brand = @Brand";
    
    var parameters = new { Brand = "Toyota", NewPrice = 28000 };

    int rowsAffected = connection.Execute(sql, parameters);

    Console.WriteLine($"Обновлено записей: {rowsAffected}");
}
```

## 3. DELETE

```csharp
using (var connection = new SqlConnection(connectionString))
{
    string sql = "DELETE FROM Cars WHERE Brand = @Brand";

    var parameters = new { Brand = "Toyota" };

    int rowsAffected = connection.Execute(sql, parameters);

    Console.WriteLine($"Удалено записей: {rowsAffected}");
}
```

## Relationships 

`Dapper Relationships` – это просто способ связывать объекты в C#, если данные связаны в базе (например, через JOIN).
- Один запрос – несколько объектов
- Используем splitOn, чтобы правильно разделить данные
- Связываем их вручную в лямбда-функции


`SplitOn` в Dapper говорит, с какого столбца начинается новый объект в результате SQL-запроса. Когда мы соединяем (JOIN) несколько таблиц в SQL, все данные приходят в одной строке. Dapper не понимает, где заканчивается один объект (например, Order) и начинается другой (например, User). И в этот момент в игру вступает `SplitOn` и только благодаря ему данные разделяются на отдельные обьекты. 

Вот базовый пример: 

### SQL PART

```sql
  CREATE TABLE Users (
    Id INT PRIMARY KEY,
    Name NVARCHAR(100)
);

CREATE TABLE Orders (
    Id INT PRIMARY KEY,
    UserId INT FOREIGN KEY REFERENCES Users(Id), /*Вот и происходит связь так называемые Relationships*/
    Product NVARCHAR(100)
);


SELECT o.Id, o.Product, u.Id, u.Name 
FROM Orders o
JOIN Users u ON o.UserId = u.Id
```

### C# CLASSES PART
```csharp
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Order
{
    public int Id { get; set; }
    public string Product { get; set; }
    public User User { get; set; }  // Связь с User
}
```

### C# SplitOn PART


```csharp
var sql = "SELECT o.Id, o.Product, u.Id, u.Name FROM Orders o JOIN Users u ON o.UserId = u.Id";

var orders = connection.Query<Order, User, Order>( // В этой части описываются таблицы которые обьединяются в той же последовательности в которой они были записаны в SQL запросе, а также в конце указывается тип возвращаемого значения. Это значит, что итоговая коллекция (List<Order>) будет включать объекты Order, содержащие User
    sql,
    (order, user) => /* Dapper передает нам 2 объекта (Order, User), которые он собрал из SQL-результата. 
                        Мы вручную говорим, что Order должен содержать User. 
                        Возвращаем order, и он добавляется в список orders.*/
    {
        order.User = user;
        return order;
    },
    splitOn: "Id" // Говорим Dapper, что с этого момента начинается User
).ToList();
```
### Подробно как работает SplitOn

Dapper читает результат запроса по колонкам слева направо. Если он видит колонку, указанную в splitOn, он создает новый объект.

Пример:

```sql
SELECT o.Id, o.Product, u.Id, u.Name FROM Orders o JOIN Users u ON o.UserId = u.Id
```

Колонки в результате:

```pgsql
o.Id | o.Product | u.Id | u.Name
---------------------------------
  1  |  "Laptop" |  10  | "Alice"
  2  |  "Phone"  |  11  | "Bob"
```

Dapper видит:

1. o.Id → создает Order
2. o.Product → добавляет в Order
3. u.Id (совпадает с SplitOn) → создает User
4. u.Name → добавляет в User

Затем объединяет:

```csharp
Order { Id = 1, Product = "Laptop", User = User { Id = 10, Name = "Alice" } }
Order { Id = 2, Product = "Phone", User = User { Id = 11, Name = "Bob" } }
```

## Типы отношений 

#### 📌 One-to-Many (Один ко многим)
- Один объект содержит список других объектов
- Используем LEFT JOIN
- Заполняем List<Order> внутри User



#### 📌 Many-to-Many (Многие ко многим)
- Две сущности связаны через промежуточную таблицу
- Используем двойной JOIN
- Заполняем List<Course> внутри Student