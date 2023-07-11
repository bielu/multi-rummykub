using bielu.multiRummykub.Models.Player;
using bielu.multiRummykub.Models.Table;
using Microsoft.EntityFrameworkCore;

namespace bielu.multiRummykub.Server.DbContexts;

public class SetDbContext: DbContext
{
    public SetDbContext(DbContextOptions<SetDbContext> options) : base(options)
    {
    }
        
    public DbSet<CubeSet> CubeSets { get; set; }
}