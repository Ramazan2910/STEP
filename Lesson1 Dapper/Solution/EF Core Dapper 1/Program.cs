using Microsoft.Extensions.Configuration;

namespace EF_Core_Dapper_1;

class Program
{
    static void Main(string[] args)
    {
        CrudCars crudCars = new CrudCars();
        var car1 = new Car("Lamborgini", "Urus", 2022, 100000);
        var car2 = new Car("BWM", "X5", 2024, 700000);
        var  car3 = new Car("Audi", "A5", 2014, 800000);
        var  car4 = new Car("Audi", "Q7", 2018, 890000);

        #region Car Add
        /*var cars = new List<Car> {car1,car2,car3,car4};

        foreach (var car in cars)
        {
            crudCars.Add(car);
        }*/
        #endregion
        
        #region Car Update
        //crudCars.Update(car2,28);
        #endregion
        
        #region Car Delete
        //crudCars.Delete(28);
        #endregion
        
        #region Car Get All
        /*var cars = crudCars.GetAll();
        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }*/
        #endregion
        
        #region Car Get By Brand
        /*var carsByBrand = crudCars.GetByBrand("Audi");
        foreach (var car in carsByBrand)
        {
            Console.WriteLine(car);
        }*/
        #endregion
    }
}


