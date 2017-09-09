using MongoDB.Driver;
using XY.Component.Abstract;

namespace XY.Component.MongoDB
{
    public class MongodbProvider: IMongodbProvider
    {
        public string ConnectionString { get; set; }
        private static MongoClient _client;
        public MongoClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new MongoClient(ConnectionString);
                }
                return _client;
            }
        }

        private IMongoDatabase db;
        public MongodbProvider(string connectionString, string dataBaseName)
        {
            this.ConnectionString = connectionString;
            db = Client.GetDatabase(dataBaseName);
        }
    }
}
