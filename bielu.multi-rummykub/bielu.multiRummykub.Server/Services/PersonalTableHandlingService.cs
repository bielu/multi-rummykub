using bielu.multiRummykub.Models;
using bielu.multiRummykub.Models.PersonalBoard;
using bielu.multiRummykub.Models.Table;
using bielu.multiRummykub.Server.DbContexts;

namespace bielu.multiRummykub.Server.Services;

public class PersonalTableHandlingService
{
    private readonly ISetService _service;


    public PersonalTableHandlingService(ISetService service)
    {
        _service = service;
    }

    public PersonalBoard CreatePersonalBoard()
    {
        return new PersonalBoard
        {
            Cubes = new List<Cube>(),
            PlayerAchievedFirstMove = false
        };
    }
    public PersonalBoard GetPersonalBoard(Guid personalBoardId)
    {
     
    }
    public void AddCubeToPersonalBoard(Guid personalBoard, Cube cube)
    {
        GetPersonalBoard(personalBoard).Cubes.Add(cube);
    }

    public CubeSet CreateSet(params Guid[] cubes)
    {
        var cubeSet = new CubeSet();
        return cubeSet;
    }
    public IList<CubeSet> ProposeSets(Guid personalBoard, SortType type)
    {
        var cubes = GetPersonalBoard(personalBoard).Cubes.Where(x=>!x.Locked).ToList();
        return _service.ProposeSets(cubes, type);
    }
}