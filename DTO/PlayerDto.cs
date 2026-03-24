using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for player
    /// </summary>
    public class PlayerDto : BaseDto
    {
        public int id { get; set; }

        public string? name { get; set; }

        public string? full_name { get; set; }

        public int? quality_id { get; set; }

        public int? rarity_id { get; set; }

        public int? league_id { get; set; }

        public int? club_id { get; set; }

        public int? rating { get; set; }

        public int? price { get; set; }

        public DateTime create_date { get; set; }

        public DateTime? update_date { get; set; }

        public int? update_user_id { get; set; }

        public string? fixed_name { get; set; }

        public int? futbin_player_id { get; set; }

        public string? futbin_player_link { get; set; }

        public string? futbin_squat_link { get; set; }

        public int? position_id { get; set; }

        public string? url { get; set; }

        public string? url_img_player { get; set; }

        public int price_cross { get; set; }

        public int price_pc { get; set; }

        public string? url_img_card { get; set; }

        public string? url_img_nation { get; set; }

        public string? url_img_league { get; set; }

        public string? url_img_club { get; set; }

        public int? nation_id { get; set; }
    }
}
