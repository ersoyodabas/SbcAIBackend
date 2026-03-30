using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class rarity
{
    public int id { get; set; }

    public string? code { get; set; }

    public string? icon_url { get; set; }

    public bool active { get; set; }

    public short? sort_number { get; set; }

    public DateTime create_date { get; set; }

    public string? futbin_class { get; set; }

    public int? futbin_id { get; set; }

    public string? futwiz_id { get; set; }

    public string? card_url { get; set; }

    public string? req_key { get; set; }

    public string? name_en { get; set; }

    public string? name_tr { get; set; }

    public string? futbin_value { get; set; }

    public virtual ICollection<card_default> card_default { get; set; } = new List<card_default>();

    public virtual ICollection<player> player { get; set; } = new List<player>();

    public virtual ICollection<sbc_player> sbc_player { get; set; } = new List<sbc_player>();
}
