
using System.ComponentModel.DataAnnotations;

public class Team {
  public int Id { get; set; }
  
  [Required]
  [MinLength(1)]
  public string? Name { get; set; }
}
