using DoadorOnline.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoadorOnline.Infrastructure;

public class DonationIntentionMapping : IEntityTypeConfiguration<DonationIntention>
{
    public void Configure(EntityTypeBuilder<DonationIntention> builder)
    {
        builder.ToTable("DonationIntentions");
    }
}

