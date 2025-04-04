﻿// <auto-generated />
using System;
using MMIP.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MMIP.Infrastructure.Context;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MMIP.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20231205104639_InitialChallengeConfiguration")]
    partial class InitialChallengeConfiguration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Shared.Entities.Branche", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid>("SectorId")
                        .HasColumnType("uuid")
                        .HasColumnName("sector_id");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id")
                        .HasName("pk_branches");

                    b.HasIndex("SectorId")
                        .HasDatabaseName("ix_branches_sector_id");

                    b.ToTable("branches", (string)null);
                });

            modelBuilder.Entity("Shared.Entities.Challenge", b =>
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
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
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

            modelBuilder.Entity("Shared.Entities.Comment", b =>
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

            modelBuilder.Entity("Shared.Entities.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id")
                        .HasName("pk_organizations");

                    b.ToTable("organizations", (string)null);
                });

            modelBuilder.Entity("Shared.Entities.Phase", b =>
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

                    b.Property<int>("Order")
                        .HasColumnType("integer")
                        .HasColumnName("order");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id")
                        .HasName("pk_phases");

                    b.ToTable("phases", (string)null);
                });

            modelBuilder.Entity("Shared.Entities.Sector", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id")
                        .HasName("pk_sector");

                    b.ToTable("sector", (string)null);
                });

            modelBuilder.Entity("Shared.Entities.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("pk_tag");

                    b.ToTable("tag", (string)null);
                });

            modelBuilder.Entity("Shared.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Shared.Entities.UserGroup", b =>
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

                    b.Property<Guid?>("PhaseId")
                        .HasColumnType("uuid")
                        .HasColumnName("phase_id");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id")
                        .HasName("pk_user_groups");

                    b.HasIndex("PhaseId")
                        .HasDatabaseName("ix_user_groups_phase_id");

                    b.ToTable("user_groups", (string)null);
                });

            modelBuilder.Entity("challenge_phases", b =>
                {
                    b.Property<Guid>("ChallengeId")
                        .HasColumnType("uuid")
                        .HasColumnName("challenge_id");

                    b.Property<Guid>("PhasesId")
                        .HasColumnType("uuid")
                        .HasColumnName("phase_id");

                    b.HasKey("ChallengeId", "PhasesId")
                        .HasName("pk_challenge_phases");

                    b.HasIndex("PhasesId")
                        .HasDatabaseName("ix_challenge_phases_phases_id");

                    b.ToTable("challenge_phases", (string)null);
                });

            modelBuilder.Entity("challenge_tags", b =>
                {
                    b.Property<Guid>("_tagsId")
                        .HasColumnType("uuid")
                        .HasColumnName("tag_id");

                    b.Property<Guid>("challengesId")
                        .HasColumnType("uuid")
                        .HasColumnName("challenge_id");

                    b.HasKey("_tagsId", "challengesId")
                        .HasName("pk_challenge_tags");

                    b.HasIndex("challengesId")
                        .HasDatabaseName("ix_challenge_tags_challenges_id");

                    b.ToTable("challenge_tags", (string)null);
                });

            modelBuilder.Entity("Shared.Entities.Branche", b =>
                {
                    b.HasOne("Shared.Entities.Sector", "Sector")
                        .WithMany()
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_branches_sector_sector_id");

                    b.Navigation("Sector");
                });

            modelBuilder.Entity("Shared.Entities.Challenge", b =>
                {
                    b.HasOne("Shared.Entities.Organization", "Organization")
                        .WithMany("Challenges")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired()
                        .HasConstraintName("fk_challenges_organizations_organization_id1");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Shared.Entities.UserGroup", b =>
                {
                    b.HasOne("Shared.Entities.Phase", null)
                        .WithMany("VisibleTo")
                        .HasForeignKey("PhaseId")
                        .HasConstraintName("fk_user_groups_phases_phase_id");
                });

            modelBuilder.Entity("challenge_phases", b =>
                {
                    b.HasOne("Shared.Entities.Challenge", null)
                        .WithMany()
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_challenge_phases_challenges_challenge_id");

                    b.HasOne("Shared.Entities.Phase", null)
                        .WithMany()
                        .HasForeignKey("PhasesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_challenge_phases_phases_phases_id");
                });

            modelBuilder.Entity("challenge_tags", b =>
                {
                    b.HasOne("Shared.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("_tagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_challenge_tags_tag__tags_id");

                    b.HasOne("Shared.Entities.Challenge", null)
                        .WithMany()
                        .HasForeignKey("challengesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_challenge_tags_challenges_challenges_id");
                });

            modelBuilder.Entity("Shared.Entities.Organization", b =>
                {
                    b.Navigation("Challenges");
                });

            modelBuilder.Entity("Shared.Entities.Phase", b =>
                {
                    b.Navigation("VisibleTo");
                });
#pragma warning restore 612, 618
        }
    }
}
