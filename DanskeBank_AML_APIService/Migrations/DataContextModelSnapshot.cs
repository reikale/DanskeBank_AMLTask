﻿// <auto-generated />
using System;
using DanskeBank_AML_APIService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DanskeBank_AML_APIService.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DanskeBank_AML_APIService.Models.TaxRules", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TaxRules");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "AddTaxes"
                        },
                        new
                        {
                            Id = 2,
                            Name = "ChooseSmallest"
                        });
                });

            modelBuilder.Entity("DanskeBank_AML_APIService.Models.TaxType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TaxType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Yearly"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Monthly"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Weekly"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Daily"
                        });
                });

            modelBuilder.Entity("DanskeBank_AMLTask_APIService.Models.Municipality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RuleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RuleId");

                    b.ToTable("Municipalities");
                });

            modelBuilder.Entity("DanskeBank_AMLTask_APIService.Models.Taxes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Municipality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MunicipalityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("TaxRate")
                        .HasColumnType("float");

                    b.Property<int>("TaxTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MunicipalityId");

                    b.HasIndex("TaxTypeId");

                    b.ToTable("Taxes");
                });

            modelBuilder.Entity("DanskeBank_AMLTask_APIService.Models.Municipality", b =>
                {
                    b.HasOne("DanskeBank_AML_APIService.Models.TaxRules", "Rule")
                        .WithMany()
                        .HasForeignKey("RuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rule");
                });

            modelBuilder.Entity("DanskeBank_AMLTask_APIService.Models.Taxes", b =>
                {
                    b.HasOne("DanskeBank_AMLTask_APIService.Models.Municipality", null)
                        .WithMany("Taxes")
                        .HasForeignKey("MunicipalityId");

                    b.HasOne("DanskeBank_AML_APIService.Models.TaxType", "TaxType")
                        .WithMany()
                        .HasForeignKey("TaxTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaxType");
                });

            modelBuilder.Entity("DanskeBank_AMLTask_APIService.Models.Municipality", b =>
                {
                    b.Navigation("Taxes");
                });
#pragma warning restore 612, 618
        }
    }
}
