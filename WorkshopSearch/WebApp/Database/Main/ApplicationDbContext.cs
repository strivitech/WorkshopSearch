using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WebApp.Features.Directions;
using WebApp.Features.Workshops;

namespace WebApp.Database.Main;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Direction> Directions => Set<Direction>();
    public DbSet<Workshop> Workshops => Set<Workshop>();

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // Here custom logic

        return await base.SaveChangesAsync(cancellationToken);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Here custom logic
    }
}