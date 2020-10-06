using _005_DependencyInjections_EntityLib;
using _005_DependencyInjections_Lib;
using System;

namespace _005_DependencyInjections_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            BadCarService badCarService = new BadCarService();
            badCarService.RepairCar(new BadCar()); 
            //Nachteile: - BadCarService.RepairCar benötigt BadCarService als Typ = BadCar muss fertig sein. + harte Verdrahtung

            Console.WriteLine("Hello World!");
        }
    }
}
