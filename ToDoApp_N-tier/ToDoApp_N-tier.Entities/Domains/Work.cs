namespace ToDoApp_N_tier.Entities.Domains
{
    public class Work : BaseEntity
    {
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}
