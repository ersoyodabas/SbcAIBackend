using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class nation_lang
{
    public int id { get; set; }

    public int nation_id { get; set; }

    public string lang { get; set; } = null!;

    public string name { get; set; } = null!;

    public string? manager_lang_code { get; set; }

    public DateTime? create_date { get; set; }

    public DateTime? update_date { get; set; }

    public virtual language langNavigation { get; set; } = null!;

    public virtual nation nation { get; set; } = null!;
}
