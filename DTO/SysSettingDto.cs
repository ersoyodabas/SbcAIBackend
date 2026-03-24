using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for sys_setting
    /// </summary>
    public class SysSettingDto : BaseDto
    {
        public int id { get; set; }

        public string version { get; set; } = null!;

        public string? version_updated { get; set; }

        public string download_link { get; set; } = null!;

        public string? facebook_link { get; set; }

        public double usd_tl_amount { get; set; }

        public double discount_percent_tl { get; set; }

        public double discount_percent_season { get; set; }

        public double discount_percent_six_months { get; set; }

        public double discount_percent_three_months { get; set; }

        public double discount_percent_plan_change { get; set; }

        public double discount_silver { get; set; }

        public double discount_bronze { get; set; }

        public string? crypto_tl_iban { get; set; }

        public string? crypto_tl_iban_owner { get; set; }

        public string? crypto_tl_iban_bank { get; set; }

        public string? crypto_tether_trc { get; set; }

        public string? crypto_tether_erc { get; set; }

        public string? crypto_btc { get; set; }

        public string? crypto_eth { get; set; }

        public string? paypal_email { get; set; }

        public DateTime season_end_date { get; set; }

        public int season_left_day { get; set; }

        public decimal? supplier_commission { get; set; }

        public double app_price { get; set; }

        public DateTime? update_date { get; set; }

        public string? social_facebook { get; set; }

        public string? social_instagram { get; set; }

        public string? social_telegram { get; set; }

        public string? social_discord { get; set; }

        public string? social_whatsapp { get; set; }

        public string? social_youtube { get; set; }

        public string? website_link { get; set; }

        public string? social_logo { get; set; }

        public string? social_twitter { get; set; }

        public int discount_percent_month { get; set; }

        public double discount_percent_per_month { get; set; }

        public int discount_percent_two_months { get; set; }

        public string? crypto_tryc { get; set; }

        public string? email { get; set; }

        public bool hide_prices { get; set; }

        public string? wp_invite_link { get; set; }

        public string? coachs { get; set; }

        public string? coach_nations { get; set; }

        public string? quick_sellable_coach_nations_tr { get; set; }

        public string? quick_sellable_coach_nations_en { get; set; }

        public string? futbin_sbc_integration_link { get; set; }

        public string? whatsapp_no { get; set; }

        public short? trial_hours { get; set; }

        public bool? sync_sbc { get; set; }

        public string? integration { get; set; }

        public string? integration_url { get; set; }

        public bool? waiting_for_new_season { get; set; }

        public string? whatsapp_channel { get; set; }

        public int max_session_limit { get; set; }

        public string? video_install { get; set; }

        public string? download_url { get; set; }

        public string? webapp_url { get; set; }

        public short? energizer_coin_limit { get; set; }

        public DateTime? worker_runned_date { get; set; }

        public string? worker_log { get; set; }

        public string? max_buy_limit { get; set; }

        public TimeOnly? sync_time { get; set; }

        public int resolve_limit { get; set; }

        public bool? buy_from_concept { get; set; }

        public bool? quick_send_to_squat { get; set; }

        public short? sbc_req_rating_limit { get; set; }

        public short? tmarket_run_auto_minute { get; set; }

        public short? season { get; set; }

        public string? broken_player_names { get; set; }

        public bool? sync_sbc_reqs { get; set; }

        public short? coin_card_ratio { get; set; }
    }
}
