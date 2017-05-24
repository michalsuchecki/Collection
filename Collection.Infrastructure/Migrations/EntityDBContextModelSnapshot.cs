﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Collection.Infrastructure.DAL;

namespace Collection.Infrastructure.Migrations
{
    [DbContext(typeof(EntityDBContext))]
    partial class EntityDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Collection.Core.Domain.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Collection.Core.Domain.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FileName");

                    b.Property<int?>("ItemId");

                    b.HasKey("ImageId");

                    b.HasIndex("ItemId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Collection.Core.Domain.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<bool>("InCollection");

                    b.Property<string>("Index");

                    b.Property<string>("Name");

                    b.Property<int?>("ProducerId");

                    b.HasKey("ItemId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProducerId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Collection.Core.Domain.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AuthorUserId");

                    b.Property<string>("Message");

                    b.Property<DateTime>("PublishDate");

                    b.Property<string>("Topic");

                    b.HasKey("PostId");

                    b.HasIndex("AuthorUserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Collection.Core.Domain.Producer", b =>
                {
                    b.Property<int>("ProducerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("URL");

                    b.HasKey("ProducerId");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("Collection.Core.Domain.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Nickname");

                    b.Property<string>("Password");

                    b.Property<string>("Salt");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Collection.Core.Domain.Image", b =>
                {
                    b.HasOne("Collection.Core.Domain.Item", "Item")
                        .WithMany("Images")
                        .HasForeignKey("ItemId");
                });

            modelBuilder.Entity("Collection.Core.Domain.Item", b =>
                {
                    b.HasOne("Collection.Core.Domain.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("Collection.Core.Domain.Producer", "Producer")
                        .WithMany()
                        .HasForeignKey("ProducerId");
                });

            modelBuilder.Entity("Collection.Core.Domain.Post", b =>
                {
                    b.HasOne("Collection.Core.Domain.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorUserId");
                });
        }
    }
}
