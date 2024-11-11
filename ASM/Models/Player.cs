using System.ComponentModel.DataAnnotations;

namespace ASM.Models;

public class Player
{
    [Key]
    public int Player_id { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Character_name { get; set; }

    public int? Level { get; set; }

    public int? Food { get; set; }

    public int? Health { get; set; }

    public int? Exp { get; set; }
}
