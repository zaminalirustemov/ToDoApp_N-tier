using ToDoApp_N_tier.Common.Enums;

namespace ToDoApp_N_tier.Common.ResponseObjects
{
    public class Response<T> : Response, IResponse<T>
    {
        public Response(ResponseType responseType,T data):base(responseType)
        {
            Data = data;
        }

        public Response(ResponseType responseType, string message) : base(message,responseType)
        {
        }

        public Response(ResponseType responseType, T data, List<CustomValidationError> errors) : base(responseType)
        {
            ValidationErrors = errors;
            Data = data;
        }
        public T Data { get; set ; }
        public List<CustomValidationError> ValidationErrors { get ; set; }
    }
}
