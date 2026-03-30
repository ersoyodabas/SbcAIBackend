using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class user_login
{
    public int id { get; set; }

    public int user_id { get; set; }

    public int? user_club_id { get; set; }

    public string ip { get; set; } = null!;

    public string? token { get; set; }

    public DateTime? token_expire { get; set; }

    public string type { get; set; } = null!;

    public string? new_attemped_ip { get; set; }

    public DateTime create_time { get; set; }

    public DateTime update_time { get; set; }

    public string? version { get; set; }

    public virtual user user { get; set; } = null!;

    public virtual user_club? user_club { get; set; }
}
