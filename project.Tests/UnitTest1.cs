using System;
using Xunit;
using project.Services;
namespace project.Tests
{
    public class SummaryTest
    {
        private WeatherForeCastService _weatherForeCastService;
        public SummaryTest(){
            _weatherForeCastService = new WeatherForeCastService();
        }
        [Fact]
        public void Test1()
        {
            Assert.Equal("Cool",  _weatherForeCastService.getSummary(3));
        }
        [Fact]
        public void Test2()
        {
            Assert.Equal("Scorching",  _weatherForeCastService.getSummary(55));
        }
        [Fact]
        public void Test3()
        {
            Assert.Equal("Bracin",  _weatherForeCastService.getSummary(-10));
        }
    }
}
