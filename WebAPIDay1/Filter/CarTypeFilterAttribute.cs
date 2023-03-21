using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;
using WebAPIDay1.Models;

namespace WebAPIDay1.Filter;



public class CarTypeFilterAttribute:ActionFilterAttribute
{
    private ILogger<CarTypeFilterAttribute> _logger;
    public CarTypeFilterAttribute(ILogger<CarTypeFilterAttribute> logger)
    {
        _logger = logger;
    }
    private Regex AllowedTypes = new Regex("^(Electric|Gas|Diesl|Hybrid)$", RegexOptions.IgnoreCase , TimeSpan.FromSeconds(10));
    public override void OnActionExecuting(ActionExecutingContext context)
    {

        _logger.LogInformation("hello from type filkter");

        Cars? TargetCar = context.ActionArguments["car"] as Cars;

        _logger.LogInformation($"hello from type filkter with type {TargetCar.Type.ToString()}");

        if (TargetCar is null || !AllowedTypes.IsMatch(TargetCar!.Type))
        {
            context.Result = new BadRequestObjectResult(new { message = "Wrong Type Inserted" });
        }
    }
}
