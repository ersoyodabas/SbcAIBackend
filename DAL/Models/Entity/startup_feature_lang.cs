using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class startup_feature_lang
{
    public int id { get; set; }

    public int startup_feature_id { get; set; }

    public string lang { get; set; } = null!;

    public string name { get; set; } = null!;

    public virtual language langNavigation { get; set; } = null!;

    public virtual startup_feature startup_feature { get; set; } = null!;
}
