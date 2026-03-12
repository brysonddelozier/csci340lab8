using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMeme.Models;

public class Meme
{
    public int Id { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Name { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    [Required]
    public DateTime Date { get; set; }

    public string? Origin { get; set; }
    
    [Range(1, 10)]
    [DataType(DataType.Integer)]
    public int Funniness { get; set; }

    [Display(Name = "Celebrity Endorsement")]
    public string CelebrityEndorsement { get; set; } = string.Empty;
}