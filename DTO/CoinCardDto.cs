using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for coin_card
    /// </summary>
    public class CoinCardDto : BaseDto
    {
        public int id { get; set; }

        public string? json_data { get; set; }

        public int? create_user_id { get; set; }

        public int? update_user_id { get; set; }

        public string? player_name { get; set; }

        public short? rating { get; set; }

        public string? bg_card_url { get; set; }

        public string? player_img_url { get; set; }

        public string? position { get; set; }

        public string? nation_img_url { get; set; }

        public string? club_flag_img_url { get; set; }

        public string? power_pac { get; set; }

        public string? power_sho { get; set; }

        public string? power_pas { get; set; }

        public string? power_dri { get; set; }

        public string? power_def { get; set; }

        public string? power_phy { get; set; }

        public DateTime? create_date { get; set; }

        public DateTime? update_date { get; set; }

        public string? url { get; set; }

        public string? league_img_url { get; set; }

        public string? club_img_url { get; set; }

        public double? min_price_cross { get; set; }

        public double? price_cross { get; set; }

        public double? max_price_cross { get; set; }

        public double? min_price_pc { get; set; }

        public double? price_pc { get; set; }

        public double? max_price_pc { get; set; }

        public double? transfer_ratio_cross { get; set; }

        public double? transfer_ratio_pc { get; set; }
    }
}
