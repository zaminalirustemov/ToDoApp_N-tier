namespace ToDoApp_N_tier.Common.ResponseObjects
{
    public interface IResponse<T>:IResponse
    {
        T Data { get; set; }

        List<CustomValidationError> ValidationErrors { get; set; }
    }
}
