using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for formation
    /// </summary>
    public class FormationDto : BaseDto
    {
        public int id { get; set; }

        public string name { get; set; } = null!;

        public int sort_number { get; set; }
    }
}
