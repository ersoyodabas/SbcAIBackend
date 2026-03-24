using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class language
{
    public string code { get; set; } = null!;

    public string? name { get; set; }

    public string? flag { get; set; }

    public int? sort_number { get; set; }

    public bool? active { get; set; }

    public virtual ICollection<chemistry_lang> chemistry_lang { get; set; } = new List<chemistry_lang>();

    public virtual ICollection<club_lang> club_lang { get; set; } = new List<club_lang>();

    public virtual ICollection<league_lang> league_lang { get; set; } = new List<league_lang>();

    public virtual ICollection<nation_lang> nation_lang { get; set; } = new List<nation_lang>();

    public virtual ICollection<position_lang> position_lang { get; set; } = new List<position_lang>();

    public virtual ICollection<quality_lang> quality_lang { get; set; } = new List<quality_lang>();

    public virtual ICollection<rarity_lang> rarity_lang { get; set; } = new List<rarity_lang>();

    public virtual ICollection<sbc_category_lang> sbc_category_lang { get; set; } = new List<sbc_category_lang>();

    public virtual ICollection<sbc_lang> sbc_lang { get; set; } = new List<sbc_lang>();

    public virtual ICollection<startup_feature_lang> startup_feature_lang { get; set; } = new List<startup_feature_lang>();
}
