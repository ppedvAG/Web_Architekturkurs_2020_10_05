using System;

namespace _005_DependencyInjections
{

    #region Bad Sample


    //Car.dll (wird von Steve programmiert)
    public class BadCar
    {
        public string  Hersteller { get; set; }
        public string  Typ { get; set; }
        public DateTime Baujahr { get; set; }
    }


    //CarService.dll (wird von Bill programmiert)
    public class BadCarService
    {
        public void RepairCar (BadCar car)
        {
            //repair something
        }
    }
    #endregion



    #region better Variant

    //Like Contract First -> Zuerst werden die Interface definiert. 
    public interface ICar
    {
        string Herrsteller { get; set; }
        string Type { get; set; }
        DateTime Baujahr { get; set; }
    }

    public interface ICarService
    {
        public void RepairCar(ICar car);
    }





    
    //Codeabschnitt Steve
    public class Car : ICar
    {
        public string Herrsteller { get; set ; }
        public string Type { get; set; }
        public DateTime Baujahr { get; set; }
    }


    //Codeabschnitt Bill
    public class CarService : ICarService
    {
        public void RepairCar(ICar car)
        {
            //Mach irgendwas
        }
    }

    public class MockCar : ICar
    {
        public string Herrsteller { get; set; } = "Porsche";
        public string Type { get; set; } = "911er";
        public DateTime Baujahr { get; set; } = DateTime.Now;
    }


    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarService();

            carService.RepairCar(new MockCar());
        }
    }
}
