using System.ComponentModel.DataAnnotations;

namespace bielu.multiRummykub.Models.Table;

public class Table
{
    public IList<Cube> Cubes { get; set; }
    public bool Private { get; set; }
    public string Password { get; set; }
    private IList<Cube> CubesOnStack { get; set; } = new List<Cube>();
    public IList<CubeSet> CubesOnTable { get; set; } = new List<CubeSet>();
    public IList<PersonalBoard.PersonalBoard> PersonalBoard { get; set; } = new List<PersonalBoard.PersonalBoard>();
    public IEnumerable<Player.Player> Players { get; set; }
    public int MaxPlayers { get; set; }
    public ScaleType ScaleType { get; set; }
    [Key]
    public Guid Id { get; set; }
    public Guid TableOwner { get; set; }

    public void ShuffleCubes()
    {
        var usedCubes = new List<Cube>();
        PersonalBoard?.Clear();
        CubesOnStack.Clear();
        CubesOnTable.Clear();
        foreach (var player in Players)
        {
            var cubes = Cubes.Where(x => !usedCubes.Contains(x)).OrderBy(x=>Guid.NewGuid()).Take(14).ToList();
            PersonalBoard.Add(new PersonalBoard.PersonalBoard()
            {
                Cubes = cubes,
                PlayerId = player.Id,
                Id = Guid.NewGuid()
            });
            usedCubes.AddRange(cubes);

        }
    }
}