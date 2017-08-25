using StackExchange.Redis;
using System;

namespace XY.Component.Redis
{
    public class RedisCacheOptions
    {
        public static string ConnectionString { get; set; }
        internal static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect(ConnectionString);
        });
    }
}
