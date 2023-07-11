using bielu.multiRummykub.Models;
using bielu.multiRummykub.Models.Table;
using bielu.multiRummykub.Server.Services;

namespace bielu.multiRummykub.UnitTests.Services;

public class SetServiceTests
{
    [Fact]
    public void SetService_NoSets_SameColor_6_SingleSets__Color()
    {
        var tableService = new SetService();
        var cubes = new List<Cube>()
        {
            new Cube()
            {
                Id = Guid.NewGuid(),
                Value = 1,
                Color = 1
            },
            new Cube()
            {
                Id = Guid.NewGuid(),
                Value = 3,
                Color = 1
            },
            new Cube()
            {
                Id = Guid.NewGuid(),
                Value = 5,
                Color = 1
            },
            new Cube()
            {
                Id = Guid.NewGuid(),
                Value = 7,
                Color = 1
            },
            new Cube()
            {
                Id = Guid.NewGuid(),
                Value = 9,
                Color = 1
            }
        };
        var Sets = tableService.ProposeSets(cubes, SortType.Color);
        Assert.All(Sets, x => Assert.Single(x.Cubes));
    }
    [Fact]
    public void ProposeSets_DifferentColors_6_SingleSets__Color()
    {
        var tableService = new SetService();
        var cubes = new List<Cube>()
        {
            new Cube()
            {
                Id = Guid.NewGuid(),
                Value = 1,
                Color = 1
            },
            new Cube()
            {
                Id = Guid.NewGuid(),
                Value = 1,
                Color =2
            },
            new Cube()
            {
                Id = Guid.NewGuid(),
                Value = 5,
                Color = 2
            },
            new Cube()
            {
                Id = Guid.NewGuid(),
                Value = 7,
                Color = 2
            },
            new Cube()
            {
                Id = Guid.NewGuid(),
                Value = 9,
                Color = 1
            }
        };
        var Sets = tableService.ProposeSets(cubes, SortType.Color);
        Assert.All(Sets, x => Assert.Single(x.Cubes));
    }
    [Fact]
    public void ProposeSets_DifferentColors_2_tripleSets_Color()
    {
        var tableService = new SetService();
        var cubes = new List<Cube>()
        {
            new Cube()
            {
                Id = Guid.NewGuid(),
                Value = 6,
                Color = 1
            },
            new Cube()
            {
                Id = Guid.NewGuid(),
                Value = 1,
                Color = 1
            },
            new Cube()
            {
                Id = Guid.NewGuid(),
                Value = 5,
                Color = 1
            },
            new Cube()
            {
                Id = Guid.NewGuid(),
                Value = 2,
                Color =1
            },
            new Cube()
            {
                Id = Guid.NewGuid(),
                Value = 3,
                Color = 1
            },
         
           
            new Cube()
            {
                Id = Guid.NewGuid(),
                Value =7,
                Color = 1
            }
        };
        var Sets = tableService.ProposeSets(cubes, SortType.Color);
        Assert.All(Sets, x => Assert.Equal(3,x.Cubes.Count()));
    }
    
    [Fact]
    public void SetService_NoSets_DifferentColor_6_SingleSets_Value()
    {
        var tableService = new SetService();
        var cubes = new List<Cube>()
        {
            new Cube()
            {
                Id = Guid.NewGuid(),
                Value = 1,
                Color = 2
            },
            new Cube()
            {
                Id = Guid.NewGuid(),
                Value = 3,
                Color = 3
            },
            new Cube()
            {
                Id = Guid.NewGuid(),
                Value = 5,
                Color = 4
            },
            new Cube()
            {
                Id = Guid.NewGuid(),
                Value = 7,
                Color = 5
            },
            new Cube()
            {
                Id = Guid.NewGuid(),
                Value = 9,
                Color = 6
            }
        };
        var Sets = tableService.ProposeSets(cubes, SortType.Value);
        Assert.All(Sets, x => Assert.Single(x.Cubes));
    }
    [Fact]
    public void SetService_NoSets_mixedColor_6_SingleSets_Value()
    {
        var tableService = new SetService();
        var cubes = new List<Cube>()
        {
            new Cube()
            {
                Id = Guid.NewGuid(),
                Value = 1,
                Color = 1
            },
            new Cube()
            {
                Id = Guid.NewGuid(),
                Value = 1,
                Color = 1
            },
            new Cube()
            {
                Id = Guid.NewGuid(),
                Value = 2,
                Color = 1
            },
            new Cube()
            {
                Id = Guid.NewGuid(),
                Value = 3,
                Color = 1
            },
            new Cube()
            {
                Id = Guid.NewGuid(),
                Value = 3,
                Color = 1
            }
        };
        var Sets = tableService.ProposeSets(cubes, SortType.Value);
        Assert.All(Sets, x => Assert.Single(x.Cubes));
    }
}