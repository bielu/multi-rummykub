using Microsoft.EntityFrameworkCore;
using bielu.multiRummykub.Models.Player;

namespace bielu.multiRummykub.Server.DbContexts;

public class PlayerDbContext : DbContext
{
    public PlayerDbContext(DbContextOptions<PlayerDbContext> options) : base(options)
    {
    }
        
    public DbSet<Player> Players { get; set; }
}