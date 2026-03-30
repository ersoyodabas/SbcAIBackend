using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class user_startup
{
    public int id { get; set; }

    public int? sort_number { get; set; }

    public int? feature_id { get; set; }

    public bool? active { get; set; }

    public DateTime? create_date { get; set; }

    public string? value1 { get; set; }

    public int? user_id { get; set; }

    public DateTime? update_time { get; set; }

    public string value2 { get; set; } = null!;

    public virtual startup_feature? feature { get; set; }

    public virtual user? user { get; set; }
}
