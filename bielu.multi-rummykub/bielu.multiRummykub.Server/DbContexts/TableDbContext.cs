using bielu.multiRummykub.Models.Table;
using Microsoft.EntityFrameworkCore;

namespace bielu.multiRummykub.Server.DbContexts;

public class TableDbContext: DbContext
{
    public TableDbContext(DbContextOptions<TableDbContext> options) : base(options)
    {
    }
        
    public DbSet<Table> Tables { get; set; }
}