using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class feature
{
    public int id { get; set; }

    public string code { get; set; } = null!;

    public bool active { get; set; }

    public string? type { get; set; }

    public string? names { get; set; }

    public string? links { get; set; }

    public string? plans { get; set; }

    public short? sort_no { get; set; }
}
