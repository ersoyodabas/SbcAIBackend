using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for plan
    /// </summary>
    public class PlanDto : BaseDto
    {
        public int id { get; set; }

        public string langs { get; set; } = null!;

        public string img { get; set; } = null!;

        public DateTime? create_date { get; set; }

        public DateTime? update_date { get; set; }

        public string? code { get; set; }

        public short? login_limit { get; set; }

        public short? account_limit { get; set; }

        public DateTimeOffset? current_price { get; set; }

        public string? icon { get; set; }
    }
}
