using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class subscription
{
    public int id { get; set; }

    public int user_id { get; set; }

    public int duration_unit { get; set; }

    public string duration_type { get; set; } = null!;

    public string membership_type { get; set; } = null!;

    public int count { get; set; }

    public string? currency { get; set; }

    public double amount { get; set; }

    public string status { get; set; } = null!;

    public string? confirm_code { get; set; }

    public DateTime? confirmed_date { get; set; }

    public string? payment_type { get; set; }

    public DateTime? update_date { get; set; }

    public DateTime create_date { get; set; }

    public string? payment_method { get; set; }

    public int? rate_point { get; set; }

    public string? rate_comment { get; set; }

    public bool rated { get; set; }

    public DateTime? rated_date { get; set; }

    public string? discount_code { get; set; }

    public int discount_ratio { get; set; }

    public int? promotion_id { get; set; }

    public double usd_currency { get; set; }

    public int? reference_user_id { get; set; }

    public short login_limit { get; set; }

    public short? account_limit { get; set; }

    public short? ip_limit { get; set; }

    public short season { get; set; }

    public bool upgrade { get; set; }

    public string? note { get; set; }

    public virtual user user { get; set; } = null!;
}
