using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for user_sbc
    /// </summary>
    public class UserSbcDto : BaseDto
    {
        public int id { get; set; }

        public int user_id { get; set; }

        public int sbc_id { get; set; }

        public bool? active { get; set; }

        public string? squad_link { get; set; }

        public DateTime create_date { get; set; }

        public DateTime? update_date { get; set; }

        public bool? hide { get; set; }

        public bool? active_squad { get; set; }

        public bool? daily { get; set; }

        public string? reqs { get; set; }

        public bool startup { get; set; }

        public bool fav { get; set; }
    }
}
