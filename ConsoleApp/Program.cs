using Microsoft.Extensions.Configuration;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

            var secretProvider = config.Providers.First();
            secretProvider.TryGet("MongoDBConnectionString", out var connectionString);

            Console.WriteLine("Hello, World!");
            Console.WriteLine(connectionString);
        }
    }
}