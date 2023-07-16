using Microsoft.EntityFrameworkCore;
using bielu.multiRummykub.Models.Player;
using bielu.multiRummykub.Models.Table;

namespace bielu.multiRummykub.Server.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
        
    public DbSet<Player> Players { get; set; }
    public DbSet<CubeSet> CubeSets { get; set; }
    public DbSet<Table> Tables { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Table>()
            .HasMany<Player>(x=>x.Players)
            .WithOne(x=>x.TableId)
            .HasForeignKey(x=>x.Id);
    }

}