using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class pack
{
    public int id { get; set; }

    public int category_id { get; set; }

    public string? code { get; set; }

    public string? coin { get; set; }

    public string? fp { get; set; }

    public short sort_no { get; set; }

    public string? langs { get; set; }

    public virtual pack_category category { get; set; } = null!;
}
