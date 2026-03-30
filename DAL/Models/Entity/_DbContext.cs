using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sbc.DAL.Models.Entity;

public partial class _DbContext : DbContext
{
    public _DbContext()
    {
    }

    public _DbContext(DbContextOptions<_DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<announcement> announcement { get; set; }

    public virtual DbSet<card_default> card_default { get; set; }

    public virtual DbSet<chemistry> chemistry { get; set; }

    public virtual DbSet<club> club { get; set; }

    public virtual DbSet<coin_card> coin_card { get; set; }

    public virtual DbSet<country> country { get; set; }

    public virtual DbSet<feature> feature { get; set; }

    public virtual DbSet<formation> formation { get; set; }

    public virtual DbSet<formation_position> formation_position { get; set; }

    public virtual DbSet<language> language { get; set; }

    public virtual DbSet<league> league { get; set; }

    public virtual DbSet<log_request> log_request { get; set; }

    public virtual DbSet<mail> mail { get; set; }

    public virtual DbSet<menu> menu { get; set; }

    public virtual DbSet<nation> nation { get; set; }

    public virtual DbSet<pack> pack { get; set; }

    public virtual DbSet<pack_category> pack_category { get; set; }

    public virtual DbSet<plan> plan { get; set; }

    public virtual DbSet<player> player { get; set; }

    public virtual DbSet<position> position { get; set; }

    public virtual DbSet<quality> quality { get; set; }

    public virtual DbSet<rarity> rarity { get; set; }

    public virtual DbSet<sbc> sbc { get; set; }

    public virtual DbSet<sbc_category> sbc_category { get; set; }

    public virtual DbSet<sbc_player> sbc_player { get; set; }

    public virtual DbSet<startup_feature> startup_feature { get; set; }

    public virtual DbSet<subscription> subscription { get; set; }

    public virtual DbSet<sys_setting> sys_setting { get; set; }

    public virtual DbSet<user> user { get; set; }

    public virtual DbSet<user_club> user_club { get; set; }

    public virtual DbSet<user_coin_supplier> user_coin_supplier { get; set; }

    public virtual DbSet<user_login> user_login { get; set; }

    public virtual DbSet<user_login_attempt> user_login_attempt { get; set; }

    public virtual DbSet<user_menu_settings> user_menu_settings { get; set; }

    public virtual DbSet<user_sbc> user_sbc { get; set; }

    public virtual DbSet<user_sbc_submit> user_sbc_submit { get; set; }

    public virtual DbSet<user_startup> user_startup { get; set; }

    public virtual DbSet<version> version { get; set; }

    public virtual DbSet<vw_request_log> vw_request_log { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=94.73.145.8;Database=u2211892_sbcai;User Id=u2211892_sbcai;Password=4unYm_o.FS2Q25::;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<announcement>(entity =>
        {
            entity.Property(e => e.create_date).HasColumnType("datetime");
            entity.Property(e => e.desc_en).HasMaxLength(1000);
            entity.Property(e => e.desc_tr).HasMaxLength(1000);
            entity.Property(e => e.end_date).HasColumnType("datetime");
            entity.Property(e => e.header_en).HasMaxLength(500);
            entity.Property(e => e.header_tr).HasMaxLength(500);
            entity.Property(e => e.icon).HasMaxLength(100);
            entity.Property(e => e.img_url).HasMaxLength(500);
            entity.Property(e => e.link_url).HasMaxLength(500);
            entity.Property(e => e.logo).HasMaxLength(500);
            entity.Property(e => e.return_url).HasMaxLength(500);
            entity.Property(e => e.start_date).HasColumnType("datetime");
            entity.Property(e => e.type).HasMaxLength(10);
            entity.Property(e => e.update_date).HasColumnType("datetime");
        });

        modelBuilder.Entity<card_default>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__card_def__3213E83F52ACA40B");

            entity.HasOne(d => d.quality).WithMany(p => p.card_default)
                .HasForeignKey(d => d.quality_id)
                .HasConstraintName("FK_card_default_quality");

            entity.HasOne(d => d.rarity).WithMany(p => p.card_default)
                .HasForeignKey(d => d.rarity_id)
                .HasConstraintName("FK_card_default_rarity");
        });

