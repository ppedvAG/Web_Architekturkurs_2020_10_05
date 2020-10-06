using _006_DependencyInjections_EntityLib;
using _006_DependencyInjections_ServiceLib;
using _006_DependencyInjections_SharedLib;
using System;

namespace _006_DependencyInjections_Console
{
    class Program
    {
        static void Main(string[] args)
        {

            ICarService carService = new CarService();

            ICar meinAuto = new Car();


            carService.RepairCar(meinAuto);



            Console.WriteLine("Hello World!");
        }
    }
}
