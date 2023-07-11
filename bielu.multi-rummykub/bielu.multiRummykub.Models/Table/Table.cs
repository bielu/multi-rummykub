namespace bielu.multiRummykub.Models.Table;

public class Table
{
    public IList<Cube> Cubes { get; set; }
    public IList<Guid> Players { get; set; }
    public int MaxPlayers { get; set; }
    public ScaleType ScaleType { get; set; }
    public Guid Id { get; set; }
}