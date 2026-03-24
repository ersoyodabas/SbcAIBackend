using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class league_lang
{
    public int id { get; set; }

    public int league_id { get; set; }

    public string lang { get; set; } = null!;

    public string name { get; set; } = null!;

    public virtual language langNavigation { get; set; } = null!;

    public virtual league league { get; set; } = null!;
}
