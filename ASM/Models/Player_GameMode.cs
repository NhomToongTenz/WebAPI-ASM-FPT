using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM.Models;

public class Player_GameMode
{
    [Key]
    public int Player_GameMode_id { get; set; }

    [ForeignKey("Player")]
    public int? Player_id { get; set; }

    [ForeignKey("Game_Mode")]
    public int? GameMode_id { get; set; }

    public string? Player_GameMode_name { get; set; }
    // Navigation property


}
