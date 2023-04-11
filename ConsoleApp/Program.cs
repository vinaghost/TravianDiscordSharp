﻿using MongoDB.Bson;
using MongoDB.Driver;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");

            if (string.IsNullOrEmpty(connectionString))
            {
                Console.WriteLine("You must set your 'MONGODB_URI' environmental variable. See\n\t https://www.mongodb.com/docs/drivers/go/current/usage-examples/#environment-variable");
                return;
            }
            var client = new MongoClient(connectionString);
            var collection = client.GetDatabase("sample_mflix").GetCollection<BsonDocument>("movies");
            var filter = Builders<BsonDocument>.Filter.Eq("title", "Back to the Future");
            var document = collection.Find(filter).First();
            Console.WriteLine(document);
        }
    }
}