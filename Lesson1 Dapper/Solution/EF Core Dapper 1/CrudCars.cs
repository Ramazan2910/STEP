using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EF_Core_Dapper_1;

public class CrudCars
{
    private readonly string _connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("Default");
    
    public void Add(Car newCar)
    {
        using var connection = new SqlConnection(_connectionString);
        var sqlCommand = "INSERT INTO Cars(Brand, Model,Year,Price) VALUES (@Brand, @Model, @Year, @Price)";
        var res = connection.Execute(sqlCommand, newCar);
        Console.WriteLine(res > 0 ? $"{newCar.Brand} has been added successfully": "Something went wrong");
    }

    public void Update(Car newCar,int id)
    {
        var sqlCommand = "UPDATE Cars SET Brand = @Brand, Model = @Model, Year = @Year, Price = @Price WHERE Id = @Id";
        using var connection = new SqlConnection(_connectionString);
        var res = connection.Execute(sqlCommand, new {Id = id , newCar.Brand, newCar.Model, newCar.Year , newCar.Price});
        Console.WriteLine(res > 0 ? "Car price updated successfully!": "Something went wrong" );
    }

    public void Delete(int id)
    {
        var sqlCommand = "DELETE FROM Cars WHERE Id = @Id";
        using var connection = new SqlConnection(_connectionString);
        var res = connection.Execute(sqlCommand, new { Id = id });
        Console.WriteLine(res >  0 ? "Car deleted successfully!" : "Something went wrong");
    }

    public IEnumerable<Car> GetAll()
    {
        using var connection = new SqlConnection(_connectionString);
        var sqlCommand = "SELECT * FROM Cars";
        var cars = connection.Query<Car>(sqlCommand);
        return cars;
    }

    public IEnumerable<Car> GetByBrand(string brand)
    {
        using var connection = new SqlConnection(_connectionString);
        var sqlCommand = "SELECT * FROM Cars WHERE Brand = @Brand";
        var cars = connection.Query<Car>(sqlCommand, new { Brand = brand });
        return cars;
    }
    
}