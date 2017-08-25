namespace XY.Component.Abstract
{
    public interface IRedisCache
    {
        bool StringSet(string key, string value);
    }
}
