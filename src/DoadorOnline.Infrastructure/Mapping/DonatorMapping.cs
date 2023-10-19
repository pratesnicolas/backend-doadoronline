using DoadorOnline.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoadorOnline.Infrastructure;

public class DonatorMapping : IEntityTypeConfiguration<Donator>
{
    public void Configure(EntityTypeBuilder<Donator> builder)
    {
        builder.HasMany(x => x.Donations)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.DonatorId);

        builder.HasMany(x => x.Addresses)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.DonatorId);

        builder.HasMany(x => x.DonationIntentions)
              .WithOne(x => x.User)
              .HasForeignKey(x => x.DonatorId);

        builder.HasKey(x => x.Id);
    }
}

