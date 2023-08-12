using Mapster;
using Carpool.BLL.Services.Campus.Models;
using Carpool.Api.Contracts.Campus.Response;

namespace Carpool.Api.MapperConfiguration
{
    public class CampusMapperConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CampusResult, CampusResponse>()
                .Map(dest => dest.CompleteLineAddress, src => FormatCompleteLineAddress(src.LineAddress, src.CEP, src.Neighborhood))
                .Map(dest => dest.College.Name, src => src.College.CollegeName);
        }

        private String FormatCompleteLineAddress(String lineAddress, String CEP, String Neighborhood)
        {
            return $"{lineAddress} - {CEP} - {Neighborhood}";
        }
    }
}
