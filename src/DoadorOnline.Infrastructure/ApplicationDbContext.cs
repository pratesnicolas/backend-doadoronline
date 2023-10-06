using DoadorOnline.Domain;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DoadorOnline.Infrastructure;
public sealed class ApplicationDbContext : IdentityDbContext<User>
{
    private readonly IConfiguration _configuration;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
       : base(options)
    {
        _configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<ValidationResult>();

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        var entities = modelBuilder.Model.GetEntityTypes();
        var properties = entities.SelectMany(e => e.GetProperties());
        foreach (var property in properties.Where(p => p.ClrType == typeof(string)))
        {
            var maxLength = property.GetMaxLength() ?? 100;
            property.SetMaxLength(maxLength);
            property.SetColumnType($"varchar({maxLength})");
        }

        base.OnModelCreating(modelBuilder);
    }
}
