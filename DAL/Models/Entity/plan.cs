using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class plan
{
    public int id { get; set; }

    public string langs { get; set; } = null!;

    public string img { get; set; } = null!;

    public DateTime? create_date { get; set; }

    public DateTime? update_date { get; set; }

    public string? code { get; set; }

    public short? login_limit { get; set; }

    public short? account_limit { get; set; }

    public DateTimeOffset? current_price { get; set; }

    public string? icon { get; set; }
}
