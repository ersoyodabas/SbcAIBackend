using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class user_menu_settings
{
    public int id { get; set; }

    public int? user_id { get; set; }

    public int? auto_bid_next_tour_sleep_duration { get; set; }

    public bool? auto_bid_add_won_items_to_transfer_market { get; set; }

    public bool? auto_bid_add_won_items_to_transfer_list { get; set; }

    public bool? auto_bid_add_won_items_to_club { get; set; }

    public bool? add_to_tlist_unassigned_items { get; set; }

    public bool? add_to_tlist_club_players { get; set; }

    public bool? add_to_tlist_dont_use_active_squat_players { get; set; }

    public bool? add_to_tlist_consumables_all { get; set; }

    public bool? add_to_tlist_consumables_contract { get; set; }

    public bool? add_to_tlist_consumables_healing { get; set; }

    public bool? add_to_tlist_consumables_positioning { get; set; }

    public bool? add_to_tlist_consumables_chemistry_style { get; set; }

    public bool? add_to_tlist_consumables_manager_league { get; set; }

    public bool? add_to_tlist_staff { get; set; }

    public bool? add_to_tlist_sell_items { get; set; }

    public bool? pac_preview { get; set; }

    public bool? pac_open_pack { get; set; }

    public bool? pack_buy { get; set; }

    public bool? packing_use_fp { get; set; }

    public int? pack_buy_count { get; set; }

    public bool? tmarket_list_s_send_to_tlist { get; set; }

    public bool? tmarket_list_send_to_club_active { get; set; }

    public int? tmarket_relist_s_custom_price { get; set; }

    public bool? tmarket_relist_s_compare_price { get; set; }

    public int? tmarket_relist_s_price_change { get; set; }

    public bool? tmarket_relist_send_to_club_if_min_price { get; set; }

    public int? tmarket_list_s_custom_price { get; set; }

    public bool? tmarket_list_s_compare_price { get; set; }

    public int? tmarket_list_s_price_change { get; set; }

    public bool? tmarket_list_send_to_club_if_min_price { get; set; }

    public bool? tmarket_list_qs_active { get; set; }

    public bool? tmarket_list_qs_if_min_price { get; set; }

    public int? tmarket_list_qs_max_rating_tradeable { get; set; }

    public int? tmarket_list_qs_max_rating_untradeable_copy { get; set; }

    public bool? tmarket_list_qs_chemistry { get; set; }

    public bool? tmarket_list_qs_position { get; set; }

    public bool? tmarket_list_qs_contract { get; set; }

    public bool? tmarket_list_qs_manager { get; set; }

    public bool? tmarket_list_qs_other { get; set; }

    public int? snipe_search_count { get; set; }

    public int? snipe_sleep_duration { get; set; }

    public bool? snipe_add_to_transfer_market { get; set; }

    public bool? snipe_add_to_transfer_list { get; set; }

    public int? snipe_market_price { get; set; }

    public int? snipe_buy_count { get; set; }

    public bool? sbc_use_my_solutions { get; set; }

    public bool? sbc_use_concept_player { get; set; }

    public bool? sbc_use_futbin_address { get; set; }

    public bool? sbc_show_only_tradeable { get; set; }

    public bool? sbc_hide_solved { get; set; }

    public bool? sbc_send_squat { get; set; }

    public bool? sbc_search_club_player { get; set; }

    public bool? sbc_open_packs { get; set; }

    public bool? tmarket_list_send_to_club_rare_player { get; set; }

    public bool? tmarket_relist_qs_active { get; set; }

    public int? tmarket_relist_qs_max_rating_tradeable { get; set; }

    public bool? tmarket_relist_qs_if_min_price { get; set; }

    public bool? tmarket_relist_qs_chemistry { get; set; }

    public bool? tmarket_relist_qs_manager { get; set; }

    public bool? tmarket_relist_qs_position { get; set; }

    public bool? tmarket_relist_qs_contract { get; set; }

    public bool? tmarket_relist_qs_other { get; set; }

    public bool? tmarket_relist_send_to_club_active { get; set; }

    public bool? tmarket_relist_send_to_club_common_player { get; set; }

    public bool? tmarket_relist_send_to_club_rare_player { get; set; }

    public bool? tmarket_send_to_club_unsold_min_priced { get; set; }

    public bool? tmarket_list_send_to_club_common_player { get; set; }

    public bool? tmarket_list_s_list_on_market { get; set; }

    public string? pack_action { get; set; }

    public bool? pack_run_tmarket { get; set; }

    public byte? action_speed { get; set; }

    public bool? pack_sound { get; set; }

    public bool? sync_data { get; set; }

    public bool? sbc_untradeables_only { get; set; }

    public bool? sbc_dont_use_active_squat_players { get; set; }

    public bool? sbc_open_packs_fast { get; set; }

    public DateTime create_date { get; set; }

    public bool? sbc_use_tmarket_screen { get; set; }

    public bool? startup { get; set; }

    public bool? startup_open_pack_preview { get; set; }

    public bool? startup_add_to_tlist { get; set; }

    public bool? startup_transfer_market_run { get; set; }

    public bool? startup_daily_sbcs_solve { get; set; }

    public bool? startup_claim_all_rewards { get; set; }

    public bool? startup_open_packs_all { get; set; }

    public bool? startup_tradeable_sbcs_solve { get; set; }

    public bool pack_open_tradeables { get; set; }

    public bool pack_open_untradeables { get; set; }

    public int startup_daily_sbcs_solve_count { get; set; }

    public bool? auto_bid_run_tmarket { get; set; }

    public bool? auto_bid_list_on_tmarket { get; set; }

    public int? tmarket_qs_quality_id { get; set; }

    public int? tmarket_qs_rarity_id { get; set; }

    public int? tmarket_qs_rating_min { get; set; }

    public int? tmarket_qs_rating_max { get; set; }

    public bool? tmarket_qs_chemistry { get; set; }

    public bool? tmarket_qs_manager { get; set; }

    public bool? tmarket_qs_if_min_price { get; set; }

    public bool? tmarket_qs_other { get; set; }

    public int? tmarket_s2c_quality_id { get; set; }

    public int? tmarket_s2c_rarity_id { get; set; }

    public int? tmarket_s2c_rating_min { get; set; }

    public int? tmarket_s2c_rating_max { get; set; }

    public bool? tmarket_s2c_others { get; set; }

    public bool? tmarket_s2c_if_min_price { get; set; }

    public int? tmarket_s2tl_quality_id { get; set; }

    public int? tmarket_s2tl_rarity_id { get; set; }

    public int? tmarket_s2tl_rating_min { get; set; }

    public int? tmarket_s2tl_rating_max { get; set; }

    public bool? tmarket_s2tl_other { get; set; }

    public short? tmarket_list_duration_id { get; set; }

    public short? tmarket_relist_duration_id { get; set; }

    public int? tmarket_list_buy_now_price { get; set; }

    public short tmarket_list_price_change { get; set; }

    public short tmarket_relist_price_change { get; set; }

    public int? tmarket_list_buy_now_price_ { get; set; }

    public int? tmarket_list_start_price { get; set; }

    public int? tmarket_relist_start_price { get; set; }

    public int? tmarket_relist_buy_now_price { get; set; }

    public bool? tmarket_relist_compare_price { get; set; }

    public bool? tmarket_s2tl_others { get; set; }

    public bool? tmarket_qs_others { get; set; }

    public DateTime? update_time { get; set; }

    public bool pack_animation_skip { get; set; }

    public bool tmarket_sell_club_players { get; set; }

    public bool sbc_use_active_squad_players { get; set; }

    public bool sbc_use_tradeables { get; set; }

    public bool pack_open_bronze { get; set; }

    public bool pack_open_silver { get; set; }

    public bool pack_open_other_types { get; set; }

    public string? club_sortage { get; set; }

    public int action_speed_max { get; set; }

    public bool? tmarket_run_auto { get; set; }

    public bool? sbc_dont_buy_players { get; set; }

    public int? tmarket_qs_duplicate_max_rating { get; set; }

    public short? tmarket_qs_if_min_price_rating_limit { get; set; }

    public short? tmarket_s2c_if_min_price_rating_limit { get; set; }

    public string? tmarket_player_pick_option_id { get; set; }

    public short tmarket_rerun_min { get; set; }

    public bool sbc_allow_club_players { get; set; }

    public bool sbc_allow_buy_players { get; set; }

    public bool? sbc_buy_only_concept_players { get; set; }

    public bool? sbc_show_only_my_startup_sbcs { get; set; }

    public bool tmarket_qs_active { get; set; }

    public bool tmarket_qs_kit { get; set; }

    public bool tmarket_s2c { get; set; }

    public short? tmarket_s2c_if_min_price_rating_min { get; set; }

    public bool tmarket_s2c_min_price { get; set; }

    public bool tmarket_s2c_min_price_relist { get; set; }

    public short? tmarket_s2c_if_min_price_rating_max { get; set; }

    public bool tmarket_s2c_direct { get; set; }

    public short? tmarket_s2c_direct_min_rating { get; set; }

    public short? tmarket_s2c_direct_max_rating { get; set; }

    public int? tmarket_s2c_direct_rarity_id { get; set; }

    public bool tmarket_s2c_direct_relist { get; set; }

    public bool tmarket_s2c_others_relist { get; set; }

    public bool tmarket_qs_duplicate { get; set; }

    public bool tmarket_s2tl { get; set; }

    public short? tmarket_qs_if_min_price_rating_min { get; set; }

    public short? tmarket_qs_if_min_price_rating_max { get; set; }

    public bool tmarket_qs_direct { get; set; }

    public string? tmarket_qs_if_min_price_list_type { get; set; }

    public bool tmarket_qs_direct_untradeable { get; set; }

    public bool tmarket_qs_direct_tradeable { get; set; }

    public virtual user? user { get; set; }
}
