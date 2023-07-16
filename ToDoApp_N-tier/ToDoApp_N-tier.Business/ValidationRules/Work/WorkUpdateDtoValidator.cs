using FluentValidation;
using ToDoApp_N_tier.Dtos.WorkDtos;

namespace ToDoApp_N_tier.Business.ValidationRules.Work
{
    public class WorkUpdateDtoValidator:AbstractValidator<WorkUpdateDto>
    {
        public WorkUpdateDtoValidator()
        {
            RuleFor(x=>x.Id).NotEmpty();
            RuleFor(x=>x.Definition).NotEmpty();
        }
    }
}
