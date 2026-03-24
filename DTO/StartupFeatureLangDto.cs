using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for startup_feature_lang
    /// </summary>
    public class StartupFeatureLangDto : BaseDto
    {
        public int id { get; set; }

        public int startup_feature_id { get; set; }

        public string lang { get; set; } = null!;

        public string name { get; set; } = null!;
    }
}
