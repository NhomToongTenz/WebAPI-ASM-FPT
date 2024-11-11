using System.ComponentModel.DataAnnotations;

namespace ASM.Models;

public class Game_Mode
{
    [Key]
    public int GameMode_id { get; set; }

    public string? GameMode_name { get; set; }
}
