namespace bielu.multiRummykub.Models.Table;

public class CubeSet
{
    public Guid Id { get; set; }
    public bool Valid { get; set; }
    public SetType Type { get; set; }
    public List<Cube> Cubes { get; set; } = new List<Cube>();
    public bool Locked { get; set; }
}