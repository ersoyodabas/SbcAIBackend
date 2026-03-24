using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for feature
    /// </summary>
    public class FeatureDto : BaseDto
    {
        public int id { get; set; }

        public string code { get; set; } = null!;

        public bool active { get; set; }

        public string? type { get; set; }

        public string? names { get; set; }

        public string? links { get; set; }

        public string? plans { get; set; }

        public short? sort_no { get; set; }
    }
}
