using System.ComponentModel.DataAnnotations;

namespace ASM.Models;

public class Resources
{
    [Key]
    public int Resource_id { get; set; }

    public string? Resource_name { get; set; }
}
