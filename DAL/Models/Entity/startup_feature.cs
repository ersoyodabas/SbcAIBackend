using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class startup_feature
{
    public int id { get; set; }

    public int? sort_number { get; set; }

    public string? code { get; set; }

    public bool? active { get; set; }

    public DateTime create_date { get; set; }

    public string? value1 { get; set; }

    public string? value2 { get; set; }

    public string? name_en { get; set; }

    public string? name_tr { get; set; }

    public virtual ICollection<startup_feature_lang> startup_feature_lang { get; set; } = new List<startup_feature_lang>();

    public virtual ICollection<user_startup> user_startup { get; set; } = new List<user_startup>();
}
