using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoApp_N_tier.Entities.Domains;

namespace ToDoApp_N_tier.DataAccess.Configurations
{
    internal class WorkConfiguration : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Definition).HasMaxLength(300);
            builder.Property(x => x.Definition).IsRequired(true);

            builder.Property(x=>x.IsCompleted).IsRequired(true);
        }
    }
}
