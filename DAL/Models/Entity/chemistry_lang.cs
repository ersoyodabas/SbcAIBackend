using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class chemistry_lang
{
    public int id { get; set; }

    public int? chemistry_id { get; set; }

    public string? lang { get; set; }

    public string? name { get; set; }

    public virtual chemistry? chemistry { get; set; }

    public virtual language? langNavigation { get; set; }
}
