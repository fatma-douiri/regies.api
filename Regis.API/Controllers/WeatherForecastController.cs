using Microsoft.AspNetCore.Mvc;

namespace Regis.API.Controllers;


public class Temps
{
    public int min { get; set; }
    public int max { get; set; }
}


[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{


    private readonly ILogger<WeatherForecastController> _logger;

    private IWeatherForecastService _service;



    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService service)
    {
        _logger = logger;
        _service = service;
    }


    [HttpGet]
    [Route("ExampleGet")]
    public IActionResult Get()
    {
        return StatusCode(200, _service.Get(50, 5));
    }


    [HttpGet]
    [Route("{take}/GetConstruct")]
    public IEnumerable<WeatherForecast> Get([FromQuery] int max, [FromRoute] int take)
    {
        return _service.Get(max, take);
    }


    [HttpGet("currentDay")]

    public WeatherForecast GetCurrentDay()
    {
        return _service.Get(50, 5).First();
    }


    [HttpPost("currentDay")]

    public string Hello([FromBody] string name) => $"Hello {name}";

    //M�thode create HttpPost qui va renvoyer un IActionResult
    //Depuis la query on r�cup�re le nombre de r�sultats 
    //Depuis le body on r�cup�re un objet Temps temp�ratures limites qui contiendra les valeurs min et max � passer � la m�thode Get
    //Si minTemp> maxTemp OU si numberOfResults < 0 => Renvoie une badRequest SINON => OK qui contient le r�sultats

    [HttpPost("create")]
    public IActionResult Create([FromQuery] int numberOfResults, [FromBody] Temps temps)
    {
        if(temps.max<temps.min || numberOfResults < 0)
        {
            return BadRequest("Error");
        }
        return StatusCode(200, this._service.Get(temps.min, temps.max, numberOfResults));
    }



}


