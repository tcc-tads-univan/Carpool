using Carpool.DAL.Domain;
using Carpool.DAL.Persistence.Redis.Interfaces;
using StackExchange.Redis;
using System.Text.Json;

namespace Carpool.DAL.Persistence.Redis
{
    public class RideRepository : IRideRepository
    {
        private readonly IDatabase _redis;

        public RideRepository(IConnectionMultiplexer connection)
        {
            _redis = connection.GetDatabase();
        }
        public async Task CreateRideRequest(int campusId, Ride ride)
        {
            String serializedRide = JsonSerializer.Serialize(ride);

            var hashRide = new HashEntry[]
            {
                new HashEntry(ride.StudentId, serializedRide)
            };

            await _redis.HashSetAsync($"{campusId}", hashRide);
        }

        public async Task DeleteRideRequest(int campusId, int studentId)
        {
            await _redis.HashDeleteAsync($"{campusId}", studentId);
        }

        public async Task<IEnumerable<Ride>> GetAllRideRequests(int campusId)
        {
            var redisValues = await _redis.HashGetAllAsync($"{campusId}");

            if (redisValues.Length == 0) return new List<Ride>();

            var students = Array.ConvertAll(redisValues, val => JsonSerializer.Deserialize<Ride>(val.Value)).ToList();

            return students;
        }

        public async Task<Ride> GetStudentRideRequest(int campusId, int studentId)
        {
            var redisValue = await _redis.HashGetAsync($"{campusId}", studentId);

            if (!redisValue.HasValue) return null;

            var student = JsonSerializer.Deserialize<Ride>(redisValue.ToString());

            return student;
        }
    }
}
