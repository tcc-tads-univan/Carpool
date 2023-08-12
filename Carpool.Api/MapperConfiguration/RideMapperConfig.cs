using Carpool.Api.Contracts.Ride;
using Carpool.Api.Contracts.Ride.Response;
using Carpool.BLL.Services.Ride.Models.Command;
using Carpool.BLL.Services.Ride.Models.Result;
using Carpool.DAL.Domain;
using Mapster;

namespace Carpool.Api.MapperConfiguration
{
    public class RideMapperConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RideCreateRequest, RideCreateCommand>();
            config.NewConfig<RideDeleteRequest, RideDeleteCommand>();
            config.NewConfig<RideResult, RideResponse>();
            config.NewConfig<RideStudentResult, RideStudentResponse>();
        }
    }
}
