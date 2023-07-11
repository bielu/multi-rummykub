using System.Drawing;
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

    public Table CreateTable(int maxPlayers , ScaleType scaleType = ScaleType.Duplicates)
    {
        var table = new Table
        {
            Cubes = GenerateCubes(maxPlayers,scaleType ),
            Players = new List<Guid>(),
            MaxPlayers = maxPlayers,
            ScaleType = scaleType
        };

        return _tableDbContext.Tables.Add(table).Entity;
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
            }
        }

        if (maxPlayer > 4)
        {
            for (var i = 0; i < (maxPlayer-4)/2; i++)
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
        GenerateJokers(maxPlayer, cubes);
       
        return cubes;
    }

    private void GenerateJokers(int maxPlayer, List<Cube> cubes)
    {
        for (var i = 0; i < maxPlayer/2; i++)
        {
            cubes.Add(new Cube
            {
                Id = Guid.NewGuid(),
                Color = i,
                IsJoker = true
            });
        }
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