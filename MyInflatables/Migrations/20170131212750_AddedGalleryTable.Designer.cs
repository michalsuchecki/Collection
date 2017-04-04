using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MyInflatables.Models;

namespace MyInflatables.Migrations
{
    [DbContext(typeof(ToyContext))]
    [Migration("20170131212750_AddedGalleryTable")]
    partial class AddedGalleryTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyInflatables.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MyInflatables.Models.Gallery", b =>
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

            modelBuilder.Entity("MyInflatables.Models.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("MyInflatables.Models.Toy", b =>
                {
                    b.Property<int>("ToyID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Index")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("ProducerId");

                    b.HasKey("ToyID");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProducerId");

                    b.ToTable("Toys");
                });

            modelBuilder.Entity("MyInflatables.Models.Gallery", b =>
                {
                    b.HasOne("MyInflatables.Models.Toy", "Toy")
                        .WithMany("Gallery")
                        .HasForeignKey("ToyID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyInflatables.Models.Toy", b =>
                {
                    b.HasOne("MyInflatables.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("MyInflatables.Models.Producer", "Producer")
                        .WithMany()
                        .HasForeignKey("ProducerId");
                });
        }
    }
}
