using FluentResults;

namespace Carpool.BLL.Common.Errors
{
    public class RideAlreadyExist : IError
    {
        public List<IError> Reasons => new List<IError>();

        public string Message => "The student already has a ride scheduled";

        public Dictionary<string, object> Metadata => new Dictionary<string, object>()
        {
            {Constants.ErrorType, ErrorType.Conflit }
        };
    }
}
