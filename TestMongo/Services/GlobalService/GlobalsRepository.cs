using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMongo.Models;

namespace TestMongo.Services.GlobalService
{
    public class GlobalsRepository
    {
        //delcaring mongo db
        private readonly IMongoDatabase _database;

        public GlobalsRepository(IOptions<Settings> settings)
        {
            try
            {
                var client = new MongoClient(settings.Value.ConnectionString);
                if (client != null)
                    _database = client.GetDatabase(settings.Value.Database);
            }
            catch (Exception ex)
            {
                throw new Exception("Can not access to MongoDb server.", ex);
            }
        }

        public IMongoCollection<GlobalModel> Globals => _database.GetCollection<GlobalModel>("globals");

    }
}
