using Carpool.Api.Contracts.Schedule.Request;
using Carpool.Api.Contracts.Schedule.Response;
using Carpool.BLL.Services.Schedule.Models.Command;
using Carpool.BLL.Services.Schedule.Models.Result;
using Mapster;

namespace Carpool.Api.MapperConfiguration
{
    public class ScheduleMapperConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ScheduleCreateRequest, ScheduleCreateCommand>();
            config.NewConfig<ScheduleResult, ScheduleResponse>();
            config.NewConfig<ScheduleAcceptedResult, ScheduleAcceptedResponse>();
        }
    }
}
