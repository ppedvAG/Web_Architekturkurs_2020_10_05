using DependencyInjections_SharedLib;
using System;

namespace _006_DependencyInjections_EntityLib
{
    public class Car : ICar
    {
        public string Herrsteller { get; set; } = "BMW";
        public string Type { get; set; } = "Z8";
        public DateTime Baujahr { get; set; } = new DateTime(2002, 2, 22);
    }
}
