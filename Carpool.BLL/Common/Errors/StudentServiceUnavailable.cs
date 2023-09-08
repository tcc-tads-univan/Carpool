using FluentResults;

namespace Carpool.BLL.Common.Errors
{
    public class StudentServiceUnavailable : IError
    {
        public List<IError> Reasons => new List<IError>();

        public string Message => "Internal service error";

        public Dictionary<string, object> Metadata => new Dictionary<string, object>
        {
            { Constants.ErrorType, ErrorType.BadGateway }
        }
    }
}
