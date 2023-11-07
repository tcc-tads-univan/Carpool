using Carpool.DAL.Infrastructure.Services.Route.Model;

namespace Carpool.DAL.Infrastructure.Services.Route
{
    public interface IRouteService
    {
        Task<Model.RouteMap> CalculatePath(RouteRequest route);
    }
}
