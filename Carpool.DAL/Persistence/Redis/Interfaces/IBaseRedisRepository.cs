namespace Carpool.DAL.Persistence.Redis.Interfaces
{
    public interface IBaseRedisRepository
    {
        Task SaveCache<T>(string key, T data);
        Task<T> GetCache<T>(string key);
    }
}
