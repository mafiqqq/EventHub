using System.ComponentModel.DataAnnotations;

namespace API.Entities;

public class AppEvent
{
    [Key]
    public int EventId { get; set; }
    public string? EventName { get; set; }
    
}
