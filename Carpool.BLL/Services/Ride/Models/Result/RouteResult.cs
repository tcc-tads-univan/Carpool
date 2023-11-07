namespace Carpool.BLL.Services.Ride.Models.Result
{
    public class RouteResult
    {
        public RouteResult(string googlePath)
        {
            GooglePath = googlePath;
        }

        public string GooglePath { get; set; }
    }
}
