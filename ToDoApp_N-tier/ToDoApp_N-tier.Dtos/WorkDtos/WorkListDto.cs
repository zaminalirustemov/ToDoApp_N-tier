using ToDoApp_N_tier.Dtos.Interfaces;

namespace ToDoApp_N_tier.Dtos.WorkDtos
{
    public class WorkListDto:IDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}
