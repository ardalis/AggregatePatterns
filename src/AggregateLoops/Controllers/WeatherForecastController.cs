using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AggregateLoops.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly AppDbContext _db;

    public WeatherForecastController(ILogger<WeatherForecastController> logger,
        AppDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        var po = _db.PurchaseOrders
            .Include(po => po.Items)
            .FirstOrDefault();
        po.UpdateMaxAmount(50000);
        var existingItem = po.Items.FirstOrDefault();
        existingItem.UpdateAmount(100000);
        var poItem = new PurchaseOrderItem(4000);
        po.AddItem(poItem);

        _db.SaveChanges();

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
