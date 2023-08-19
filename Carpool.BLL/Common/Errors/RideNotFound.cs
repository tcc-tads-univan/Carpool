using FluentResults;

namespace Carpool.BLL.Common.Errors
{
    public class RideNotFound : IError
    {
        public List<IError> Reasons => new List<IError>();

        public string Message => "The ride was not found.";

        public Dictionary<string, object> Metadata => new Dictionary<string, object>()
        {
            {Constants.ErrorType, ErrorType.NotFound }
        };
    }
}
