using StackExchange.Redis;
using System;
using System.Threading.Tasks;
using XY.Component.Abstract;

namespace XY.Component.Redis
{
    public class RedisCache : IRedisCache
    {
        public string ConnectionString { get; set; }
        private static ConnectionMultiplexer _connection;
        public ConnectionMultiplexer Connection
        {
            get
            {
                if (_connection == null || !_connection.IsConnected)
                {
                    _connection = ConnectionMultiplexer.Connect(ConnectionString);
                }
                return _connection;
            }
        }

        private IDatabase db;

        public RedisCache(string connectionString)
        {
            this.ConnectionString = connectionString;
            db = Connection.GetDatabase();
        }


        public bool StringSet(string key, string value)
        {
            return StringSet(key, value, null);
        }
        public bool StringSet(string key, string value, TimeSpan? ts)
        {
            return db.StringSet(key, value, ts);
        }
        public async Task<bool> StringSetAsync(string key, string value)
        {
            return await StringSetAsync(key, value, null);
        }
        public async Task<bool> StringSetAsync(string key, string value, TimeSpan? ts)
        {
            return await db.StringSetAsync(key, value, ts);
        }
        public string StringGet(string key)
        {
            return db.StringGet(key);
        }
        public async Task<string> StringGetAsync(string key)
        {
            return await db.StringGetAsync(key);
        }
        public long StringIncrement(string key)
        {
            return db.StringIncrement(key);
        }
        public async Task<long> StringIncrementAsync(string key)
        {
            return await db.StringIncrementAsync(key);
        }

        public bool KeyDelete(string key)
        {
            return db.KeyDelete(key);
        }
        public async Task<bool> KeyDeleteAsync(string key)
        {
            return await db.KeyDeleteAsync(key);
        }
    }
}
