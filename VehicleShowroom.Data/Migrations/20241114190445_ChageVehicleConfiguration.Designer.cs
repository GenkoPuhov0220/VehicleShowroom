﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehicleShowroom.Data;

#nullable disable

namespace VehicleShowroom.Web.Data.Migrations
{
    [DbContext(typeof(VehicleDbContext))]
    [Migration("20241114190445_ChageVehicleConfiguration")]
    partial class ChageVehicleConfiguration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("VehicleShowroom.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("VehicleShowroom.Data.Models.Bus", b =>
                {
                    b.Property<int>("BusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("HorsePower")
                        .HasColumnType("int");

                    b.Property<string>("Transmission")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("BusId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Buses");

                    b.HasData(
                        new
                        {
                            BusId = 1,
                            Capacity = 66,
                            Description = "Volvo 9700 DD is an extremely flexible double decker that offers impressive capacity and possibilities for different kinds of operations.",
                            HorsePower = 445,
                            Transmission = "Automatic",
                            VehicleId = 4
                        });
                });

            modelBuilder.Entity("VehicleShowroom.Data.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("HorsePower")
                        .HasColumnType("int");

                    b.Property<int>("Kilometers")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfDoors")
                        .HasColumnType("int");

                    b.Property<string>("Transmission")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            CarId = 1,
                            Description = "Fast and comfort",
                            HorsePower = 245,
                            Kilometers = 150000,
                            NumberOfDoors = 4,
                            Transmission = "Automatic",
                            VehicleId = 1
                        },
                        new
                        {
                            CarId = 2,
                            Description = "Lazy car",
                            HorsePower = 224,
                            Kilometers = 300000,
                            NumberOfDoors = 4,
                            Transmission = "Automatic",
                            VehicleId = 2
                        },
                        new
                        {
                            CarId = 3,
                            Description = "Luxury car",
                            HorsePower = 356,
                            Kilometers = 22200,
                            NumberOfDoors = 4,
                            Transmission = "Automatic",
                            VehicleId = 3
                        });
                });

            modelBuilder.Entity("VehicleShowroom.Data.Models.Motorcycle", b =>
                {
                    b.Property<int>("MotorcycleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MotorcycleId"));

                    b.Property<int>("Kw")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("MotorcycleId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Motorcycles");

                    b.HasData(
                        new
                        {
                            MotorcycleId = 1,
                            Kw = 45,
                            VehicleId = 5
                        });
                });

            modelBuilder.Entity("VehicleShowroom.Data.Models.SuperCar", b =>
                {
                    b.Property<int>("SuperCarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SuperCarId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("HorsePower")
                        .HasColumnType("int");

                    b.Property<int>("Kilometers")
                        .HasColumnType("int");

                    b.Property<string>("MaxSpeed")
                        .IsRequired()
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<int>("NumberOfDoors")
                        .HasColumnType("int");

                    b.Property<string>("Transmission")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasMaxLength(1700)
                        .HasColumnType("nvarchar(1700)");

                    b.HasKey("SuperCarId");

                    b.HasIndex("VehicleId");

                    b.ToTable("SuperCars");

                    b.HasData(
                        new
                        {
                            SuperCarId = 1,
                            Description = "The F8 Tributo uses the same engine from the 488 Pista, a 3.9 L twin-turbocharged V8 engine with a power output of 720 PS (530 kW; 710 hp) at 8000 rpm and 770 N⋅m (568 lb⋅ft) of torque at 3250 rpm",
                            HorsePower = 710,
                            Kilometers = 8500,
                            MaxSpeed = "350",
                            NumberOfDoors = 2,
                            Transmission = "Dual-Clutch Automatic",
                            VehicleId = 7,
                            Weight = "1400"
                        },
                        new
                        {
                            SuperCarId = 2,
                            Description = "The Pagani Huayra is a masterpiece of automotive engineering, renowned for its breathtaking design and performance. With an aerodynamic, lightweight body crafted from carbon-titanium, it achieves exceptional speed and agility. The Huayra’s performance is complemented by luxurious Italian craftsmanship and cutting-edge technology, making it a unique blend of art and science on wheels.",
                            HorsePower = 791,
                            Kilometers = 1500,
                            MaxSpeed = "383",
                            NumberOfDoors = 2,
                            Transmission = "7-Speed Sequential Manual",
                            VehicleId = 8,
                            Weight = "1350"
                        },
                        new
                        {
                            SuperCarId = 3,
                            Description = "The Lamborghini Aventador is an iconic supercar that combines Lamborghini's signature aggressive design with world-class performance. Equipped with a naturally aspirated V12 engine, it delivers a raw and thrilling driving experience. The Aventador is known for its sharp lines, scissor doors, and a commanding presence, making it a favorite among supercar enthusiasts.",
                            HorsePower = 769,
                            Kilometers = 3200,
                            MaxSpeed = "355",
                            NumberOfDoors = 2,
                            Transmission = "7-Speed Automated Manual (ISR)",
                            VehicleId = 9,
                            Weight = "1575"
                        });
                });

            modelBuilder.Entity("VehicleShowroom.Data.Models.Truck", b =>
                {
                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.Property<int>("CargoCapacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("EuroNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("HorsePower")
                        .HasColumnType("int");

                    b.Property<string>("Transmission")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TruckId")
                        .HasColumnType("int");

                    b.HasKey("VehicleId");

                    b.ToTable("Trucks");

                    b.HasData(
                        new
                        {
                            VehicleId = 6,
                            CargoCapacity = 12000,
                            Description = "Best truck",
                            EuroNumber = "Euro 6",
                            HorsePower = 650,
                            Transmission = "Automatic",
                            TruckId = 1
                        });
                });

            modelBuilder.Entity("VehicleShowroom.Data.Models.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleId"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("VehicleType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Year")
                        .HasColumnType("datetime2");

                    b.HasKey("VehicleId");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            VehicleId = 1,
                            Color = "White",
                            FuelType = "Diesel",
                            ImageUrl = "https://d3ok64umd5ysj.cloudfront.net/dev/assets/images/gallery/alpine-white-e91-bmw-335i-wagon-estate-forgestar-f14-bagged-stance-c.jpg",
                            IsDelete = false,
                            Make = "BMW",
                            Model = "330D E91",
                            Price = 21500m,
                            VehicleType = "Car",
                            Year = new DateTime(2012, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            VehicleId = 2,
                            Color = "Black",
                            FuelType = "Diesel",
                            ImageUrl = "https://garrybase.com/images/full/uploads/2021/AWEsL34IiTvPxXp2k8M7JcCdJrsZKJEiqimwpWpi.jpg",
                            IsDelete = false,
                            Make = "Merces",
                            Model = "e-clas E320CDI",
                            Price = 22500m,
                            VehicleType = "Car",
                            Year = new DateTime(2006, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            VehicleId = 3,
                            Color = "White",
                            FuelType = "Petrol",
                            ImageUrl = "https://frankfurt.apollo.olxcdn.com/v1/files/r8lz4w93so09-BG/image",
                            IsDelete = false,
                            Make = "AUDI",
                            Model = "A8 Long",
                            Price = 150000m,
                            VehicleType = "Car",
                            Year = new DateTime(2022, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            VehicleId = 4,
                            Color = "Brown",
                            FuelType = "Diesel",
                            ImageUrl = "https://www.lectura-specs.bg/models/renamed/detail_max_retina/avtobusi-za-turisticeski-avtobusi-9700-dd-volvo-buses.jpg",
                            IsDelete = false,
                            Make = "Volvo",
                            Model = "9900 DD",
                            Price = 198222m,
                            VehicleType = "Bus",
                            Year = new DateTime(2022, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            VehicleId = 5,
                            Color = "red",
                            FuelType = "Petrol",
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRTUkEaOz8kEyPTk3ansNtGsVrlm4zR0PBuMQ&s",
                            IsDelete = false,
                            Make = "Honda",
                            Model = "450",
                            Price = 19800m,
                            VehicleType = "Motorcycle",
                            Year = new DateTime(2022, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            VehicleId = 6,
                            Color = "Orange",
                            FuelType = "Diesel",
                            ImageUrl = "https://www.hobbies.co.uk/media/catalog/product/cache/084ca19aa5ee10728706fd297654f270/1/5/156325man_1.jpg",
                            IsDelete = false,
                            Make = "Man",
                            Model = "TGC",
                            Price = 198000m,
                            VehicleType = "Truck",
                            Year = new DateTime(2016, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            VehicleId = 7,
                            Color = "Crimson Red",
                            FuelType = "Petrol",
                            ImageUrl = "https://ferrari-cdn.thron.com/delivery/public/thumbnail/ferrari/e9677798-7b8b-42b1-becf-387235c70b2a/bocxuw/std/488x325/e9677798-7b8b-42b1-becf-387235c70b2a?scalemode=auto",
                            IsDelete = false,
                            Make = "Ferrari",
                            Model = "F8",
                            Price = 450000m,
                            VehicleType = "Supercar",
                            Year = new DateTime(2022, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            VehicleId = 8,
                            Color = "Carbon Fiber Black",
                            FuelType = "Petrol",
                            ImageUrl = "https://assets.newatlas.com/dims4/default/7afc3de/2147483647/strip/true/crop/1024x576+0+47/resize/1200x675!/quality/90/?url=http%3A%2F%2Fnewatlas-brightspot.s3.amazonaws.com%2Farchive%2Fpagani-huayra-supercar.jpg",
                            IsDelete = false,
                            Make = "Pagani",
                            Model = "Huayra",
                            Price = 3400000m,
                            VehicleType = "Supercar",
                            Year = new DateTime(2022, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            VehicleId = 9,
                            Color = "Lamborghini Yellow",
                            FuelType = "Petrol",
                            ImageUrl = "https://www.exoticcarhacks.com/wp-content/uploads/2024/02/uFcbfiuL-scaled.jpeg",
                            IsDelete = false,
                            Make = "Lamborghini",
                            Model = "Aventador",
                            Price = 550000m,
                            VehicleType = "Supercar",
                            Year = new DateTime(2023, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("VehicleShowroom.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("VehicleShowroom.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VehicleShowroom.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("VehicleShowroom.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VehicleShowroom.Data.Models.Bus", b =>
                {
                    b.HasOne("VehicleShowroom.Data.Models.Vehicle", "Vehicle")
                        .WithMany("Buses")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("VehicleShowroom.Data.Models.Car", b =>
                {
                    b.HasOne("VehicleShowroom.Data.Models.Vehicle", "Vehicle")
                        .WithMany("Cars")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("VehicleShowroom.Data.Models.Motorcycle", b =>
                {
                    b.HasOne("VehicleShowroom.Data.Models.Vehicle", "Vehicle")
                        .WithMany("Motorcycles")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("VehicleShowroom.Data.Models.SuperCar", b =>
                {
                    b.HasOne("VehicleShowroom.Data.Models.Vehicle", "Vehicle")
                        .WithMany("SuperCars")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("VehicleShowroom.Data.Models.Truck", b =>
                {
                    b.HasOne("VehicleShowroom.Data.Models.Vehicle", "Vehicle")
                        .WithMany("Trucks")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("VehicleShowroom.Data.Models.Vehicle", b =>
                {
                    b.Navigation("Buses");

                    b.Navigation("Cars");

                    b.Navigation("Motorcycles");

                    b.Navigation("SuperCars");

                    b.Navigation("Trucks");
                });
#pragma warning restore 612, 618
        }
    }
}
