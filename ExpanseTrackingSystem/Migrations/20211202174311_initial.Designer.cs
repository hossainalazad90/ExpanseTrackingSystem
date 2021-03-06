// <auto-generated />
using System;
using ExpanseTrackingSystem.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExpanseTrackingSystem.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20211202174311_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExpanseTrackingSystem.Context.Expanse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ExpanseAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ExpanseCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExpanseCategoryId");

                    b.ToTable("Expanses");
                });

            modelBuilder.Entity("ExpanseTrackingSystem.Context.ExpanseCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExpanseCategories");
                });

            modelBuilder.Entity("ExpanseTrackingSystem.Context.Expanse", b =>
                {
                    b.HasOne("ExpanseTrackingSystem.Context.ExpanseCategory", "ExpanseCategory")
                        .WithMany("Expanses")
                        .HasForeignKey("ExpanseCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
