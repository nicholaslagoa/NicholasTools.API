using MongoDB.Driver;
using NicholasTools.API.Data.Configurations;

namespace NicholasTools.API.Data.Repositories
{
    public class BaseRepository
    {
        protected IMongoClient _client;
        protected IMongoDatabase _database;

        public BaseRepository(IDatabaseConfig databaseConfig)
        {
            _client = new MongoClient(databaseConfig.ConnectionString);
            _database = _client.GetDatabase(databaseConfig.DatabaseName);
        }
    }
}
