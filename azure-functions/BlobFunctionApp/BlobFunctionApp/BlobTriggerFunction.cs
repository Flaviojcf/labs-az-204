using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text;

namespace BlobFunctionApp
{
    public class BlobTriggerFunction
    {
        private readonly ILogger<BlobTriggerFunction> _logger;

        public BlobTriggerFunction(ILogger<BlobTriggerFunction> logger)
        {
            _logger = logger;
        }

        [Function(nameof(BlobTriggerFunction))]
        public void Run([BlobTrigger("dados/{name}", Connection = "blobConnection")] string blob, string name)
        {
            var stream = new MemoryStream(Encoding.UTF8.GetByteCount(blob));
            StreamWriter writer = new(stream, Encoding.UTF8, -1, true);

            writer.Write(blob);
            writer.Flush();
            stream.Position = 0;

            string message = $"Blob trigger function processed blob\n Name: {name}\n Size: {stream.Length} Bytes";

            _logger.LogInformation(message);

            StreamWriter writer1 = new StreamWriter(@"C:\Users\f.da.costa.filho\blob.txt", false);
            writer1.WriteLine(message);
            writer1.Close();
        }
    }
}
