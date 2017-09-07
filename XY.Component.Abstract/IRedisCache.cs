using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XY.Component.Abstract
{
    public interface IRedisCache
    {
        bool HashSet(string key, string field, string value);
        Task<bool> HashSetAsync(string key, string field, string value);
        void HashSet(string key, Dictionary<string, string> dict);
        Task HashSetAsync(string key, Dictionary<string, string> dict);
        string HashGet(string key, string field);
        Task<string> HashGetAsync(string key, string field);
        Dictionary<string, string> HashGetAll(string key);
        Task<Dictionary<string, string>> HashGetAllAsync(string key);
        bool StringSet(string key, string value);
        bool StringSet(string key, string value, TimeSpan? ts);
        Task<bool> StringSetAsync(string key, string value);
        Task<bool> StringSetAsync(string key, string value, TimeSpan? ts);
        string StringGet(string key);
        Task<string> StringGetAsync(string key);
        long StringIncrement(string key);
        Task<long> StringIncrementAsync(string key);
        long ListRightPush(string key, string value);
        Task<long> ListRightPushAsync(string key, string value);
        string ListLeftPop(string key);
        Task<string> ListLeftPopAsync(string key);
        string[] ListRange(string key);
        bool SetAdd(string key, string value);
        Task<bool> SetAddAsync(string key, string value);
        string SetPop(string key);
        Task<string> SetPopAsync(string key);
        string[] SetMembers(string key);
        Task<string[]> SetMembersAsync(string key);
        string SetRandomMember(string key);
        Task<string> SetRandomMemberAsync(string key);
        bool KeyDelete(string key);
        Task<bool> KeyDeleteAsync(string key);
    }
}
