using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for quality_lang
    /// </summary>
    public class QualityLangDto : BaseDto
    {
        public int id { get; set; }

        public int quality_id { get; set; }

        public string lang { get; set; } = null!;

        public string name { get; set; } = null!;
    }
}
