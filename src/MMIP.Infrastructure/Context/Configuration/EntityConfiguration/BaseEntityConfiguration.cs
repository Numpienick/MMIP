using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Context.Configuration.EntityConfiguration;

internal class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity
{
    protected const int DESCRIPTION_MAX_LENGTH = 100000;
    protected const int SHORT_DESCRIPTION_MAX_LENGTH = 150;

    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.CreatedDate).HasDefaultValueSql("NOW()");
        builder.Property(b => b.UpdatedDate).HasDefaultValueSql("NOW()");
    }
}
