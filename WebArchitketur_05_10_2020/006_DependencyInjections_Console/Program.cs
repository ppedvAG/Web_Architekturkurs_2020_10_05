using _006_DependencyInjections_EntityLib;
using _006_DependencyInjections_ServiceLib;

using System;

namespace _006_DependencyInjections_Console
{
    class Program
    {
        static void Main(string[] args)
        {

            DependencyInjections_SharedLib.ICarService carService = new CarService();

            DependencyInjections_SharedLib.ICar meinAuto = new Car();


            carService.RepairCar(meinAuto);



            Console.WriteLine("Hello World!");
        }
    }
}
