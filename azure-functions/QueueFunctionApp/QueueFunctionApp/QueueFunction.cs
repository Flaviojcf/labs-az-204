using Azure.Data.Tables;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using QueueFunctionApp.Models;

namespace QueueFunctionApp
{
    public class QueueFunction
    {
        private readonly ILogger<QueueFunction> _logger;

        public QueueFunction(ILogger<QueueFunction> logger)
        {
            _logger = logger;
        }

        [Function(nameof(QueueFunction))]
        public async Task Run(
            [QueueTrigger("queuetrigger", Connection = "queueConnection")] Product product)
        {
            _logger.LogInformation($"Produto recebido: {product}");

            var connectionString = Environment.GetEnvironmentVariable("queueConnection");
            var tableClient = new TableClient(connectionString, "Products");

            await tableClient.CreateIfNotExistsAsync();

            var entity = new TableEntity(product.Category, product.Id.ToString())
            {
                { "Description", product.Description },
                { "Price", product.Price }
            };

            await tableClient.UpsertEntityAsync(entity);
        }
    }
}