// <auto-generated />
using System;
using MMIP.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MMIP.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MMIP.Shared.Entities.Challenge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("BannerImagePath")
                        .HasMaxLength(254)
                        .HasColumnType("character varying(254)")
                        .HasColumnName("banner_image_path");

                    b.Property<string>("ChallengeVisibility")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("challenge_visibility");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date")
                        .HasDefaultValueSql("NOW()");

                    b.Property<Guid>("CurrentPhaseId")
                        .HasColumnType("uuid")
                        .HasColumnName("current_phase_id");

                    b.Property<DateTimeOffset>("Deadline")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deadline");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100000)
                        .HasColumnType("character varying(100000)")
                        .HasColumnName("description");

                    b.Property<string>("FinalReport")
                        .HasMaxLength(100000)
                        .HasColumnType("character varying(100000)")
                        .HasColumnName("final_report");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uuid")
                        .HasColumnName("organization_id");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("short_description");

                    b.Property<DateTimeOffset>("StartDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("title");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id")
                        .HasName("pk_challenges");

                    b.HasIndex("OrganizationId")
                        .HasDatabaseName("ix_challenges_organization_id");

                    b.ToTable("challenges", (string)null);
                });

            modelBuilder.Entity("MMIP.Shared.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CommentType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("comment_type");

                    b.Property<bool>("Concluded")
                        .HasColumnType("boolean")
                        .HasColumnName("concluded");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("text");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id")
                        .HasName("pk_comments");

                    b.ToTable("comments", (string)null);
                });

            modelBuilder.Entity("MMIP.Shared.Entities.Industry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("character varying(254)")
                        .HasColumnName("name");

                    b.Property<Guid>("SectorId")
                        .HasColumnType("uuid")
                        .HasColumnName("sector_id");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id")
                        .HasName("pk_industries");

                    b.HasIndex("SectorId")
                        .HasDatabaseName("ix_industries_sector_id");

                    b.ToTable("industries", (string)null);
                });

            modelBuilder.Entity("MMIP.Shared.Entities.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("EnrollmentCode")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)")
                        .HasColumnName("enrollment_code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("name");

                    b.Property<Guid>("SectorId")
                        .HasColumnType("uuid")
                        .HasColumnName("sector_id");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id")
                        .HasName("pk_organizations");

                    b.HasIndex("SectorId")
                        .HasDatabaseName("ix_organizations_sector_id");

                    b.ToTable("organizations", (string)null);
                });

            modelBuilder.Entity("MMIP.Shared.Entities.Phase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("character varying(254)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("character varying(24)")
                        .HasColumnName("name");

                    b.Property<int>("Order")
                        .HasColumnType("integer")
                        .HasColumnName("order");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id")
                        .HasName("pk_phases");

                    b.ToTable("phases", (string)null);
                });

            modelBuilder.Entity("MMIP.Shared.Entities.Sector", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("character varying(254)")
                        .HasColumnName("name");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id")
                        .HasName("pk_sectors");

                    b.ToTable("sectors", (string)null);
                });

            modelBuilder.Entity("MMIP.Shared.Entities.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date")
                        .HasDefaultValueSql("NOW()");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("pk_tags");

                    b.HasIndex("Value")
                        .IsUnique()
                        .HasDatabaseName("ix_tags_value");

                    b.ToTable("tags", (string)null);
                });

            modelBuilder.Entity("MMIP.Shared.Entities.UserGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id")
                        .HasName("pk_user_groups");

                    b.ToTable("user_groups", (string)null);
                });

            modelBuilder.Entity("MMIP.Shared.Views.ChallengeCardView", b =>
                {
                    b.Property<string>("BannerImagePath")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("banner_image_path");

                    b.Property<Guid>("ChallengeId")
                        .HasColumnType("uuid")
                        .HasColumnName("challenge_id");

                    b.Property<string>("OrganizationName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("organization_name");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("short_description");

                    b.Property<string>("TagsString")
                        .HasColumnType("text")
                        .HasColumnName("tags");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.ToTable((string)null);

                    b.ToView("challenge_card_view", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_name");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_roles");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("role_id");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_role_claims");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_asp_net_role_claims_role_id");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_user_claims");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_asp_net_user_claims_user_id");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("login_provider");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("provider_key");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text")
                        .HasColumnName("provider_display_name");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("pk_asp_net_user_logins");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_asp_net_user_logins_user_id");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.Property<string>("RoleId")
                        .HasColumnType("text")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId")
                        .HasName("pk_asp_net_user_roles");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_asp_net_user_roles_role_id");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("login_provider");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("pk_asp_net_user_tokens");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("challenge_phases", b =>
                {
                    b.Property<Guid>("ChallengeId")
                        .HasColumnType("uuid")
                        .HasColumnName("challenge_id");

                    b.Property<Guid>("PhasesId")
                        .HasColumnType("uuid")
                        .HasColumnName("phase_id");

                    b.Property<DateTimeOffset>("EnteredAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("entered_at")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("ChallengeId", "PhasesId")
                        .HasName("pk_challenge_phases");

                    b.HasIndex("PhasesId")
                        .HasDatabaseName("ix_challenge_phases_phases_id");

                    b.ToTable("challenge_phases", (string)null);
                });

            modelBuilder.Entity("challenge_tags", b =>
                {
                    b.Property<Guid>("ChallengeId")
                        .HasColumnType("uuid")
                        .HasColumnName("challenge_id");

                    b.Property<Guid>("TagsId")
                        .HasColumnType("uuid")
                        .HasColumnName("tag_id");

                    b.HasKey("ChallengeId", "TagsId")
                        .HasName("pk_challenge_tags");

                    b.HasIndex("TagsId")
                        .HasDatabaseName("ix_challenge_tags_tags_id");

                    b.ToTable("challenge_tags", (string)null);
                });

            modelBuilder.Entity("phase_visible_to_user_groups", b =>
                {
                    b.Property<Guid>("PhaseId")
                        .HasColumnType("uuid")
                        .HasColumnName("phase_id");

                    b.Property<Guid>("VisibleToId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_group_id");

                    b.HasKey("PhaseId", "VisibleToId")
                        .HasName("pk_phase_visible_to_user_groups");

                    b.HasIndex("VisibleToId")
                        .HasDatabaseName("ix_phase_visible_to_user_groups_visible_to_id");

                    b.ToTable("phase_visible_to_user_groups", (string)null);
                });

            modelBuilder.Entity("MMIP.Shared.Entities.Challenge", b =>
                {
                    b.HasOne("MMIP.Shared.Entities.Organization", null)
                        .WithMany("Challenges")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_challenges_organizations_organization_id");
                });

            modelBuilder.Entity("MMIP.Shared.Entities.Industry", b =>
                {
                    b.HasOne("MMIP.Shared.Entities.Sector", "Sector")
                        .WithMany()
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_industries_sectors_sector_id");

                    b.Navigation("Sector");
                });

            modelBuilder.Entity("MMIP.Shared.Entities.Organization", b =>
                {
                    b.HasOne("MMIP.Shared.Entities.Sector", null)
                        .WithMany()
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_organizations_sectors_sector_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_role_claims_asp_net_roles_role_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MMIP.Infrastructure.Models.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_claims_asp_net_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MMIP.Infrastructure.Models.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_logins_asp_net_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_roles_asp_net_roles_role_id");

                    b.HasOne("MMIP.Infrastructure.Models.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_roles_asp_net_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MMIP.Infrastructure.Models.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_tokens_asp_net_users_user_id");
                });

            modelBuilder.Entity("challenge_phases", b =>
                {
                    b.HasOne("MMIP.Shared.Entities.Challenge", null)
                        .WithMany()
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_challenge_phases_challenges_challenge_id");

                    b.HasOne("MMIP.Shared.Entities.Phase", null)
                        .WithMany()
                        .HasForeignKey("PhasesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_challenge_phases_phases_phases_id");
                });

            modelBuilder.Entity("challenge_tags", b =>
                {
                    b.HasOne("MMIP.Shared.Entities.Challenge", null)
                        .WithMany()
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_challenge_tags_challenges_challenge_id");

                    b.HasOne("MMIP.Shared.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_challenge_tags_tags_tags_id");
                });

            modelBuilder.Entity("phase_visible_to_user_groups", b =>
                {
                    b.HasOne("MMIP.Shared.Entities.Phase", null)
                        .WithMany()
                        .HasForeignKey("PhaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_phase_visible_to_user_groups_phases_phase_id");

                    b.HasOne("MMIP.Shared.Entities.UserGroup", null)
                        .WithMany()
                        .HasForeignKey("VisibleToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_phase_visible_to_user_groups_user_groups_visible_to_id");
                });

            modelBuilder.Entity("MMIP.Shared.Entities.Organization", b =>
                {
                    b.Navigation("Challenges");
                });
#pragma warning restore 612, 618
        }
    }
}
