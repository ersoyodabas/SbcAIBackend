using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class menu
{
    public int id { get; set; }

    public int sort_number { get; set; }

    public bool? only_admin { get; set; }

    public bool? active { get; set; }

    public bool show { get; set; }

    public string? type { get; set; }

    public string? href { get; set; }

    public string? img { get; set; }

    public string? name_en { get; set; }

    public string? name_tr { get; set; }

    public string? code { get; set; }
}
