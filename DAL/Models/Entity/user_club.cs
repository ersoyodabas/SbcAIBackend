using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class user_club
{
    public int id { get; set; }

    public int user_id { get; set; }

    public string name { get; set; } = null!;

    public string? note { get; set; }

    public bool unlock { get; set; }

    public bool banned { get; set; }

    public double coin { get; set; }

    public string? platform { get; set; }

    public DateTime create_date { get; set; }

    public DateTime? update_date { get; set; }

    public int? nation_id { get; set; }

    public string? nation_code { get; set; }

    public string account_name { get; set; } = null!;

    public string? email { get; set; }

    public string? point { get; set; }

    public bool? active { get; set; }

    public bool? bug { get; set; }

    public virtual user user { get; set; } = null!;

    public virtual ICollection<user_login> user_login { get; set; } = new List<user_login>();

    public virtual ICollection<user_sbc_submit> user_sbc_submit { get; set; } = new List<user_sbc_submit>();
}
