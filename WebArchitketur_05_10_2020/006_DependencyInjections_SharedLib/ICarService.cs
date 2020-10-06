using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjections_SharedLib
{
    public interface ICarService
    {
        public void RepairCar(ICar car);
    }
}
