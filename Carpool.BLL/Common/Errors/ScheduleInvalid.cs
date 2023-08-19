using FluentResults;

namespace Carpool.BLL.Common.Errors
{
    public class ScheduleInvalid : IError
    {
        public List<IError> Reasons => new List<IError>();

        public string Message => "The schedule doesn't exist or has already been changed";

        public Dictionary<string, object> Metadata => new Dictionary<string, object>()
        {
            {Constants.ErrorType, ErrorType.Conflit }
        };
    }
}
