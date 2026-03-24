using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for user
    /// </summary>
    public class UserDto : BaseDto
    {
        public int id { get; set; }

        public string name { get; set; } = null!;

        public int? inviter_user_id { get; set; }

        public string email { get; set; } = null!;

        public string password { get; set; } = null!;

        public DateTime? last_login_date_app { get; set; }

        public DateTime? last_active_date_app { get; set; }

        public string? last_used_ip { get; set; }

        public string? role { get; set; }

        public string? membership_type { get; set; }

        public string? email_code { get; set; }

        public DateTime email_code_sent_date { get; set; }

        public DateTime? activated_date { get; set; }

        public DateTime? membership_start_date { get; set; }

        public DateTime? membership_end_date { get; set; }

        public bool? active { get; set; }

        public string? password_reset_code { get; set; }

        public string? auto_login_code { get; set; }

        public int max_login_limit { get; set; }

        public bool banned { get; set; }

        public string? phone_area { get; set; }

        public string? phone { get; set; }

        public DateTime create_date { get; set; }

        public DateTime? update_date { get; set; }

        public bool? can_promotion { get; set; }

        public bool has_reseller { get; set; }

        public string lang_app { get; set; } = null!;

        public bool reseller { get; set; }

        public short? reseller_discount { get; set; }

        public bool expire_mail_sent { get; set; }

        public int? reseller_id { get; set; }

        public string? social_facebook { get; set; }

        public string? social_instagram { get; set; }

        public string? social_telegram { get; set; }

        public string? social_discord { get; set; }

        public string? social_whatsapp { get; set; }

        public string? website_link { get; set; }

        public string? social_youtube { get; set; }

        public string? social_twitter { get; set; }

        public string? social_logo { get; set; }

        public bool? contact_buy_coins { get; set; }

        public bool? wp_join_result { get; set; }

        public string? trial_status { get; set; }

        public string? registered_ip_address { get; set; }

        public string? trial_requested_ip_address { get; set; }

        public DateTime? trial_confirm_date { get; set; }

        public DateTime? trial_requested_date { get; set; }

        public bool? contact_mail_webapp_opened { get; set; }

        public bool? contact_mail_subs_expire { get; set; }

        public bool? contact_mail_price_change { get; set; }

        public bool? auto_login { get; set; }

        public short login_limit { get; set; }

        public short? ip_limit { get; set; }

        public short? account_limit { get; set; }

        public string? version { get; set; }

        public string? crypto_sender_name { get; set; }

        public string? crypto_platform_name { get; set; }

        public string? crypt_sender_address { get; set; }

        public bool? coin_buyer { get; set; }

        public string? username { get; set; }

        public string? register_source { get; set; }

        public string? note { get; set; }
    }
}
