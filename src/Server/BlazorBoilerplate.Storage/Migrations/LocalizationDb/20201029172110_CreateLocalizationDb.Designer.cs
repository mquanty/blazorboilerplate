﻿// <auto-generated />
using BlazorBoilerplate.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlazorBoilerplate.Storage.Migrations.LocalizationDb
{
    [DbContext(typeof(LocalizationDbContext))]
    [Migration("20201029172110_CreateLocalizationDb")]
    partial class CreateLocalizationDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlazorBoilerplate.Infrastructure.Storage.DataModels.LocalizationRecord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContextId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Culture")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MsgId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MsgIdPlural")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Translation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MsgId", "Culture", "ContextId")
                        .IsUnique()
                        .HasFilter("[MsgId] IS NOT NULL AND [Culture] IS NOT NULL AND [ContextId] IS NOT NULL");

                    b.ToTable("LocalizationRecords");
                });

            modelBuilder.Entity("BlazorBoilerplate.Infrastructure.Storage.DataModels.PluralFormRule", b =>
                {
                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Selector")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Language");

                    b.ToTable("PluralFormRules");
                });

            modelBuilder.Entity("BlazorBoilerplate.Infrastructure.Storage.DataModels.PluralTranslation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<long>("LocalizationRecordId")
                        .HasColumnType("bigint");

                    b.Property<string>("Translation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocalizationRecordId");

                    b.ToTable("PluralTranslations");
                });

            modelBuilder.Entity("BlazorBoilerplate.Infrastructure.Storage.DataModels.PluralTranslation", b =>
                {
                    b.HasOne("BlazorBoilerplate.Infrastructure.Storage.DataModels.LocalizationRecord", "LocalizationRecord")
                        .WithMany("PluralTranslations")
                        .HasForeignKey("LocalizationRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
