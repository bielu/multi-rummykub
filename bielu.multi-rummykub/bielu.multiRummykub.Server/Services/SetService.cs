using bielu.multiRummykub.Models;
using bielu.multiRummykub.Models.Table;

namespace bielu.multiRummykub.Server.Services;

public class SetService : ISetService
{
    public IList<CubeSet> ProposeSets(IList<Cube> cubes, SortType type)
    {
        return type switch
        {
            SortType.Color => ProposeColorSets(cubes),
            SortType.Value => ProposeValueSets(cubes),
        };
    }

    private IList<CubeSet> ProposeValueSets(IList<Cube> cubes)
    {
        var colorGroups = cubes.GroupBy(x => x.Value);
        var sets = new List<CubeSet>();
        foreach (var group in colorGroups)
        {
            var set = new CubeSet()
            {
                Id = new Guid(),
                Type = SetType.Color,
                Valid = true,
                Cubes = group.OrderBy(x => x.Value).ToList()
            };
            sets.Add(set);
        }

        return sets;
    }

    private IList<CubeSet> ProposeColorSets(IList<Cube> cubes)
    {
        var colorGroups = GroupByColor(cubes);
        var sets = new List<CubeSet>();
        foreach (var group in colorGroups)
        {
            var sortedCubes = group.OrderBy(x => x.Value).ToList();
            var tempSet = new CubeSet()
            {
                Id = new Guid(),
                Type = SetType.Color,
                Valid = true
            };
            foreach (var cube in sortedCubes)
            {
                if (tempSet.Cubes.Count == 0)
                {
                    tempSet.Cubes.Add(cube);
                }
                else if (tempSet.Cubes.Last().Value == cube.Value - 1)
                {
                    tempSet.Cubes.Add(cube);
                }
                else
                {
                    sets.Add(tempSet);
                    tempSet = new CubeSet();
                    tempSet.Cubes.Add(cube);
                }
            }
        }

        return sets;
    }

    public IEnumerable<IGrouping<int, Cube>> GroupByColor(IList<Cube> cubes)
    {
        return cubes.GroupBy(x => x.Color);
    }
}

public interface ISetService
{
    IList<CubeSet> ProposeSets(IList<Cube> cubes, SortType type);
}