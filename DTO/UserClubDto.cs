using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for user_club
    /// </summary>
    public class UserClubDto : BaseDto
    {
        public int id { get; set; }

        public int user_id { get; set; }

        public string name { get; set; } = null!;

        public string? note { get; set; }

        public bool unlock { get; set; }

        public bool banned { get; set; }

        public double coin { get; set; }

        public string? platform { get; set; }

        public DateTime create_date { get; set; }

        public DateTime? update_date { get; set; }

        public int? nation_id { get; set; }

        public string? nation_code { get; set; }

        public string account_name { get; set; } = null!;

        public string? email { get; set; }

        public string? point { get; set; }

        public bool? active { get; set; }

        public bool? bug { get; set; }
    }
}
