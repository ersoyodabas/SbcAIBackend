using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class sbc
{
    public int id { get; set; }

    public int category_id { get; set; }

    public int? parent_id { get; set; }

    public string? code { get; set; }

    public int? sort_number { get; set; }

    public bool? group { get; set; }

    public bool? tradeable { get; set; }

    public bool? loyality { get; set; }

    public bool? active { get; set; }

    public DateTime create_date { get; set; }

    public DateTime? update_date { get; set; }

    public bool? use_filter { get; set; }

    public string? icon_url { get; set; }

    public int? child_count { get; set; }

    public bool? req { get; set; }

    public int? update_user_id { get; set; }

    public string? squad_link { get; set; }

    public DateTime? integration_date { get; set; }

    public bool? daily { get; set; }

    public string? reqs { get; set; }

    public bool? repeatable { get; set; }

    public int? repeat_count { get; set; }

    public string? name_en { get; set; }

    public string? name_tr { get; set; }

    public string? desc_en { get; set; }

    public string? desc_tr { get; set; }

    public int? chemistry { get; set; }

    public virtual sbc_category category { get; set; } = null!;

    public virtual ICollection<sbc_lang> sbc_lang { get; set; } = new List<sbc_lang>();

    public virtual ICollection<sbc_player> sbc_player { get; set; } = new List<sbc_player>();

    public virtual ICollection<user_sbc> user_sbc { get; set; } = new List<user_sbc>();

    public virtual ICollection<user_sbc_submit> user_sbc_submit { get; set; } = new List<user_sbc_submit>();
}
