using Microsoft.Extensions.Caching.Memory;

namespace Carpool.DAL.Infrastructure.Services.Student
{
    public class CachedStudentService : IStudentService
    {
        private readonly IStudentService _decorated;
        private readonly IMemoryCache _memoryCache;
        public CachedStudentService(IStudentService studentService, IMemoryCache memoryCache)
        {
            _decorated = studentService;
            _memoryCache = memoryCache;
        }

        public Task<Model.Student> GetStudentBasicInfos(int studentId)
        {
            string key = $"student-{studentId}";

            return _memoryCache.GetOrCreateAsync(
                key,
                entry =>
                {
                    entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
                    return _decorated.GetStudentBasicInfos(studentId);
                });
        }
    }
}
