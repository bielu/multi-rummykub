using System.ComponentModel.DataAnnotations;

namespace bielu.multiRummykub.Models.Player;

public class Player
{
    [Key] public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public Table.Table TableId { get; set; }
}