using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class sbc_category_lang
{
    public int id { get; set; }

    public int sbc_category_id { get; set; }

    public string lang { get; set; } = null!;

    public string name { get; set; } = null!;

    public virtual language langNavigation { get; set; } = null!;

    public virtual sbc_category sbc_category { get; set; } = null!;
}
