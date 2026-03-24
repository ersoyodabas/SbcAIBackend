using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class sbc_category
{
    public int id { get; set; }

    public string? code { get; set; }

    public short sort_number { get; set; }

    public bool active { get; set; }

    public bool sync { get; set; }

    public bool selected { get; set; }

    public string? name_en { get; set; }

    public string? name_tr { get; set; }

    public virtual ICollection<sbc> sbc { get; set; } = new List<sbc>();

    public virtual ICollection<sbc_category_lang> sbc_category_lang { get; set; } = new List<sbc_category_lang>();
}
