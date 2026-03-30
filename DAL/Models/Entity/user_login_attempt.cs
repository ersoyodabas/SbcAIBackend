using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class user_login_attempt
{
    public int id { get; set; }

    public int user_id { get; set; }

    public string? ip { get; set; }

    public DateTime create_date { get; set; }
}
