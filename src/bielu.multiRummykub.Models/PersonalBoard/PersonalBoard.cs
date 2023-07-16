using bielu.multiRummykub.Models.Table;

namespace bielu.multiRummykub.Models.PersonalBoard;

public class PersonalBoard
{
    public Guid Id { get; set; }
    public Guid PlayerId { get; set; }
    public IList<Cube> Cubes { get; set; }
    public bool PlayerAchievedFirstMove { get; set; }
    public IList<CubeSet> Sets { get; set; } = new List<CubeSet>();
    public IList<CubeSet> LockSets { get; set; } = new List<CubeSet>();

}