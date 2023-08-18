using FluentResults;

namespace Carpool.BLL.Common.Errors
{
    public class CampusNotFound : IError
    {
        public string Message => "The given [campusId] doesn't exist";
        public Dictionary<string, object> Metadata => new Dictionary<string, object>()
        {
            { Constants.ErrorType, ErrorType.NotFound }
        };
        public List<IError> Reasons => new List<IError>();
    }
}
