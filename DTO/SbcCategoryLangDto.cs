using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for sbc_category_lang
    /// </summary>
    public class SbcCategoryLangDto : BaseDto
    {
        public int id { get; set; }

        public int sbc_category_id { get; set; }

        public string lang { get; set; } = null!;

        public string name { get; set; } = null!;
    }
}
