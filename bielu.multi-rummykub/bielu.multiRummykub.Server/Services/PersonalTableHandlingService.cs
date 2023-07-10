using bielu.multiRummykub.Models;
using bielu.multiRummykub.Models.PersonalBoard;
using bielu.multiRummykub.Models.Table;

namespace bielu.multiRummykub.Server.Services;

public class PersonalTableHandlingService
{
    public PersonalTableHandlingService()
    {
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

    public Guid CreateSet(params Guid[] cubes)
    {
        var cubeSet = new CubeSet();
        
    }
    public Guid ProposeSet(Guid personalBoard, SortType type)
    {
        var cubes = GetPersonalBoard(personalBoard).Cubes;

    }
}