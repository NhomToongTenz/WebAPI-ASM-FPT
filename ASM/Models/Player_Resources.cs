using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM.Models;

public class Player_Resources
{
    [Key]
    public int Player_Resoucers_id { get; set; }

    [ForeignKey("Player")]
    public int? Player_id { get; set; }

    [ForeignKey("ResourcesController")]
    public int? Resources_id { get; set; }


}
