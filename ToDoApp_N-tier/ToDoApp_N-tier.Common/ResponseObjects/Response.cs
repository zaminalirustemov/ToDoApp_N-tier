using ToDoApp_N_tier.Common.Enums;

namespace ToDoApp_N_tier.Common.ResponseObjects
{
    public class Response:IResponse
    {
        public Response(ResponseType responseType)
        {
            ResponseType = responseType;
        }
        public Response(string message,ResponseType responseType)
        {
            Message = message;
            ResponseType = responseType;
        }
        public string Message { get; set; }
        public ResponseType ResponseType { get; set; }

    }
}
