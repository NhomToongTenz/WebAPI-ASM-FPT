using System.ComponentModel.DataAnnotations;

namespace ASM.Models;

public class Items
{
    [Key] // data annotation
    public int Item_id { get; set; }

    public string? Item_name { get; set; }

    public byte[]? Image { get; set; }

    public string? Item_type { get; set; }

    public int? Exp {get; set;}
}
