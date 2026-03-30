using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class user
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

    public string? subscription_type { get; set; }

    public DateTime? subscription_start_date { get; set; }

    public DateTime? subscription_end_date { get; set; }

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

    public bool? contact_buy_coins { get; set; }

    /// <summary>
    /// pending
    /// confirmed
    /// </summary>
    public string? trial_status { get; set; }

    public string? registered_ip_address { get; set; }

    public string? trial_requested_ip_address { get; set; }

    public DateTime? trial_confirm_date { get; set; }

    public DateTime? trial_requested_date { get; set; }

    public bool? contact_mail_webapp_opened { get; set; }

    public bool? contact_mail_subs_expire { get; set; }

    public bool? contact_mail_price_change { get; set; }

    public short login_limit { get; set; }

    public string? version { get; set; }

    public string? crypto_sender_name { get; set; }

    public string? crypto_platform_name { get; set; }

    public string? crypt_sender_address { get; set; }

    public bool? coin_buyer { get; set; }

    public string? register_source { get; set; }

    public string? note { get; set; }

    public virtual ICollection<user> Inverseinviter_user { get; set; } = new List<user>();

    public virtual ICollection<user> InverseresellerNavigation { get; set; } = new List<user>();

    public virtual user? inviter_user { get; set; }

    public virtual ICollection<player> player { get; set; } = new List<player>();

    public virtual user? resellerNavigation { get; set; }

    public virtual ICollection<sbc_player> sbc_player { get; set; } = new List<sbc_player>();

    public virtual ICollection<subscription> subscription { get; set; } = new List<subscription>();

    public virtual ICollection<user_club> user_club { get; set; } = new List<user_club>();

    public virtual ICollection<user_login> user_login { get; set; } = new List<user_login>();

    public virtual user_menu_settings? user_menu_settings { get; set; }

    public virtual ICollection<user_sbc> user_sbc { get; set; } = new List<user_sbc>();

    public virtual ICollection<user_sbc_submit> user_sbc_submit { get; set; } = new List<user_sbc_submit>();

    public virtual ICollection<user_startup> user_startup { get; set; } = new List<user_startup>();
}
