using System;

namespace DependencyInjections_SharedLib
{
    public interface ICar
    {
        string Herrsteller { get; set; }
        string Type { get; set; }
        DateTime Baujahr { get; set; }
    }
}
