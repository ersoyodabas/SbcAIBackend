using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class league
{
    public int id { get; set; }

    public string? code { get; set; }

    public string? icon_url { get; set; }

    public bool active { get; set; }

    public DateTime? create_date { get; set; }

    public int? sort_number { get; set; }

    public string? name_en { get; set; }

    public string? name_tr { get; set; }

    public virtual ICollection<club> club { get; set; } = new List<club>();

    public virtual ICollection<league_lang> league_lang { get; set; } = new List<league_lang>();

    public virtual ICollection<player> player { get; set; } = new List<player>();

    public virtual ICollection<sbc_player> sbc_player { get; set; } = new List<sbc_player>();
}
