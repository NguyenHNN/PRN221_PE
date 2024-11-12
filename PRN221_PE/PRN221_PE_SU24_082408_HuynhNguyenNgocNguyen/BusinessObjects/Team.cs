using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects;

public partial class Team
{
    public int Id { get; set; }
    [Required]
    [StringLength(10, MinimumLength = 3, ErrorMessage = "TeamName must in range from 3 to 10")]
    [RegularExpression(@"^(?:[A-Z][a-zA-Z0-9]*\s?)+$", ErrorMessage = "TeamName must begin with capital letter, allow number and not allow special characters")]
    public string TeamName { get; set; } = null!;
    [Required]
    public int Point { get; set; }
    [Required]
    public int? GroupId { get; set; }
    [Required]
    public int Position { get; set; }

    public virtual GroupTeam? Group { get; set; }
}
