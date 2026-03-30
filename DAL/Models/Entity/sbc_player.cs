using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class sbc_player
{
    public int id { get; set; }

    public int? sbc_id { get; set; }

    public int? user_id { get; set; }

    public int? position_id { get; set; }

    public int? quality_id { get; set; }

    public int? league_id { get; set; }

    public int? club_id { get; set; }

    public int? nation_id { get; set; }

    public string? name { get; set; }

    public string? full_name { get; set; }

    public int price { get; set; }

    public int? rating { get; set; }

    public bool? system { get; set; }

    public DateTime? create_date { get; set; }

    public DateTime? update_date { get; set; }

    public int? update_user_id { get; set; }

    public string? fixed_name { get; set; }

    public int? rarity_id { get; set; }

    public bool? req { get; set; }

    public bool? first_owner { get; set; }

    public bool active { get; set; }

    public int? min_rating { get; set; }

    public virtual club? club { get; set; }

    public virtual league? league { get; set; }

    public virtual nation? nation { get; set; }

    public virtual position? position { get; set; }

    public virtual quality? quality { get; set; }

    public virtual rarity? rarity { get; set; }

    public virtual sbc? sbc { get; set; }

    public virtual user? user { get; set; }
}
