using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp.Features.Workshops;

public class WorkshopConfiguration : IEntityTypeConfiguration<Workshop>
{
    private const int TitleMaxLength = 100;
    private const int DescriptionMaxLength = 10000;
    private const int OwnerMaxLength = 200;
    private const int EmailMaxLength = 50;
    private const int PhoneNumberMaxLength = 20;
    private const int ImageUrisMaxLength = 1000;
    private const int RatingMaxLength = 5;
    private const int RegionMaxLength = 100;
    private const int CityMaxLength = 100;
    private const int StreetMaxLength = 100;
    private const int BuildingNumberMaxLength = 10;
    

    public void Configure(EntityTypeBuilder<Workshop> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                x => x.Value,
                x => new WorkshopId(x));

        builder.Property(x => x.Title).HasMaxLength(TitleMaxLength).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(DescriptionMaxLength).IsRequired();
        builder.Property(x => x.Owner).HasMaxLength(OwnerMaxLength).IsRequired();
        builder.Property(x => x.Rating).HasMaxLength(RatingMaxLength);

        builder.OwnsOne(x => x.Address,
            ownedBuilder =>
            {
                ownedBuilder.Property(x => x.Region).HasMaxLength(RegionMaxLength);
                ownedBuilder.Property(x => x.City).HasMaxLength(CityMaxLength).IsRequired();
                ownedBuilder.Property(x => x.Street).HasMaxLength(StreetMaxLength).IsRequired();
                ownedBuilder.Property(x => x.BuildingNumber).HasMaxLength(BuildingNumberMaxLength).IsRequired();
            });
        
        builder.OwnsOne(x => x.ContactInformation,
            ownedBuilder =>
            {
                ownedBuilder.Property(x => x.Email).HasMaxLength(EmailMaxLength).IsRequired();
                ownedBuilder.Property(x => x.PhoneNumber).HasMaxLength(PhoneNumberMaxLength).IsRequired();
                ownedBuilder.Property(x => x.ContactLinks)
                    .HasConversion(
                        x => string.Join(',', x),
                        x => x.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList())
                    .Metadata.SetValueComparer(StringListValueComparer());
            });

        builder.OwnsOne(x => x.Constrains,
            ownedBuilder =>
            {
                ownedBuilder.Property(x => x.MinAge);
                ownedBuilder.Property(x => x.MaxAge);
            });

        builder.Property(x => x.ImageUris)
            .HasMaxLength(ImageUrisMaxLength)
            .HasConversion(
                x => string.Join(',', x),
                x => x.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList())
            .Metadata.SetValueComparer(StringListValueComparer());
        
        builder.Property(x => x.CoverImageUri).HasMaxLength(ImageUrisMaxLength).IsRequired();

        builder.HasMany(x => x.Directions)
            .WithMany();
    }
    
    private static ValueComparer<List<string>> StringListValueComparer() => new(
        (c1, c2) => c1!.SequenceEqual(c2!),
        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
        c => c.ToList());
}