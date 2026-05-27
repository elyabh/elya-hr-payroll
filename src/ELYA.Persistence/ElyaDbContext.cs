using Microsoft.EntityFrameworkCore;

namespace ELYA.Persistence;

public class ElyaDbContext : DbContext
{
    public ElyaDbContext(DbContextOptions<ElyaDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ElyaDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
