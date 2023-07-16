using FluentValidation.Results;
using ToDoApp_N_tier.Common.Enums;
using ToDoApp_N_tier.Common.ResponseObjects;
using ToDoApp_N_tier.Dtos.WorkDtos;

namespace ToDoApp_N_tier.Business.Extensions
{
    public static class ValidationResultExtension
    {
        public static List<CustomValidationError> ConvertToCustomValidationError(this ValidationResult validationResult)
        {
            List<CustomValidationError> errors = new();
            foreach (var error in validationResult.Errors)
            {
                errors.Add(new()
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                });
            }
            return errors;
        }
    }
}
