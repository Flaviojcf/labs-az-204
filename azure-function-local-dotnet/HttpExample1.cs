using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace My.Function;

public class HttpExample1
{
    private readonly ILogger<HttpExample1> _logger;

    public HttpExample1(ILogger<HttpExample1> logger)
    {
        _logger = logger;
    }

    [Function("HttpExample1")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}