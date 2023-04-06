using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp.Features.Directions;

public class DirectionConfiguration : IEntityTypeConfiguration<Direction>
{
    private const int NameMaxLength = 100;
    
    public void Configure(EntityTypeBuilder<Direction> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                x => x.Value, 
                x => new DirectionId(x));

        builder.Property(x => x.Name).HasMaxLength(NameMaxLength).IsRequired();
    }
}