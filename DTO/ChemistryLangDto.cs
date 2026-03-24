using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for chemistry_lang
    /// </summary>
    public class ChemistryLangDto : BaseDto
    {
        public int id { get; set; }

        public int? chemistry_id { get; set; }

        public string? lang { get; set; }

        public string? name { get; set; }
    }
}
