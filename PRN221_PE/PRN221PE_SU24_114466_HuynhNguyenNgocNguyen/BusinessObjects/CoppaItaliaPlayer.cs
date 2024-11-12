using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects;

public partial class CoppaItaliaPlayer
{
    public string CoppaItaliaPlayerId { get; set; } = null!;
    [Required(ErrorMessage = "FullName is required")]
    [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessage = "Must begin capital letter")]
    public string FullName { get; set; } = null!;
    [Required]
    public string Position { get; set; } = null!;
    [Required]
    public DateTime? Birthday { get; set; }
    [Required]
    public string InternationalCareer { get; set; } = null!;
    [Required]
    public string StyleOfPlay { get; set; } = null!;

    public string? CoppaItaliaClubId { get; set; }

    public virtual CoppaItaliaClub? CoppaItaliaClub { get; set; }
}
