using FluentValidation;
using ToDoApp_N_tier.Dtos.WorkDtos;

namespace ToDoApp_N_tier.Business.ValidationRules.Work
{
    public class WorkCreateDtoValidator:AbstractValidator<WorkCreateDto>
    {
        public WorkCreateDtoValidator()
        {
            RuleFor(x=>x.Definition).NotEmpty();
        }
    }
}
