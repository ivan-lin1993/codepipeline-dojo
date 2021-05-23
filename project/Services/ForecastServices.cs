using System;
using System.Collections.Generic;
using System.Linq;
using project.Interface;
using project.Models;

namespace project.Services{
    public class WeatherForeCastService : IForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", 
            "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private int _minTemperture = -20;
        private int _MAXTemperture = 55;
        public WeatherForeCastService(){
            
        }
        public IEnumerable<WeatherForecast> forecast()
        {
            var rng = new Random();
            
            var forecastData = new List<WeatherForecast>();
            foreach(var i in Enumerable.Range(1, 5)){
                var tempertureC = rng.Next(_minTemperture, _MAXTemperture);
                var summary = getSummary(tempertureC);

                forecastData.Add(new WeatherForecast{
                    Date = DateTime.Now.AddDays(i),
                    TemperatureC = tempertureC,
                    Summary = summary
                });
            }
            return forecastData;
        }

        public string getSummary(int tempertureC){
            var index = (
                (float)(tempertureC - _minTemperture) / (_MAXTemperture - _minTemperture)
            ) * (Summaries.Length - 1);
            Console.WriteLine((int)Math.Round(index));
            return Summaries[(int)Math.Round(index)];
        }
    }
}