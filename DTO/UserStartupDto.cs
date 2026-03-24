using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for user_startup
    /// </summary>
    public class UserStartupDto : BaseDto
    {
        public int id { get; set; }

        public int? sort_number { get; set; }

        public int? feature_id { get; set; }

        public bool? active { get; set; }

        public DateTime? create_date { get; set; }

        public string? value1 { get; set; }

        public int? user_id { get; set; }

        public DateTime? update_time { get; set; }

        public string value2 { get; set; } = null!;
    }
}
