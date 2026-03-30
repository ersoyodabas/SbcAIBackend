using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class user_sbc
{
    public int id { get; set; }

    public int user_id { get; set; }

    public int sbc_id { get; set; }

    public bool? active { get; set; }

    public string? squad_link { get; set; }

    public DateTime create_date { get; set; }

    public DateTime? update_date { get; set; }

    public bool? hide { get; set; }

    public bool? active_squad { get; set; }

    public bool? daily { get; set; }

    public string? reqs { get; set; }

    public bool startup { get; set; }

    public bool fav { get; set; }

    public virtual sbc sbc { get; set; } = null!;

    public virtual user user { get; set; } = null!;
}
