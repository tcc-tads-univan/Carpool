using Azure;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Carpool.DAL.Infrastructure.Services.Student
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient _client;
        private readonly ILogger<StudentService> _logger;

        public StudentService(HttpClient client, ILogger<StudentService> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<Model.Student> GetStudentBasicInfos(int studentId)
        {
            //Decorator
            try
            {
                HttpRequestMessage request = new HttpRequestMessage();
                request.Method = HttpMethod.Get;
                request.RequestUri = new Uri($"/student/{studentId}/basic-infos");
                //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "");

                var response = await _client.SendAsync(request);

                response.EnsureSuccessStatusCode();

                var studentJson = await response.Content.ReadAsStringAsync();
                var student = JsonSerializer.Deserialize<Model.Student>(studentJson);
                return student;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "[Univan] Fail to retrieve student information");
                return null;
            }
        }
    }
}
