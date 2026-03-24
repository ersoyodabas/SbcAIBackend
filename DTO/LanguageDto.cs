using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for language
    /// </summary>
    public class LanguageDto : BaseDto
    {
        public string code { get; set; } = null!;

        public string? name { get; set; }

        public string? flag { get; set; }

        public int? sort_number { get; set; }

        public bool? active { get; set; }
    }
}
