namespace bielu.multiRummykub.Models;

public class Cube
{
    public Guid Id { get; set; }
    public int Color { get; set; }
    public int Value { get; set; }
    public Guid SortSet { get; set; }
    public bool Moved { get; set; }
    public bool IsJoker { get; set; }
    public bool New { get; set; }
    public bool AddedByCurrentPlayer { get; set; }
    public bool Locked { get; set; }
}