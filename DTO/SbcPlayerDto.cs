using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for sbc_player
    /// </summary>
    public class SbcPlayerDto : BaseDto
    {
        public int id { get; set; }

        public int? sbc_id { get; set; }

        public int? user_id { get; set; }

        public int? position_id { get; set; }

        public int? quality_id { get; set; }

        public int? league_id { get; set; }

        public int? club_id { get; set; }

        public int? nation_id { get; set; }

        public string? name { get; set; }

        public string? full_name { get; set; }

        public int price { get; set; }

        public int? rating { get; set; }

        public bool? system { get; set; }

        public DateTime? create_date { get; set; }

        public DateTime? update_date { get; set; }

        public int? update_user_id { get; set; }

        public string? fixed_name { get; set; }

        public int? rarity_id { get; set; }

        public bool? req { get; set; }

        public bool? first_owner { get; set; }

        public bool active { get; set; }

        public int? min_rating { get; set; }
    }
}
