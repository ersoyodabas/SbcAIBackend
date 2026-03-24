using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for startup_feature
    /// </summary>
    public class StartupFeatureDto : BaseDto
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
    }
}
