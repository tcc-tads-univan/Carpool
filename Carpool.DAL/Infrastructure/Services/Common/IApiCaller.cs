namespace Carpool.DAL.Infrastructure.Services.Common
{
    public interface IApiCaller
    {
        Task<T> GetUserInformation<T>(HttpMethod method, string url);
    }
}
