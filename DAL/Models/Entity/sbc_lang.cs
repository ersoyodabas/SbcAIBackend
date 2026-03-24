using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class sbc_lang
{
    public int id { get; set; }

    public int sbc_id { get; set; }

    public string lang { get; set; } = null!;

    public string sbc_name { get; set; } = null!;

    public string? reward_name { get; set; }

    public virtual language langNavigation { get; set; } = null!;

    public virtual sbc sbc { get; set; } = null!;
}
