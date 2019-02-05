﻿// <auto-generated />
using EyeTestABB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EyeTestABB.Migrations
{
    [DbContext(typeof(ContactDbContext))]
    partial class ContactDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EyeTestABB.Data.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName");

                    b.Property<string>("ContactNumber1");

                    b.Property<string>("ContactNumber2");

                    b.Property<string>("ContactNumber3");

                    b.Property<int>("CountryId");

                    b.Property<string>("EmailId");

                    b.Property<string>("FirstName");

                    b.Property<string>("HomeAddress");

                    b.Property<string>("ImagePath");

                    b.Property<string>("LastName");

                    b.Property<int>("StateId");

                    b.Property<string>("WorkAddress");

                    b.HasKey("ContactId");

                    b.HasIndex("CountryId");

                    b.HasIndex("StateId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("EyeTestABB.Data.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("EyeTestABB.Data.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("EyeTestABB.Data.Models.Contact", b =>
                {
                    b.HasOne("EyeTestABB.Data.Models.Country", "Country")
                        .WithMany("Contacts")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EyeTestABB.Data.Models.State", "State")
                        .WithMany("Contacts")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EyeTestABB.Data.Models.State", b =>
                {
                    b.HasOne("EyeTestABB.Data.Models.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
