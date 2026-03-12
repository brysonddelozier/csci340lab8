using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMeme.Models;

public class Meme
{
    public int Id { get; set; }
    public string? Name { get; set; }
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
    public string? Origin { get; set; }
    public int Funniness { get; set; }
}