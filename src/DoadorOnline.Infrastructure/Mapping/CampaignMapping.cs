using DoadorOnline.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoadorOnline.Infrastructure;

public class CampaignMapping : IEntityTypeConfiguration<Campaign>
{
    public void Configure(EntityTypeBuilder<Campaign> builder)
    {

        builder.ToTable("Campaigns");
    }
}
