﻿// <auto-generated />
using GreenThumbGLevel.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GreenThumbGLevel.Migrations
{
    [DbContext(typeof(GreenThumbDbContext))]
    [Migration("20231207111902_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GreenThumbGLevel.Models.Instruction", b =>
                {
                    b.Property<int>("InstructionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstructionId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("InstructionId");

                    b.HasIndex("PlantName");

                    b.ToTable("Instructions");
                });

            modelBuilder.Entity("GreenThumbGLevel.Models.Plant", b =>
                {
                    b.Property<string>("PlantName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PlantDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlantOrigin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlantName");

                    b.ToTable("Plants");
                });

            modelBuilder.Entity("GreenThumbGLevel.Models.Instruction", b =>
                {
                    b.HasOne("GreenThumbGLevel.Models.Plant", "Plant")
                        .WithMany("Instruction")
                        .HasForeignKey("PlantName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("GreenThumbGLevel.Models.Plant", b =>
                {
                    b.Navigation("Instruction");
                });
#pragma warning restore 612, 618
        }
    }
}