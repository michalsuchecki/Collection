using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MyInflatables.Models;

namespace MyInflatables.Migrations
{
    [DbContext(typeof(ToyContext))]
    [Migration("20170118204702_InitialDBWithSampleCategory")]
    partial class InitialDBWithSampleCategory
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

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MyInflatables.Models.Category", b =>
                {
                    b.HasOne("MyInflatables.Models.Category")
                        .WithMany("Parent")
                        .HasForeignKey("CategoryId");
                });
        }
    }
}
