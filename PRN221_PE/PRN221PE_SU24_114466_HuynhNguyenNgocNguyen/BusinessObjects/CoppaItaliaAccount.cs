using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class CoppaItaliaAccount
{
    public int AccId { get; set; }

    public string AccPassword { get; set; } = null!;

    public string? EmailAddress { get; set; }

    public string AccDescription { get; set; } = null!;

    public int? AccRole { get; set; }
}