        modelBuilder.Entity<chemistry>(entity =>
        {
            entity.Property(e => e.code).HasMaxLength(50);
            entity.Property(e => e.create_date).HasColumnType("datetime");
            entity.Property(e => e.icon_url).HasMaxLength(500);
            entity.Property(e => e.name_en)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.name_tr)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<club>(entity =>
        {
            entity.HasIndex(e => e.league_id, "IX_club_league_id");

            entity.Property(e => e.active).HasDefaultValue(true);
            entity.Property(e => e.code).HasMaxLength(100);
            entity.Property(e => e.create_date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.icon_url).HasMaxLength(500);
            entity.Property(e => e.name_en).HasMaxLength(100);
            entity.Property(e => e.name_tr).HasMaxLength(100);

            entity.HasOne(d => d.league).WithMany(p => p.club)
                .HasForeignKey(d => d.league_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_league_club");
        });

        modelBuilder.Entity<coin_card>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__coin_car__3213E83F61EA44FC");

            entity.HasIndex(e => e.url, "UQ_coin_card_url").IsUnique();

            entity.Property(e => e.bg_card_url).HasMaxLength(500);
            entity.Property(e => e.club_flag_img_url).HasMaxLength(500);
            entity.Property(e => e.club_img_url).HasMaxLength(500);
            entity.Property(e => e.create_date).HasColumnType("datetime");
            entity.Property(e => e.json_data).HasMaxLength(500);
            entity.Property(e => e.league_img_url).HasMaxLength(500);
            entity.Property(e => e.nation_img_url).HasMaxLength(500);
            entity.Property(e => e.player_img_url).HasMaxLength(500);
            entity.Property(e => e.player_name)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.position).HasMaxLength(5);
            entity.Property(e => e.power_def).HasMaxLength(3);
            entity.Property(e => e.power_dri).HasMaxLength(3);
            entity.Property(e => e.power_pac).HasMaxLength(3);
            entity.Property(e => e.power_pas).HasMaxLength(3);
            entity.Property(e => e.power_phy).HasMaxLength(3);
            entity.Property(e => e.power_sho).HasMaxLength(3);
            entity.Property(e => e.update_date).HasColumnType("datetime");
            entity.Property(e => e.url).HasMaxLength(500);
        });

        modelBuilder.Entity<country>(entity =>
        {
            entity.Property(e => e.code).HasMaxLength(10);
            entity.Property(e => e.create_date).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.phone).HasMaxLength(10);
            entity.Property(e => e.title).HasMaxLength(500);
        });

        modelBuilder.Entity<feature>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__feature__3213E83FBCC089C9");

            entity.Property(e => e.active).HasDefaultValue(true);
            entity.Property(e => e.code).HasMaxLength(50);
            entity.Property(e => e.links).HasMaxLength(500);
            entity.Property(e => e.names).HasMaxLength(200);
            entity.Property(e => e.plans).HasMaxLength(50);
            entity.Property(e => e.type)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<formation>(entity =>
        {
            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.name).HasMaxLength(50);
        });

        modelBuilder.Entity<formation_position>(entity =>
        {
            entity.Property(e => e.name).HasMaxLength(10);
            entity.Property(e => e.stage).HasMaxLength(100);
        });

        modelBuilder.Entity<language>(entity =>
        {
            entity.HasKey(e => e.code);

            entity.Property(e => e.code).HasMaxLength(3);
            entity.Property(e => e.flag)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<league>(entity =>
        {
            entity.Property(e => e.active).HasDefaultValue(true);
            entity.Property(e => e.code).HasMaxLength(100);
            entity.Property(e => e.create_date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.icon_url).HasMaxLength(500);
            entity.Property(e => e.name_en).HasMaxLength(100);
            entity.Property(e => e.name_tr).HasMaxLength(100);
        });

        modelBuilder.Entity<log_request>(entity =>
        {
            entity.Property(e => e.create_time)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ip_address_remote).HasMaxLength(500);
            entity.Property(e => e.req_url).HasMaxLength(500);
            entity.Property(e => e.used_token).HasMaxLength(1000);
            entity.Property(e => e.user_agent).HasMaxLength(500);
        });

        modelBuilder.Entity<mail>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__mail__3213E83F202CE1C7");

            entity.Property(e => e.body).HasColumnType("ntext");
            entity.Property(e => e.description).HasMaxLength(100);
            entity.Property(e => e.error_message)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.screen).HasDefaultValue(true);
            entity.Property(e => e.subject).HasMaxLength(500);
            entity.Property(e => e.update_date).HasColumnType("datetime");
            entity.Property(e => e.users).HasColumnType("ntext");
        });

        modelBuilder.Entity<menu>(entity =>
        {
            entity.Property(e => e.active).HasDefaultValue(true);
            entity.Property(e => e.code).HasMaxLength(20);
            entity.Property(e => e.href).HasMaxLength(500);
            entity.Property(e => e.img).HasMaxLength(300);
            entity.Property(e => e.name_en).HasMaxLength(100);
            entity.Property(e => e.name_tr).HasMaxLength(100);
            entity.Property(e => e.show).HasDefaultValue(true);
            entity.Property(e => e.type).HasMaxLength(20);
        });

        modelBuilder.Entity<nation>(entity =>
        {
            entity.Property(e => e.active).HasDefaultValue(true);
            entity.Property(e => e.code).HasMaxLength(100);
            entity.Property(e => e.code_short_en).HasMaxLength(10);
            entity.Property(e => e.code_short_tr).HasMaxLength(10);
            entity.Property(e => e.create_date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.icon_url).HasMaxLength(1000);
            entity.Property(e => e.name_en).HasMaxLength(100);
            entity.Property(e => e.name_tr).HasMaxLength(100);
            entity.Property(e => e.update_date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<pack>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__pack__3213E83FE0C3840F");

            entity.Property(e => e.code).HasMaxLength(100);
            entity.Property(e => e.coin).HasMaxLength(100);
            entity.Property(e => e.fp).HasMaxLength(10);
            entity.Property(e => e.langs).HasMaxLength(200);

            entity.HasOne(d => d.category).WithMany(p => p.pack)
                .HasForeignKey(d => d.category_id)
                .HasConstraintName("fk_packx");
        });

        modelBuilder.Entity<pack_category>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__pack_cat__3213E83FF4C1F22B");

            entity.Property(e => e.active).HasDefaultValue(true);
            entity.Property(e => e.langs).HasMaxLength(500);
        });

        modelBuilder.Entity<plan>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__plan__3213E83F58CF800B");

            entity.Property(e => e.code).HasMaxLength(100);
            entity.Property(e => e.create_date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.current_price).HasPrecision(0);
            entity.Property(e => e.icon)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.img).HasMaxLength(255);
            entity.Property(e => e.langs).HasMaxLength(255);
            entity.Property(e => e.update_date).HasColumnType("datetime");
        });

        modelBuilder.Entity<player>(entity =>
        {
            entity.Property(e => e.create_date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.fixed_name).HasMaxLength(100);
            entity.Property(e => e.full_name).HasMaxLength(100);
            entity.Property(e => e.futbin_player_link)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.futbin_squat_link)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.name).HasMaxLength(100);
            entity.Property(e => e.price_cross).HasDefaultValue(200);
            entity.Property(e => e.price_pc).HasDefaultValue(200);
            entity.Property(e => e.update_date).HasColumnType("datetime");
            entity.Property(e => e.url).HasMaxLength(500);
            entity.Property(e => e.url_img_card).HasMaxLength(500);
            entity.Property(e => e.url_img_club).HasMaxLength(500);
            entity.Property(e => e.url_img_league).HasMaxLength(500);
            entity.Property(e => e.url_img_nation).HasMaxLength(500);
            entity.Property(e => e.url_img_player).HasMaxLength(500);

            entity.HasOne(d => d.club).WithMany(p => p.player)
                .HasForeignKey(d => d.club_id)
                .HasConstraintName("FK_player_club");

            entity.HasOne(d => d.league).WithMany(p => p.player)
                .HasForeignKey(d => d.league_id)
                .HasConstraintName("FK_player_league");

            entity.HasOne(d => d.nation).WithMany(p => p.player)
                .HasForeignKey(d => d.nation_id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_player_nation");

            entity.HasOne(d => d.position).WithMany(p => p.player)
                .HasForeignKey(d => d.position_id)
                .HasConstraintName("FK_player_position");

            entity.HasOne(d => d.quality).WithMany(p => p.player)
                .HasForeignKey(d => d.quality_id)
                .HasConstraintName("FK_player_quality");

            entity.HasOne(d => d.rarity).WithMany(p => p.player)
                .HasForeignKey(d => d.rarity_id)
                .HasConstraintName("FK_player_rarity");

            entity.HasOne(d => d.update_user).WithMany(p => p.player)
                .HasForeignKey(d => d.update_user_id)
                .HasConstraintName("FK_player_update_user");
        });

        modelBuilder.Entity<position>(entity =>
        {
            entity.Property(e => e.code)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.create_date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.icon_url).HasMaxLength(500);
            entity.Property(e => e.name_en).HasMaxLength(50);
            entity.Property(e => e.name_tr).HasMaxLength(50);
        });

        modelBuilder.Entity<quality>(entity =>
        {
            entity.Property(e => e.active).HasDefaultValue(true);
            entity.Property(e => e.code).HasMaxLength(20);
            entity.Property(e => e.create_date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.icon_url).HasMaxLength(500);
            entity.Property(e => e.name_en).HasMaxLength(100);
            entity.Property(e => e.name_tr).HasMaxLength(100);
        });

        modelBuilder.Entity<rarity>(entity =>
        {
            entity.Property(e => e.active).HasDefaultValue(true);
            entity.Property(e => e.card_url)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.code).HasMaxLength(50);
            entity.Property(e => e.create_date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.futbin_class)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.futbin_value).HasMaxLength(50);
            entity.Property(e => e.futwiz_id).HasMaxLength(50);
            entity.Property(e => e.icon_url).HasMaxLength(500);
            entity.Property(e => e.name_en).HasMaxLength(100);
            entity.Property(e => e.name_tr).HasMaxLength(100);
            entity.Property(e => e.req_key)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<sbc>(entity =>
        {
            entity.HasIndex(e => e.category_id, "IX_sbc_category_id");

            entity.Property(e => e.active).HasDefaultValue(false);
            entity.Property(e => e.code).HasMaxLength(500);
            entity.Property(e => e.create_date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.daily).HasDefaultValue(false);
            entity.Property(e => e.desc_en).HasMaxLength(300);
            entity.Property(e => e.desc_tr).HasMaxLength(300);
            entity.Property(e => e.group).HasDefaultValue(false);
            entity.Property(e => e.icon_url).HasMaxLength(500);
            entity.Property(e => e.integration_date).HasColumnType("datetime");
            entity.Property(e => e.loyality).HasDefaultValue(false);
            entity.Property(e => e.name_en).HasMaxLength(200);
            entity.Property(e => e.name_tr).HasMaxLength(200);
            entity.Property(e => e.req).HasDefaultValue(false);
            entity.Property(e => e.reqs).HasMaxLength(2000);
            entity.Property(e => e.squad_link)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.tradeable).HasDefaultValue(false);
            entity.Property(e => e.update_date).HasColumnType("datetime");
            entity.Property(e => e.use_filter).HasDefaultValue(false);

            entity.HasOne(d => d.category).WithMany(p => p.sbc)
                .HasForeignKey(d => d.category_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_sbc_sbc_category");
        });

        modelBuilder.Entity<sbc_category>(entity =>
        {
            entity.Property(e => e.active).HasDefaultValue(true);
            entity.Property(e => e.code)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.name_en).HasMaxLength(100);
            entity.Property(e => e.name_tr).HasMaxLength(100);
        });

        modelBuilder.Entity<sbc_player>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_sbc_player_x");

            entity.HasIndex(e => e.club_id, "IX_sbc_player_x_club_id");

            entity.HasIndex(e => e.league_id, "IX_sbc_player_x_league_id");

            entity.HasIndex(e => e.nation_id, "IX_sbc_player_x_nation_id");

            entity.HasIndex(e => e.position_id, "IX_sbc_player_x_position_id");

            entity.HasIndex(e => e.quality_id, "IX_sbc_player_x_quality_id");

            entity.HasIndex(e => e.sbc_id, "IX_sbc_player_x_sbc_id");

            entity.HasIndex(e => e.user_id, "IX_sbc_player_x_user_id");

            entity.Property(e => e.active).HasDefaultValue(true);
            entity.Property(e => e.create_date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.first_owner).HasDefaultValue(false);
            entity.Property(e => e.fixed_name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.full_name).HasMaxLength(50);
            entity.Property(e => e.name).HasMaxLength(50);
            entity.Property(e => e.req).HasDefaultValue(false);
            entity.Property(e => e.update_date).HasColumnType("datetime");

            entity.HasOne(d => d.club).WithMany(p => p.sbc_player)
                .HasForeignKey(d => d.club_id)
                .HasConstraintName("FK_sbc_player_x_club");

            entity.HasOne(d => d.league).WithMany(p => p.sbc_player)
                .HasForeignKey(d => d.league_id)
                .HasConstraintName("FK_sbc_player_x_league");

            entity.HasOne(d => d.nation).WithMany(p => p.sbc_player)
                .HasForeignKey(d => d.nation_id)
                .HasConstraintName("FK_sbc_player_x_nation");

            entity.HasOne(d => d.position).WithMany(p => p.sbc_player)
                .HasForeignKey(d => d.position_id)
                .HasConstraintName("FK_sbc_player_x_position");

            entity.HasOne(d => d.quality).WithMany(p => p.sbc_player)
                .HasForeignKey(d => d.quality_id)
                .HasConstraintName("FK_sbc_player_x_quality");

            entity.HasOne(d => d.rarity).WithMany(p => p.sbc_player)
                .HasForeignKey(d => d.rarity_id)
                .HasConstraintName("fk_player_rarity_to_rarity");

            entity.HasOne(d => d.sbc).WithMany(p => p.sbc_player)
                .HasForeignKey(d => d.sbc_id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_sbc_player_x_sbc");

            entity.HasOne(d => d.user).WithMany(p => p.sbc_player)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK_sbc_player_x_user");
        });

        modelBuilder.Entity<startup_feature>(entity =>
        {
            entity.Property(e => e.code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.create_date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.name_en).HasMaxLength(100);
            entity.Property(e => e.name_tr).HasMaxLength(100);
            entity.Property(e => e.value1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.value2).HasMaxLength(20);
        });

        modelBuilder.Entity<subscription>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_user_membership_request");

            entity.HasIndex(e => e.user_id, "IX_user_membership_request_user_id");

            entity.Property(e => e.confirm_code).HasMaxLength(50);
            entity.Property(e => e.count).HasDefaultValue(1);
            entity.Property(e => e.create_date).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.currency).HasMaxLength(50);
            entity.Property(e => e.discount_code).HasMaxLength(50);
            entity.Property(e => e.duration_type).HasMaxLength(10);
            entity.Property(e => e.login_limit).HasDefaultValue((short)10);
            entity.Property(e => e.membership_type).HasMaxLength(10);
            entity.Property(e => e.note).HasMaxLength(100);
            entity.Property(e => e.payment_method)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.payment_type).HasMaxLength(20);
            entity.Property(e => e.rate_comment).HasMaxLength(500);
            entity.Property(e => e.rated_date).HasColumnType("datetime");
            entity.Property(e => e.status)
                .HasMaxLength(50)
                .HasDefaultValue("waiting");

            entity.HasOne(d => d.user).WithMany(p => p.subscription)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("fk_user_membership_request_to_user");
        });

        modelBuilder.Entity<sys_setting>(entity =>
        {
            entity.Property(e => e.broken_player_names)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.coach_nations).HasMaxLength(1000);
            entity.Property(e => e.coachs).HasMaxLength(1000);
            entity.Property(e => e.coin_card_ratio).HasDefaultValue((short)4);
            entity.Property(e => e.crypto_btc)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.crypto_eth)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.crypto_tether_erc)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.crypto_tether_trc)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.crypto_tl_iban)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.crypto_tl_iban_bank)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.crypto_tl_iban_owner)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.crypto_tryc)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.discount_percent_month).HasDefaultValue(5);
            entity.Property(e => e.discount_percent_two_months).HasDefaultValue(10);
            entity.Property(e => e.download_link)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.download_url).HasMaxLength(100);
            entity.Property(e => e.email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.facebook_link)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.futbin_sbc_integration_link)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.hide_prices).HasDefaultValue(true);
            entity.Property(e => e.integration).HasMaxLength(100);
            entity.Property(e => e.integration_url)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.max_buy_limit).HasMaxLength(8);
            entity.Property(e => e.max_session_limit).HasDefaultValue(50);
            entity.Property(e => e.paypal_email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.quick_sellable_coach_nations_en)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.quick_sellable_coach_nations_tr).HasMaxLength(1000);
            entity.Property(e => e.resolve_limit).HasDefaultValue(30);
            entity.Property(e => e.sbc_req_rating_limit).HasDefaultValue((short)81);
            entity.Property(e => e.social_discord)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.social_facebook)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.social_instagram)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.social_logo).HasMaxLength(500);
            entity.Property(e => e.social_telegram)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.social_twitter)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.social_whatsapp)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.social_youtube)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.supplier_commission).HasColumnType("numeric(38, 0)");
            entity.Property(e => e.sync_sbc_reqs).HasDefaultValue(false);
            entity.Property(e => e.sync_time).HasPrecision(0);
            entity.Property(e => e.version)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.version_updated).HasMaxLength(15);
            entity.Property(e => e.video_install).HasMaxLength(500);
            entity.Property(e => e.waiting_for_new_season).HasDefaultValue(true);
            entity.Property(e => e.webapp_url).HasMaxLength(100);
            entity.Property(e => e.website_link)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.whatsapp_channel).HasMaxLength(500);
            entity.Property(e => e.whatsapp_no).HasMaxLength(20);
            entity.Property(e => e.worker_log).HasMaxLength(500);
            entity.Property(e => e.worker_runned_date).HasColumnType("datetime");
            entity.Property(e => e.wp_invite_link).HasMaxLength(200);
        });

        modelBuilder.Entity<user>(entity =>
        {
            entity.HasIndex(e => e.reseller_id, "IX_user_reseller_id");

            entity.Property(e => e.active).HasDefaultValue(false);
            entity.Property(e => e.auto_login_code).HasMaxLength(50);
            entity.Property(e => e.can_promotion).HasDefaultValue(false);
            entity.Property(e => e.contact_buy_coins).HasDefaultValue(true);
            entity.Property(e => e.contact_mail_price_change).HasDefaultValue(true);
            entity.Property(e => e.contact_mail_subs_expire).HasDefaultValue(true);
            entity.Property(e => e.contact_mail_webapp_opened).HasDefaultValue(true);
            entity.Property(e => e.create_date).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.crypt_sender_address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.crypto_platform_name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.crypto_sender_name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.email).HasMaxLength(100);
            entity.Property(e => e.lang_app)
                .HasMaxLength(5)
                .HasDefaultValue("en");
            entity.Property(e => e.last_used_ip).HasMaxLength(500);
            entity.Property(e => e.login_limit).HasDefaultValue((short)10);
            entity.Property(e => e.max_login_limit).HasDefaultValue(1);
            entity.Property(e => e.name).HasMaxLength(100);
            entity.Property(e => e.note).HasMaxLength(200);
            entity.Property(e => e.password).HasMaxLength(100);
            entity.Property(e => e.password_reset_code).HasMaxLength(4);
            entity.Property(e => e.phone).HasMaxLength(13);
            entity.Property(e => e.phone_area).HasMaxLength(6);
            entity.Property(e => e.register_source).HasMaxLength(20);
            entity.Property(e => e.registered_ip_address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.role).HasMaxLength(50);
            entity.Property(e => e.subscription_type)
                .HasMaxLength(10)
                .HasDefaultValue("gold");
            entity.Property(e => e.trial_confirm_date).HasColumnType("datetime");
            entity.Property(e => e.trial_requested_date).HasColumnType("datetime");
            entity.Property(e => e.trial_requested_ip_address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.trial_status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("pending\r\nconfirmed");
            entity.Property(e => e.version).HasMaxLength(10);

            entity.HasOne(d => d.inviter_user).WithMany(p => p.Inverseinviter_user)
                .HasForeignKey(d => d.inviter_user_id)
                .HasConstraintName("FK_User_InviterUser");

            entity.HasOne(d => d.resellerNavigation).WithMany(p => p.InverseresellerNavigation)
                .HasForeignKey(d => d.reseller_id)
                .HasConstraintName("fk_reseller_id");
        });

        modelBuilder.Entity<user_club>(entity =>
        {
            entity.HasIndex(e => e.user_id, "IX_user_club_user_id");

            entity.Property(e => e.account_name).HasMaxLength(100);
            entity.Property(e => e.active).HasDefaultValue(true);
            entity.Property(e => e.create_date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.name).HasMaxLength(100);
            entity.Property(e => e.nation_code).HasMaxLength(3);
            entity.Property(e => e.note).HasMaxLength(100);
            entity.Property(e => e.platform).HasMaxLength(5);
            entity.Property(e => e.point).HasMaxLength(50);
            entity.Property(e => e.unlock).HasDefaultValue(true);
            entity.Property(e => e.update_date).HasColumnType("datetime");

            entity.HasOne(d => d.user).WithMany(p => p.user_club)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("fk_user_club_to_user");
        });

        modelBuilder.Entity<user_coin_supplier>(entity =>
        {
            entity.Property(e => e.create_date).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.supplier__user_id).HasColumnName("supplier_.user_id");
        });

        modelBuilder.Entity<user_login>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__user_log__3213E83FD92BFC56");

            entity.Property(e => e.create_time)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ip)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.new_attemped_ip).HasMaxLength(50);
            entity.Property(e => e.token).HasMaxLength(1000);
            entity.Property(e => e.token_expire).HasPrecision(0);
            entity.Property(e => e.type)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.update_time)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.version).HasMaxLength(10);

            entity.HasOne(d => d.user_club).WithMany(p => p.user_login)
                .HasForeignKey(d => d.user_club_id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_user_login_user_club");

            entity.HasOne(d => d.user).WithMany(p => p.user_login)
                .HasForeignKey(d => d.user_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_login_user");
        });

        modelBuilder.Entity<user_login_attempt>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__user_log__3213E83F4194D730");

            entity.Property(e => e.create_date).HasColumnType("datetime");
            entity.Property(e => e.ip)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<user_menu_settings>(entity =>
        {
            entity.HasIndex(e => e.user_id, "IX_user_menu_settings_user_id");

            entity.HasIndex(e => e.user_id, "uc_user_id").IsUnique();

            entity.Property(e => e.action_speed).HasDefaultValue((byte)3);
            entity.Property(e => e.action_speed_max).HasDefaultValue(5);
            entity.Property(e => e.add_to_tlist_club_players).HasDefaultValue(true);
            entity.Property(e => e.add_to_tlist_consumables_all).HasDefaultValue(false);
            entity.Property(e => e.add_to_tlist_consumables_chemistry_style).HasDefaultValue(false);
            entity.Property(e => e.add_to_tlist_consumables_contract).HasDefaultValue(false);
            entity.Property(e => e.add_to_tlist_consumables_healing).HasDefaultValue(false);
            entity.Property(e => e.add_to_tlist_consumables_manager_league).HasDefaultValue(false);
            entity.Property(e => e.add_to_tlist_consumables_positioning).HasDefaultValue(false);
            entity.Property(e => e.add_to_tlist_dont_use_active_squat_players).HasDefaultValue(true);
            entity.Property(e => e.add_to_tlist_sell_items).HasDefaultValue(false);
            entity.Property(e => e.add_to_tlist_staff).HasDefaultValue(false);
            entity.Property(e => e.add_to_tlist_unassigned_items).HasDefaultValue(true);
            entity.Property(e => e.auto_bid_add_won_items_to_club).HasDefaultValue(false);
            entity.Property(e => e.auto_bid_add_won_items_to_transfer_list).HasDefaultValue(true);
            entity.Property(e => e.auto_bid_add_won_items_to_transfer_market).HasDefaultValue(false);
            entity.Property(e => e.auto_bid_list_on_tmarket).HasDefaultValue(false);
            entity.Property(e => e.auto_bid_next_tour_sleep_duration).HasDefaultValue(300);
            entity.Property(e => e.auto_bid_run_tmarket).HasDefaultValue(false);
            entity.Property(e => e.club_sortage)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.create_date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.pac_open_pack).HasDefaultValue(false);
            entity.Property(e => e.pac_preview).HasDefaultValue(false);
            entity.Property(e => e.pack_action)
                .HasMaxLength(50)
                .HasDefaultValue("open");
            entity.Property(e => e.pack_animation_skip).HasDefaultValue(true);
            entity.Property(e => e.pack_buy).HasDefaultValue(false);
            entity.Property(e => e.pack_buy_count).HasDefaultValue(10);
            entity.Property(e => e.pack_open_bronze).HasDefaultValue(true);
            entity.Property(e => e.pack_open_other_types).HasDefaultValue(true);
            entity.Property(e => e.pack_open_tradeables).HasDefaultValue(true);
            entity.Property(e => e.pack_open_untradeables).HasDefaultValue(true);
            entity.Property(e => e.pack_run_tmarket).HasDefaultValue(false);
            entity.Property(e => e.pack_sound).HasDefaultValue(true);
            entity.Property(e => e.packing_use_fp).HasDefaultValue(false);
            entity.Property(e => e.sbc_allow_buy_players).HasDefaultValue(true);
            entity.Property(e => e.sbc_allow_club_players).HasDefaultValue(true);
            entity.Property(e => e.sbc_buy_only_concept_players).HasDefaultValue(false);
            entity.Property(e => e.sbc_dont_buy_players).HasDefaultValue(true);
            entity.Property(e => e.sbc_dont_use_active_squat_players).HasDefaultValue(true);
            entity.Property(e => e.sbc_hide_solved).HasDefaultValue(false);
            entity.Property(e => e.sbc_open_packs).HasDefaultValue(false);
            entity.Property(e => e.sbc_search_club_player).HasDefaultValue(true);
            entity.Property(e => e.sbc_send_squat).HasDefaultValue(true);
            entity.Property(e => e.sbc_show_only_my_startup_sbcs).HasDefaultValue(false);
            entity.Property(e => e.sbc_show_only_tradeable).HasDefaultValue(false);
            entity.Property(e => e.sbc_use_active_squad_players).HasDefaultValue(true);
            entity.Property(e => e.sbc_use_concept_player).HasDefaultValue(false);
            entity.Property(e => e.sbc_use_futbin_address).HasDefaultValue(false);
            entity.Property(e => e.sbc_use_my_solutions).HasDefaultValue(false);
            entity.Property(e => e.sbc_use_tmarket_screen).HasDefaultValue(true);
            entity.Property(e => e.sbc_use_tradeables).HasDefaultValue(true);
            entity.Property(e => e.snipe_add_to_transfer_list).HasDefaultValue(false);
            entity.Property(e => e.snipe_add_to_transfer_market).HasDefaultValue(true);
            entity.Property(e => e.snipe_buy_count).HasDefaultValue(1);
            entity.Property(e => e.snipe_search_count).HasDefaultValue(15);
            entity.Property(e => e.snipe_sleep_duration).HasDefaultValue(300);
            entity.Property(e => e.startup_daily_sbcs_solve_count).HasDefaultValue(10);
            entity.Property(e => e.sync_data).HasDefaultValue(true);
            entity.Property(e => e.tmarket_list_price_change).HasDefaultValue((short)-1);
            entity.Property(e => e.tmarket_list_qs_active).HasDefaultValue(true);
            entity.Property(e => e.tmarket_list_qs_chemistry).HasDefaultValue(true);
            entity.Property(e => e.tmarket_list_qs_contract).HasDefaultValue(true);
            entity.Property(e => e.tmarket_list_qs_if_min_price).HasDefaultValue(false);
            entity.Property(e => e.tmarket_list_qs_manager).HasDefaultValue(true);
            entity.Property(e => e.tmarket_list_qs_other).HasDefaultValue(true);
            entity.Property(e => e.tmarket_list_qs_position).HasDefaultValue(false);
            entity.Property(e => e.tmarket_list_s_compare_price).HasDefaultValue(false);
            entity.Property(e => e.tmarket_list_s_list_on_market).HasDefaultValue(false);
            entity.Property(e => e.tmarket_list_s_price_change).HasDefaultValue(-1);
            entity.Property(e => e.tmarket_list_s_send_to_tlist).HasDefaultValue(true);
            entity.Property(e => e.tmarket_list_send_to_club_active).HasDefaultValue(false);
            entity.Property(e => e.tmarket_list_send_to_club_common_player).HasDefaultValue(false);
            entity.Property(e => e.tmarket_list_send_to_club_if_min_price).HasDefaultValue(false);
            entity.Property(e => e.tmarket_list_send_to_club_rare_player).HasDefaultValue(false);
            entity.Property(e => e.tmarket_player_pick_option_id)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.tmarket_qs_chemistry).HasDefaultValue(true);
            entity.Property(e => e.tmarket_qs_direct_tradeable).HasDefaultValue(true);
            entity.Property(e => e.tmarket_qs_if_min_price_list_type).HasMaxLength(10);
            entity.Property(e => e.tmarket_qs_if_min_price_rating_max).HasDefaultValue((short)82);
            entity.Property(e => e.tmarket_qs_if_min_price_rating_min).HasDefaultValue((short)47);
            entity.Property(e => e.tmarket_qs_manager).HasDefaultValue(true);
            entity.Property(e => e.tmarket_relist_price_change).HasDefaultValue((short)-1);
            entity.Property(e => e.tmarket_relist_qs_active).HasDefaultValue(true);
            entity.Property(e => e.tmarket_relist_qs_chemistry).HasDefaultValue(true);
            entity.Property(e => e.tmarket_relist_qs_contract).HasDefaultValue(true);
            entity.Property(e => e.tmarket_relist_qs_if_min_price).HasDefaultValue(false);
            entity.Property(e => e.tmarket_relist_qs_manager).HasDefaultValue(true);
            entity.Property(e => e.tmarket_relist_qs_other).HasDefaultValue(true);
            entity.Property(e => e.tmarket_relist_qs_position).HasDefaultValue(false);
            entity.Property(e => e.tmarket_relist_s_compare_price).HasDefaultValue(false);
            entity.Property(e => e.tmarket_relist_s_price_change).HasDefaultValue(-1);
            entity.Property(e => e.tmarket_relist_send_to_club_active).HasDefaultValue(false);
            entity.Property(e => e.tmarket_relist_send_to_club_common_player).HasDefaultValue(false);
            entity.Property(e => e.tmarket_relist_send_to_club_if_min_price).HasDefaultValue(false);
            entity.Property(e => e.tmarket_relist_send_to_club_rare_player).HasDefaultValue(false);
            entity.Property(e => e.tmarket_s2tl).HasDefaultValue(true);
            entity.Property(e => e.tmarket_send_to_club_unsold_min_priced).HasDefaultValue(false);
            entity.Property(e => e.update_time).HasColumnType("datetime");

            entity.HasOne(d => d.user).WithOne(p => p.user_menu_settings)
                .HasForeignKey<user_menu_settings>(d => d.user_id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_user_filter_to_user");
        });

        modelBuilder.Entity<user_sbc>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__user_sbc__3213E83FEF5E2811");

            entity.Property(e => e.active_squad).HasDefaultValue(true);
            entity.Property(e => e.create_date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.reqs)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.squad_link)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.update_date).HasColumnType("datetime");

            entity.HasOne(d => d.sbc).WithMany(p => p.user_sbc)
                .HasForeignKey(d => d.sbc_id)
                .HasConstraintName("fk_user_sbc_to_sbc");

            entity.HasOne(d => d.user).WithMany(p => p.user_sbc)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("fk_user_sbc_to_user");
        });

        modelBuilder.Entity<user_sbc_submit>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__user_sbc__3213E83F73E43226");

            entity.HasIndex(e => new { e.user_id, e.sbc_id }, "IX_UserSbcSubmit_UserID_SBCID");

            entity.Property(e => e.create_time)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.account).WithMany(p => p.user_sbc_submit)
                .HasForeignKey(d => d.account_id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_user_sbc_submit_account");

            entity.HasOne(d => d.sbc).WithMany(p => p.user_sbc_submit)
                .HasForeignKey(d => d.sbc_id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_user_sbc_submit_sbc");

            entity.HasOne(d => d.user).WithMany(p => p.user_sbc_submit)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("fk_user_sbc_submit_user");
        });

        modelBuilder.Entity<user_startup>(entity =>
        {
            entity.Property(e => e.create_date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.sort_number).HasDefaultValue(1);
            entity.Property(e => e.update_time).HasColumnType("datetime");
            entity.Property(e => e.value1).HasMaxLength(100);
            entity.Property(e => e.value2)
                .HasMaxLength(20)
                .HasDefaultValue("bronze");

            entity.HasOne(d => d.feature).WithMany(p => p.user_startup)
                .HasForeignKey(d => d.feature_id)
                .HasConstraintName("FK_user_startup_user_startup1");

            entity.HasOne(d => d.user).WithMany(p => p.user_startup)
                .HasForeignKey(d => d.user_id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_user_startup_to_user");
        });

        modelBuilder.Entity<version>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__version__3213E83F48A9B4D1");

            entity.Property(e => e.create_date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.season).HasMaxLength(4);
        });

        modelBuilder.Entity<vw_request_log>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_request_log");

            entity.Property(e => e.create_time).HasColumnType("datetime");
            entity.Property(e => e.id).ValueGeneratedOnAdd();
            entity.Property(e => e.ip_address_remote).HasMaxLength(500);
            entity.Property(e => e.req_url).HasMaxLength(500);
            entity.Property(e => e.used_token).HasMaxLength(1000);
            entity.Property(e => e.user_agent).HasMaxLength(500);
            entity.Property(e => e.user_name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
