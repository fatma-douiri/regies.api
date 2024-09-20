
namespace Regis.API.Controllers
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get(int max, int Number);
        IEnumerable<WeatherForecast> Get(int min ,int max, int Number);
    }
}