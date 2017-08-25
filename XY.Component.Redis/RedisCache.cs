using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
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

        #region hash
        public bool HashSet(string key, string field, string value)
        {
            return db.HashSet(key, field, value);
        }
        public async Task<bool> HashSetAsync(string key, string field, string value)
        {
            return await db.HashSetAsync(key, field, value);
        }
        public void HashSet(string key, Dictionary<string, string> dict)
        {
            db.HashSet(key, dict.Select(d => new HashEntry(d.Key, d.Value)).ToArray());
        }
        public async Task HashSetAsync(string key, Dictionary<string, string> dict)
        {
            await db.HashSetAsync(key, dict.Select(d => new HashEntry(d.Key, d.Value)).ToArray());
        }
        public string HashGet(string key, string field)
        {
            return db.HashGet(key, field);
        }
        public async Task<string> HashGetAsync(string key, string field)
        {
            return await db.HashGetAsync(key, field);
        }
        public Dictionary<string, string> HashGetAll(string key)
        {
            var entities = db.HashGetAll(key);
            return entities.ToStringDictionary();
        }
        public async Task<Dictionary<string, string>> HashGetAllAsync(string key)
        {
            var entities = await db.HashGetAllAsync(key);
            return entities.ToStringDictionary();
        }
        #endregion

        #region string
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
        #endregion

        #region list
        public long ListRightPush(string key, string value)
        {
            return db.ListRightPush(key, value);
        }
        public async Task<long> ListRightPushAsync(string key, string value)
        {
            return await db.ListRightPushAsync(key, value);
        }
        public string ListLeftPop(string key)
        {
            return db.ListLeftPop(key);
        }
        public async Task<string> ListLeftPopAsync(string key)
        {
            return await db.ListLeftPopAsync(key);
        }
        public string[] ListRange(string key)
        {
            List<string> list = new List<string>();
            var values = db.ListRange(key);
            foreach (var item in values)
            {
                list.Add(item);
            }
            return list.ToArray();
        }
        #endregion

        #region set
        public bool SetAdd(string key, string value)
        {
            return db.SetAdd(key, value);
        }
        public async Task<bool> SetAddAsync(string key, string value)
        {
            return await db.SetAddAsync(key, value);
        }
        public string SetPop(string key)
        {
            return db.SetPop(key);
        }
        public async Task<string> SetPopAsync(string key)
        {
            return await db.SetPopAsync(key);
        }
        public string[] SetMembers(string key)
        {
            List<string> list = new List<string>();
            var values = db.SetMembers(key);
            foreach (var item in values)
            {
                list.Add(item);
            }
            return list.ToArray();
        }
        public async Task<string[]> SetMembersAsync(string key)
        {
            List<string> list = new List<string>();
            var values = await db.SetMembersAsync(key);
            foreach (var item in values)
            {
                list.Add(item);
            }
            return list.ToArray();
        }
        public string SetRandomMember(string key)
        {
            return db.SetRandomMember(key);
        }
        public async Task<string> SetRandomMemberAsync(string key)
        {
            return await db.SetRandomMemberAsync(key);
        }
        #endregion


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
