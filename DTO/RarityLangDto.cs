using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for rarity_lang
    /// </summary>
    public class RarityLangDto : BaseDto
    {
        public int id { get; set; }

        public int rarity_id { get; set; }

        public string lang { get; set; } = null!;

        public string name { get; set; } = null!;
    }
}
