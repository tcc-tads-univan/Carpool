using Azure;
using Carpool.DAL.Infrastructure.Services.Common;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Carpool.DAL.Infrastructure.Services.Student
{
    public class StudentService : IStudentService
    {
        private readonly IApiCaller _apiCaller;
        private readonly ILogger<StudentService> _logger;

        public StudentService(IApiCaller apiCaller, ILogger<StudentService> logger)
        {
            _apiCaller = apiCaller;
            _logger = logger;
        }

        public async Task<Model.Student> GetStudentBasicInfos(int studentId)
        {
            try
            {
                return await _apiCaller.GetUserInformation<Model.Student>(HttpMethod.Get, 
                    $"student/{studentId}/basic-infos");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "[Univan] Fail to retrieve student information");
                return null;
            }
        }
    }
}
