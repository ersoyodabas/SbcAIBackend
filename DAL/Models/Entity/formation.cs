using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class formation
{
    public int id { get; set; }

    public string name { get; set; } = null!;

    public int sort_number { get; set; }
}
