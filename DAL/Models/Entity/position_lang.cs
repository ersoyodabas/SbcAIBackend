using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class position_lang
{
    public int id { get; set; }

    public int position_id { get; set; }

    public string? lang { get; set; }

    public string? name { get; set; }

    public virtual language? langNavigation { get; set; }

    public virtual position position { get; set; } = null!;
}
