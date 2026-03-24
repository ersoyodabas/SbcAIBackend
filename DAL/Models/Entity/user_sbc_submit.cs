using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class user_sbc_submit
{
    public int id { get; set; }

    public int? user_id { get; set; }

    public int? sbc_id { get; set; }

    public int? account_id { get; set; }

    public DateTime? create_time { get; set; }

    public virtual user_club? account { get; set; }

    public virtual sbc? sbc { get; set; }

    public virtual user? user { get; set; }
}
