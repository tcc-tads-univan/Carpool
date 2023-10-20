using FluentResults;

namespace Carpool.BLL.Common.Errors
{
    public class CampusNotFound : IError
    {
        public string Message => "The campus was not found.";
        public Dictionary<string, object> Metadata => new Dictionary<string, object>()
        {
            { Constants.ErrorType, ErrorType.NotFound }
        };
        public List<IError> Reasons => new List<IError>();
    }
}
