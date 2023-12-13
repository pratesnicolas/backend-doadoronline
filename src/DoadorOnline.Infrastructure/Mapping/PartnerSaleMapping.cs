using DoadorOnline.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoadorOnline.Infrastructure.Mapping;

public class PartnerSaleMapping : IEntityTypeConfiguration<PartnerSale>
{
    public void Configure(EntityTypeBuilder<PartnerSale> builder)
    {
        builder.ToTable("PartnerSales");
        builder.HasKey(x => x.Id);
    }
}
