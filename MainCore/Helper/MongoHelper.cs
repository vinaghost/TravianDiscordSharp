using MongoDB.Driver;

namespace MainCore.Helper
{
    public static class MongoHelper
    {
        private static MongoClient _mongoClient;

        public static MongoClient GetClient()
        {
            if (_mongoClient is null)
            {
                var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
                _mongoClient = new MongoClient(connectionString);
            }
            return _mongoClient;
        }
    }
}