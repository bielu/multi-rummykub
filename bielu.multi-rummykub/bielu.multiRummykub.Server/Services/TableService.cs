using bielu.multiRummykub.Models;
using bielu.multiRummykub.Models.Table;
using bielu.multiRummykub.Server.DbContexts;

namespace bielu.multiRummykub.Server.Services;

public class TableService
{
    private readonly TableDbContext _tableDbContext;
    private readonly PlayerDbContext _playerDbContext;

    public TableService(TableDbContext tableDbContext, PlayerDbContext playerDbContext)
    {
        _tableDbContext = tableDbContext;
        _playerDbContext = playerDbContext;
    }
    public Table GetTable(Guid tableId)
    {
        return _tableDbContext.Tables.FirstOrDefault(x => x.Id == tableId);
    }

    public Table CreateTable(int maxPlayers)
    {
        var table = new Table
        {
            Cubes = new List<Cube>(),
            Players = new List<Guid>(),
            MaxPlayers = maxPlayers
        };

        return _tableDbContext.Tables.Add(table).Entity;
    }

    public bool AddPlayer(Guid tableId, Guid playerId)
    {
        var table = GetTable(tableId);
        if (table.Players.Count >= table.MaxPlayers)
        {
            return false;
        }

        if (table.Players.Contains(playerId))
        {
            return false;
        }

        table.Players.Add(playerId);
        
        return UpdateTable(table);
    }

    private bool UpdateTable(Table table)
    {
        var result = _tableDbContext.Tables.Update(table);
        //todo: validate result
        return true;
    }

    public bool RemovePlayer(Guid tableId, Guid playerId)
    {
        var table = GetTable(tableId);

        if (!table.Players.Contains(playerId))
        {
            return true;
        }

        table.Players.Remove(playerId);
        return UpdateTable(table);
    }
}