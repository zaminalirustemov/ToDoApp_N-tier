using System.ComponentModel.DataAnnotations;
using ToDoApp_N_tier.Dtos.Interfaces;

namespace ToDoApp_N_tier.Dtos.WorkDtos
{
    public class WorkCreateDto : IDto
    {
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}
