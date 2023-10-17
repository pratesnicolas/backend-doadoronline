using DoadorOnline.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoadorOnline.Infrastructure;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Donators)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

        builder.HasMany(x => x.Donations)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.UserId);

        builder.HasMany(x => x.Addresses)
              .WithOne(x => x.User)
              .HasForeignKey(x => x.UserId);

    }
}

