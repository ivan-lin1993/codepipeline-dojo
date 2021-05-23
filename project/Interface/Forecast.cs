using System.Collections.Generic;
using project.Models;
namespace project.Interface
{
    interface IForecastService
    {
        IEnumerable<WeatherForecast> forecast();
    }
}