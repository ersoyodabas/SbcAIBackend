using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class nation
{
    public int id { get; set; }

    public string code { get; set; } = null!;

    public string? icon_url { get; set; }

    public bool active { get; set; }

    public DateTime create_date { get; set; }

    public int? sort_number { get; set; }

    public bool? manager_keep { get; set; }

    public string? name_en { get; set; }

    public string? name_tr { get; set; }

    public DateTime? update_date { get; set; }

    public string? code_short_en { get; set; }

    public string? code_short_tr { get; set; }

    public virtual ICollection<nation_lang> nation_lang { get; set; } = new List<nation_lang>();

    public virtual ICollection<player> player { get; set; } = new List<player>();

    public virtual ICollection<sbc_player> sbc_player { get; set; } = new List<sbc_player>();
}
