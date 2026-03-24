using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class mail
{
    public int id { get; set; }

    public string? description { get; set; }

    public string? subject { get; set; }

    public string? body { get; set; }

    public string? users { get; set; }

    public string? error_message { get; set; }

    public int? sort_no { get; set; }

    public DateTime? update_date { get; set; }

    public bool? screen { get; set; }
}
