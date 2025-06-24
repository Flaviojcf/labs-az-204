using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace TimerFunctionApp
{
    public class TimerFunctionApp
    {
        private readonly ILogger _logger;

        public TimerFunctionApp(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<TimerFunctionApp>();
        }

        [Function(nameof(TimerFunctionApp))]
        public void Run([TimerTrigger("*/5 * * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}
