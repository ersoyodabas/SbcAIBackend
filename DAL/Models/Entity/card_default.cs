using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class card_default
{
    public int id { get; set; }

    public int? quality_id { get; set; }

    public int? rarity_id { get; set; }

    public int min_rating { get; set; }

    public int max_rating { get; set; }

    public int min_price { get; set; }

    public int? max_price { get; set; }

    public virtual quality? quality { get; set; }

    public virtual rarity? rarity { get; set; }
}
