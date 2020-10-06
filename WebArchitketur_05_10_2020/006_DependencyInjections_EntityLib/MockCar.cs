using DependencyInjections_SharedLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace _006_DependencyInjections_EntityLib
{
    public class MockCar : ICar
    {
        public string Herrsteller { get; set; } = "Porsche";
        public string Type { get; set; } = "911er";
        public DateTime Baujahr { get; set; } = DateTime.Now;
    }
}
