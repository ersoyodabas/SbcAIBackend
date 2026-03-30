using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class user_coin_supplier
{
    public int id { get; set; }

    public int user_id { get; set; }

    public int? supplier__user_id { get; set; }

    public DateTime create_date { get; set; }

    public DateTime? update_date { get; set; }
}
