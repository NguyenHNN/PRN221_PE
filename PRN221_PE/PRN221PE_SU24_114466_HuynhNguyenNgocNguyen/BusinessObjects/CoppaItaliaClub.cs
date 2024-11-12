using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class CoppaItaliaClub
{
    public string CoppaItaliaClubId { get; set; } = null!;

    public string ClubName { get; set; } = null!;

    public string? ShortDescription { get; set; }

    public DateTime? FoundedDate { get; set; }

    public string Ground { get; set; } = null!;

    public string Website { get; set; } = null!;

    public string CurrentPresident { get; set; } = null!;

    public virtual ICollection<CoppaItaliaPlayer> CoppaItaliaPlayers { get; set; } = new List<CoppaItaliaPlayer>();
}
