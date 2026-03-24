using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for nation
    /// </summary>
    public class NationDto : BaseDto
    {
        public int id { get; set; }

        public string code { get; set; } = null!;

        public string? icon_url { get; set; }

        public bool active { get; set; }

        public DateTime create_date { get; set; }

        public int? sort_number { get; set; }

        public bool? manager_keep { get; set; }

        public string? name_en { get; set; }

        public string? name_tr { get; set; }

        public DateTime? update_date { get; set; }

        public string? code_short_en { get; set; }

        public string? code_short_tr { get; set; }
    }
}
