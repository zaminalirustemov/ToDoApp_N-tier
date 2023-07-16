using ToDoApp_N_tier.Common.Enums;

namespace ToDoApp_N_tier.Common.ResponseObjects
{
    public interface IResponse
    {
        string Message { get; set; }
        ResponseType ResponseType { get; set; }
    }
}
