using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class formation_position
{
    public int id { get; set; }

    public int formation_id { get; set; }

    public string? name { get; set; }

    public int? index_no { get; set; }

    public string? stage { get; set; }

    public int stage_sort_num { get; set; }
}
