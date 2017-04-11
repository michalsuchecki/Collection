using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Collection.Models;

namespace Collection.Migrations
{
    [DbContext(typeof(ToyContext))]
    [Migration("20170213211844_ToyStatusAdded")]
    partial class ToyStatusAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Collection.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Collection.Models.Gallery", b =>
                {
                    b.Property<int>("GalleryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FileName")
                        .IsRequired();

                    b.Property<int>("ToyID");

                    b.HasKey("GalleryId");

                    b.HasIndex("ToyID");

                    b.ToTable("Gallery");
                });

            modelBuilder.Entity("Collection.Models.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("Collection.Models.Toy", b =>
                {
                    b.Property<int>("ToyID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Index")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("ProducerId");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.HasKey("ToyID");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProducerId");

                    b.ToTable("Toys");
                });

            modelBuilder.Entity("Collection.Models.Gallery", b =>
                {
                    b.HasOne("Collection.Models.Toy", "Toy")
                        .WithMany("Gallery")
                        .HasForeignKey("ToyID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Collection.Models.Toy", b =>
                {
                    b.HasOne("Collection.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("Collection.Models.Producer", "Producer")
                        .WithMany()
                        .HasForeignKey("ProducerId");
                });
        }
    }
}
