using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;
using ToDoApp_N_tier.DataAccess.Configurations;
using ToDoApp_N_tier.Entities.Domains;

namespace ToDoApp_N_tier.DataAccess.Contexts
{
    public class ToDoContext:DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new WorkConfiguration());
        }
        public DbSet<Work> Works { get; set; }
    }
}
