using Regis.API.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();



/* Cette m�thode configure le service pour qu'une nouvelle instance 
de WeatherForecastService soit cr��e chaque fois que le service est demand�. 
Cela signifie que chaque fois que vous injectez WeatherForecastService dans un 
contr�leur ou un autre service, une nouvelle instance sera fournie. 
Ce cycle de vie est utile pour les services l�gers et stateless (sans �tat).*/
//builder.Services.AddTransient<IWeatherForecastService, WeatherForecastService>();

/* Avec cette m�thode, une seule instance de WeatherForecastService 
est cr��e par requ�te HTTP. Cela signifie que pour une requ�te donn�e, 
toutes les injections de WeatherForecastService partageront la m�me instance. 
Ce cycle de vie est appropri� pour les services qui doivent conserver des donn�es 
sp�cifiques � une requ�te, mais qui ne doivent pas �tre partag�s entre diff�rentes requ�tes.*/
// Ici, on souhaitera utiliser cette m�thode pour le service WeatherForecastService
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();

/* Cette m�thode configure le service pour qu'une seule instance de WeatherForecastService 
soit cr��e et partag�e dans toute l'application. Cette instance unique est cr��e la premi�re 
fois qu'elle est demand�e, puis r�utilis�e pour toutes les requ�tes suivantes. 
Ce cycle de vie est id�al pour les services qui doivent conserver un �tat global ou 
qui sont co�teux � cr�er.*/
//builder.Services.AddSingleton<IWeatherForecastService, WeatherForecastService>();


var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
