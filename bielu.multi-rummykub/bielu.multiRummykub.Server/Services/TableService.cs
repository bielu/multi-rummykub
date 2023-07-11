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
            Id = Guid.NewGuid(),
            Cubes = GenerateCubes(maxPlayers,scaleType ),
            Players = new List<Guid>(),
            MaxPlayers = maxPlayers,
            ScaleType = scaleType
        };

       // return _tableDbContext.Tables.Add(table).Entity;
       return table;
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