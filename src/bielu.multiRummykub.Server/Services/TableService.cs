using System.Drawing;
using bielu.multiRummykub.Models;
using bielu.multiRummykub.Models.Player;
using bielu.multiRummykub.Models.Table;
using bielu.multiRummykub.Server.DbContexts;

namespace bielu.multiRummykub.Server.Services;

public interface ITableService
{
    Table GetTable(Guid tableId);    
    List<Table> GetTables(int page, int pageSize);

    Table CreateTable(int maxPlayers, ScaleType scaleType = ScaleType.Duplicates);
    List<Cube> GenerateCubes(int maxPlayer, ScaleType scaleType = ScaleType.Duplicates);
    bool AddPlayer(Guid tableId, Player playerId);
    bool RemovePlayer(Guid tableId, Player playerId);

    Task<Table> GetCurrentTable();
}
public class TableService : ITableService
{
    private readonly AppDbContext _dbContext;

    public TableService(AppDbContext _dbContext)
    {
        this._dbContext = _dbContext;
    }
    public Table GetTable(Guid tableId)
    {
        return _dbContext.Tables.FirstOrDefault(x => x.Id == tableId);
    }

    public List<Table> GetTables(int page, int pageSize)
    {
        return _dbContext.Tables.Skip((page-1) * pageSize).Take(pageSize).ToList();
    }

    public Table CreateTable(int maxPlayers , ScaleType scaleType = ScaleType.Duplicates)
    {
        var table = new Table
        {
            Id = Guid.NewGuid(),
            Cubes = GenerateCubes(maxPlayers,scaleType ),
            Players = new List<Player>(),
            MaxPlayers = maxPlayers,
            ScaleType = scaleType
        };
        var tagetTable = _dbContext.Tables.Add(table).Entity;
        _dbContext.SaveChanges();
       return tagetTable;
    }

    public List<Cube> GenerateCubes(int maxPlayer, ScaleType scaleType = ScaleType.Duplicates)
    {
        return scaleType switch
        {
            ScaleType.Duplicates => GenerateCubesForDuplicates(maxPlayer),
            ScaleType.Colors => GenerateCubesForColors(maxPlayer),
        };
    }

    private List<Cube> GenerateCubesForColors(int maxPlayer)
    {
        var cubes = new List<Cube>();
        maxPlayer = Int32.Max(4, maxPlayer);
        for (var i = 0; i < maxPlayer; i++)
        {
            for (var j = 0; j < 13; j++)
            {
                cubes.Add(new Cube
                {
                    Id = Guid.NewGuid(),
                    Color = i,
                    Value = j
                });
                cubes.Add(new Cube
                {
                    Id = Guid.NewGuid(),
                    Color = i,
                    Value = j
                });
            }
        }
        GenerateJokers(maxPlayer, cubes);
        return cubes;
    }

    private List<Cube> GenerateCubesForDuplicates(int maxPlayer)
    {
        var cubes = new List<Cube>();
      
        for (var i = 0; i < 4; i++)
        {
            for (var j = 0; j < 13; j++)
            {
                cubes.Add(new Cube
                {
                    Id = Guid.NewGuid(),
                    Color = i,
                    Value = j
                });
                cubes.Add(new Cube
                {
                    Id = Guid.NewGuid(),
                    Color = i,
                    Value = j
                });
            }
        }

        if (maxPlayer > 4)
        {
            var maxDuplicatedSets = (maxPlayer-4) / (decimal)2;
            for(var repeat = 0; repeat < maxDuplicatedSets; repeat++)
            {
               
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 13; j++)
                {
                    cubes.Add(new Cube
                    {
                        Id = Guid.NewGuid(),
                        Color = i,
                        Value = j
                    });
                }
            }
            }

        }
        GenerateJokers(maxPlayer, cubes);
       
        return cubes;
    }

    private void GenerateJokers(int maxPlayer, List<Cube> cubes)
    {
        var maxJokers = (maxPlayer) / (decimal)2;
        if(maxJokers %2 != 0 && maxPlayer > 4)
        {
            maxJokers = maxJokers +1;
        }else if(maxPlayer <= 4)
        {
            maxJokers = 2;
        }
        for (var i = 0; i < maxJokers; i++)
        {
            cubes.Add(new Cube
            {
                Id = Guid.NewGuid(),
                Color = i,
                IsJoker = true
            });
        }
    }

    public bool AddPlayer(Guid tableId, Player playerId)
    {
        var table = GetTable(tableId);
        if (table.Players.Count() >= table.MaxPlayers)
        {
            return false;
        }

        if (table.Players.Contains(playerId))
        {
            return false;
        }

        table.Players= table.Players.Union(new List<Player>(){playerId});
        
        return UpdateTable(table);
    }

    private bool UpdateTable(Table table)
    {
        var result = _dbContext.Tables.Update(table);
        //todo: validate result
        return true;
    }

    public bool RemovePlayer(Guid tableId, Player playerId)
    {
        var table = GetTable(tableId);

        if (!table.Players.Contains(playerId))
        {
            return true;
        }
        table.Players= table.Players.Except(new List<Player>(){playerId});

        return UpdateTable(table);
    }

    public async Task<Table> GetCurrentTable()
    {
        return _dbContext.Tables.FirstOrDefault();
    }
}