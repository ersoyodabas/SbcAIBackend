using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class pack_category
{
    public int id { get; set; }

    public short sort_no { get; set; }

    public string langs { get; set; } = null!;

    public bool? selected { get; set; }

    public bool? active { get; set; }

    public virtual ICollection<pack> pack { get; set; } = new List<pack>();
}
