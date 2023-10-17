using DoadorOnline.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DoadorOnline.Infrastructure;

public class IdentityRolesMapping : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        var roleHospital = new IdentityRole
        {
            Name = CustomRoleTypes.Hospital,
            NormalizedName = CustomRoleTypes.Hospital,
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            Id = CustomRoleTypes.Hospital
        };

        var roleDonator = new IdentityRole
        {
            Name = CustomRoleTypes.Donator,
            NormalizedName = CustomRoleTypes.Donator,
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            Id = CustomRoleTypes.Donator
        };

        var roleDonee = new IdentityRole
        {
            Name = CustomRoleTypes.Donee,
            NormalizedName = CustomRoleTypes.Donee,
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            Id = CustomRoleTypes.Donee
        };


        builder.HasData(roleHospital,
                        roleDonee,
                        roleDonator);
    }
}

