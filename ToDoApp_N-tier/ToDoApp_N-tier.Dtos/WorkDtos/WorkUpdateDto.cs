using System.ComponentModel.DataAnnotations;
using ToDoApp_N_tier.Dtos.Interfaces;

namespace ToDoApp_N_tier.Dtos.WorkDtos
{
    public class WorkUpdateDto : IDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "Id is requried")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Definition is requried")]
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}
