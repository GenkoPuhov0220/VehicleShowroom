using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using VehicleShowroom.Data.Models;
using static VehicleShowroom.Common.EntityValidationConstants;
namespace VehicleShowroom.Data.Configuration
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(v => v.VehicleId);

            builder
                 .HasMany(v => v.Cars)
                 .WithOne(c => c.Vehicle)
                 .HasForeignKey(c => c.VehicleId)
                 .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(v => v.Buses)
                .WithOne(b => b.Vehicle)
                .HasForeignKey(b => b.VehicleId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasMany(v => v.Trucks)
                .WithOne(t => t.Vehicle)
                .HasForeignKey(t => t.VehicleId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasMany(v => v.Motorcycles)
                .WithOne(m => m.Vehicle)
                .HasForeignKey(m => m.VehicleId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasMany(v => v.SuperCars)
                .WithOne(m => m.Vehicle)
                .HasForeignKey(m => m.VehicleId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .Property(v => v.IsDelete)
                .HasDefaultValue(false);

            builder
                .Property(v => v.Price)
                .HasColumnType("decimal(18,2)");

            builder
                .Property(v => v.VehicleType)
                .IsRequired()
                .HasMaxLength(VehicleTypeMaxLenght);

            builder
                .Property(v => v.Make)
                .IsRequired()
                .HasMaxLength(MakeMaxLenght);

            builder
                .Property(v => v.Model)
                .IsRequired()
                .HasMaxLength(ModelMaxLenght);

            builder
                .Property(v => v.Color)
                .IsRequired()
                .HasMaxLength(ColorMaxLenght);

            builder
                .Property(v => v.FuelType)
                .IsRequired()
                .HasMaxLength(FuelTypeMaxLenght);
            builder
               .Property(b => b.ImageUrl)
               .IsRequired();
            builder
              .Property(b => b.Year)
              .IsRequired();

            builder
                .HasData(this.SeedVehicle());

        }
        private List<Vehicle> SeedVehicle()
        {
            List<Vehicle> vehicles = new List<Vehicle>()
            {
                 new Vehicle
                 {
                     VehicleId = 1,
                     VehicleType = "Car",
                     Make = "BMW",
                     Model = "330D E91",
                     Year = new DateTime(2012, 08, 12),
                     Price = 21500,
                     Color = "White",
                     FuelType = "Diesel",
                     ImageUrl = "https://d3ok64umd5ysj.cloudfront.net/dev/assets/images/gallery/alpine-white-e91-bmw-335i-wagon-estate-forgestar-f14-bagged-stance-c.jpg"
                 },
                 new Vehicle
                 {
                     VehicleId = 2,
                     VehicleType = "Car",
                     Make = "Merces",
                     Model = "e-clas E320CDI",
                     Year = new DateTime(2006, 08, 08),
                     Price = 22500,
                     Color = "Black",
                     FuelType = "Diesel",
                     ImageUrl = "https://garrybase.com/images/full/uploads/2021/AWEsL34IiTvPxXp2k8M7JcCdJrsZKJEiqimwpWpi.jpg"
                 },
                 new Vehicle
                 {
                     VehicleId = 3,
                     VehicleType = "Car",
                     Make = "AUDI",
                     Model = "A8 Long",
                     Year = new DateTime(2022, 10, 15),
                     Price = 150000,
                     Color = "White",
                     FuelType = "Petrol",
                     ImageUrl = "https://frankfurt.apollo.olxcdn.com/v1/files/r8lz4w93so09-BG/image"

                 },
                  new Vehicle
                 {
                     VehicleId = 4,
                     VehicleType = "Bus",
                     Make = "Volvo",
                     Model = "9900 DD",
                     Year = new DateTime(2022, 9, 10),
                     Price = 198222,
                     Color = "Brown",
                     FuelType = "Diesel",
                     ImageUrl = "https://www.lectura-specs.bg/models/renamed/detail_max_retina/avtobusi-za-turisticeski-avtobusi-9700-dd-volvo-buses.jpg"
                 },
                  new Vehicle
                  {
                     VehicleId = 5,
                     VehicleType = "Motorcycle",
                     Make = "Honda",
                     Model = "450",
                     Year = new DateTime(2022, 9, 10),
                     Price = 19800,
                     Color = "red",
                     FuelType = "Petrol",
                      ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRTUkEaOz8kEyPTk3ansNtGsVrlm4zR0PBuMQ&s"
                  },
                  new Vehicle
                  {
                     VehicleId = 6,
                     VehicleType = "Truck",
                     Make = "Man",
                     Model = "TGC",
                     Year = new DateTime(2016, 9, 11),
                     Price = 198000,
                     Color = "Orange",
                     FuelType = "Diesel",
                     ImageUrl = "https://www.hobbies.co.uk/media/catalog/product/cache/084ca19aa5ee10728706fd297654f270/1/5/156325man_1.jpg"
                  },
                  new Vehicle
                  {
                     VehicleId = 7,
                     VehicleType = "Supercar",
                     Make = "Ferrari",
                     Model = "F8",
                     Year = new DateTime(2022, 9, 11),
                     Price= 450000,
                     Color = "Crimson Red",
                     FuelType = "Petrol",
                     ImageUrl = "https://ferrari-cdn.thron.com/delivery/public/thumbnail/ferrari/e9677798-7b8b-42b1-becf-387235c70b2a/bocxuw/std/488x325/e9677798-7b8b-42b1-becf-387235c70b2a?scalemode=auto"
                  },
                  new Vehicle
                  {
                     VehicleId= 8,
                     VehicleType ="Supercar",
                     Make = "Pagani",
                     Model = "Huayra",
                     Year = new DateTime(2022, 01, 09),
                     Price = 3400000,
                     Color ="Carbon Fiber Black",
                     FuelType = "Petrol",
                     ImageUrl= "https://assets.newatlas.com/dims4/default/7afc3de/2147483647/strip/true/crop/1024x576+0+47/resize/1200x675!/quality/90/?url=http%3A%2F%2Fnewatlas-brightspot.s3.amazonaws.com%2Farchive%2Fpagani-huayra-supercar.jpg"
                  },
                  new Vehicle
                  {
                      VehicleId = 9,
                      VehicleType= "Supercar",
                      Make= "Lamborghini",
                      Model= "Aventador",
                      Year = new DateTime(2023, 10, 09),
                      Price =550000,
                      Color = "Lamborghini Yellow",
                      FuelType = "Petrol",
                      ImageUrl = "https://www.exoticcarhacks.com/wp-content/uploads/2024/02/uFcbfiuL-scaled.jpeg"
                  },
                  new Vehicle
                  {
                      VehicleId = 10,
                      VehicleType = "Car",
                      Make = "Ford",
                      Model = "F-150",
                      Year = new DateTime(2018, 05, 20),
                      Price = 35000,
                      Color = "Black",
                      FuelType = "Gasoline",
                      ImageUrl = "https://di-uploads-pod39.dealerinspire.com/portorchardford/uploads/2016/12/18-f150.jpg"
                  },
                  new Vehicle
                  {
                      VehicleId = 11,
                      VehicleType = "Car",
                      Make = "Toyota",
                      Model = "RAV4",
                      Year = new DateTime(2020, 11, 10),
                      Price = 30000,
                      Color = "Blue",
                      FuelType = "Hybrid",
                      ImageUrl = "https://www.seegertoyota.com/static/dealer-12152/2020_Rav4_US_XLE-FWD_08W9_002.png"
                  },
                  new Vehicle
                  {
                      VehicleId = 12,
                      VehicleType = "Car",
                      Make = "Tesla",
                      Model = "Model S",
                      Year = new DateTime(2022, 03, 25),
                      Price = 79999,
                      Color = "Red",
                      FuelType = "Electric",
                      ImageUrl = "https://ev-database.org/img/auto/Tesla_Model_S_2016/Tesla_Model_S_2016-01@2x.jpg"
                  },
                  new Vehicle
                  {
                      VehicleId = 13,
                      VehicleType = "Car",
                      Make = "Audi",
                      Model = "A6",
                      Year = new DateTime(2017, 09, 30),
                      Price = 32000,
                      Color = "Grey",
                      FuelType = "Diesel",
                      ImageUrl = "https://images.clickdealer.co.uk/vehicles/5833/5833074/large1/136953099.jpg"
                  },
                  new Vehicle
                  {
                     VehicleId = 14,
                     VehicleType = "Car",
                     Make = "Jeep",
                     Model = "Wrangler",
                     Year = new DateTime(2023, 01, 15),
                     Price = 42000,
                     Color = "Green",
                     FuelType = "Gasoline",
                     ImageUrl = "https://example.com/jeep-wrangler.jpg"
                  },
                  new Vehicle
                  {
                     VehicleId = 15,
                     VehicleType = "Car",
                     Make = "Honda",
                     Model = "Civic",
                     Year = new DateTime(2019, 04, 10),
                     Price = 20000,
                     Color = "Blue",
                     FuelType = "Gasoline",
                     ImageUrl = "https://media.ed.edmunds-media.com/honda/civic/2019/oem/2019_honda_civic_sedan_si_fq_oem_1_1600.jpg"
                  },
                  new Vehicle
                  {
                     VehicleId = 16,
                     VehicleType = "Car",
                     Make = "Ford",
                     Model = "Mustang",
                     Year = new DateTime(2021, 07, 22),
                     Price = 55000,
                     Color = "Yellow",
                     FuelType = "Gasoline",
                     ImageUrl = "https://i.redd.it/lp5hnu6nyui51.jpg"
                  },
                  new Vehicle
                  {
                     VehicleId = 17,
                     VehicleType = "Car",
                     Make = "Chevrolet",
                     Model = "Camaro",
                     Year = new DateTime(2020, 10, 05),
                     Price = 62000,
                     Color = "Orange",
                     FuelType = "Gasoline",
                     ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT1G0QIvzNfjUC6aBI2TBa1SJsAMs9SSCDsJA&s"
                  },
                  new Vehicle
                  {
                     VehicleId = 18,
                     VehicleType = "Car",
                     Make = "Hyundai",
                     Model = "Elantra",
                     Year = new DateTime(2022, 01, 12),
                     Price = 22000,
                     Color = "White",
                     FuelType = "Gasoline",
                     ImageUrl = "https://www.earnhardthyundai.com/blogs/4378/wp-content/uploads/2021/08/What-Are-the-2022-Hyundai-Elantra-N-Performance-Specs_o.jpg"
                  },
                  new Vehicle
                  {
                     VehicleId = 19,
                     VehicleType = "Car",
                     Make = "Mazda",
                     Model = "Mazda3",
                     Year = new DateTime(2021, 06, 08),
                     Price = 23000,
                     Color = "Red",
                     FuelType = "Gasoline",
                     ImageUrl = "https://www.carscoops.com/wp-content/uploads/2019/11/2020-Mazda3.jpg"
                  },
                  new Vehicle
                  {
                     VehicleId = 20,
                     VehicleType = "Supercar",
                     Make = "Lamborghini",
                     Model = "Huracán EVO",
                     Year = new DateTime(2023, 4, 15),
                     Price = 260000,
                     Color = "Verde Mantis",
                     FuelType = "Petrol",
                     ImageUrl = "https://www.ilusso.com/imagetag/3092/main/l/Used-2023-Lamborghini-Huracan-EVO-Spyder-1712261384.jpg"
                  },
                  new Vehicle
                  {
                     VehicleId = 21,
                     VehicleType = "Supercar",
                     Make = "Bugatti",
                     Model = "Chiron",
                     Year = new DateTime(2021, 12, 25),
                     Price = 3000000,
                     Color = "Blue/Black",
                     FuelType = "Petrol",
                     ImageUrl = "https://news.dupontregistry.com/wp-content/uploads/2023/08/download---2023-07-26t155244.828-scaled.jpg"
                  },
                  new Vehicle
                  {
                     VehicleId = 22,
                     VehicleType = "Supercar",
                     Make = "McLaren",
                     Model = "720S",
                     Year = new DateTime(2022, 6, 18),
                     Price = 310000,
                     Color = "Aurora Blue",
                     FuelType = "Petrol",
                     ImageUrl = "https://www.alastairbols.com/wp-content/uploads/2020/03/McLaren-720S-Performance-Aurora-Blue-for-sale-18-of-33.jpg"
                  },
                  new Vehicle
                  {
                     VehicleId = 23,
                     VehicleType = "Supercar",
                     Make = "Porsche",
                     Model = "911 Turbo S",
                     Year = new DateTime(2023, 1, 5),
                     Price = 230000,
                     Color = "Jet Black Metallic",
                     FuelType = "Petrol",
                     ImageUrl = "https://vehicle-images.dealerinspire.com/8b2a-210007648/WP0AD2A99PS259634/450d491619af6ccbc6f3ad2e0f1a647e.jpg"
                  },
                  new Vehicle
                  {
                     VehicleId = 24,
                     VehicleType = "Supercar",
                     Make = "Aston Martin",
                     Model = "Valkyrie",
                     Year = new DateTime(2023, 2, 12),
                     Price = 3000000,
                     Color = "British Racing Green",
                     FuelType = "Hybrid",
                     ImageUrl = "https://www.astonmartin.com/-/media/aston-martin/images/default-source/models/valkyrie/valkyrie-retouched-nov21.jpg?mw=1920&rev=1e80dbb7953e4852bce3dfc43db4f69a&hash=2C97098139E6221C651689CFD85A296E"
                  },
                  new Vehicle
                  {
                     VehicleId = 25,
                     VehicleType = "Supercar",
                     Make = "Koenigsegg",
                     Model = "Jesko Absolut",
                     Year = new DateTime(2022, 8, 22),
                     Price = 3500000,
                     Color = "Gunpowder Grey",
                     FuelType = "Petrol",
                     ImageUrl = "https://imodels.com.pl/wp-content/uploads/2023/11/9207180cb86955e787bd27e64fe07933-scaled.jpg"
                  },
                  new Vehicle
                  {
                     VehicleId = 26,
                     VehicleType = "Motorcycle",
                     Make = "Yamaha",
                     Model = "MT-07",
                     Year = new DateTime(2023, 1, 15),
                     Price = 7800,
                     Color = "Blue",
                     FuelType = "Petrol",
                     ImageUrl = "https://cdn.dealerspike.com/imglib/v1/800x600/imglib/Assets/Inventory/94/0D/940D9D71-4E7E-4D5B-8D0A-6453F832FCED.jpg"
                  },
                  new Vehicle
                  {
                     VehicleId = 27,
                     VehicleType = "Motorcycle",
                     Make = "Kawasaki",
                     Model = "Ninja ZX-10R",
                     Year = new DateTime(2021, 5, 20),
                     Price = 15000,
                     Color = "Green",
                     FuelType = "Petrol",
                     ImageUrl = "https://imotorbike-wp-media.s3.ap-southeast-1.amazonaws.com/2020/11/2021-Kawasaki-Ninja-ZX-10RR-2-1-1000x600.jpg"
                  },
                  new Vehicle
                  {
                     VehicleId = 28,
                     VehicleType = "Motorcycle",
                     Make = "Suzuki",
                     Model = "GSX-R750",
                     Year = new DateTime(2022, 3, 10),
                     Price = 12500,
                     Color = "Red",
                     FuelType = "Petrol",
                     ImageUrl = "https://suzukicycles.com/-/media/project/cycles/images/products/motorcycles/gsx-r750/2022/promo/2022_gsx-r750_header_2500x1227.jpg?mw=2560&w=2560&hash=4F73518A00243A0350150515346531DA"
                  },
                  new Vehicle
                  {
                     VehicleId = 29,
                     VehicleType = "Motorcycle",
                     Make = "Ducati",
                     Model = "Panigale V2",
                     Year = new DateTime(2023, 7, 5),
                     Price = 18000,
                     Color = "White",
                     FuelType = "Petrol",
                     ImageUrl = "https://images.ctfassets.net/o6sr41tx16eu/7M52Hm6hoBznVK87muKiTM/646a09e80cd8dbd7c6b60a4228a46d10/DUCATI_PANIGALE_V2__2__UC173828_High_1920x960.jpg"
                  },
                  new Vehicle
                  {
                     VehicleId = 30,
                     VehicleType = "Motorcycle",
                     Make = "BMW",
                     Model = "S1000RR",
                     Year = new DateTime(2021, 11, 18),
                     Price = 19000,
                     Color = "Black",
                     FuelType = "Petrol",
                     ImageUrl = "https://img.gta5-mods.com/q95/images/bmw-s1000rr-2021-black-livery/eb828f-bmws1000rr1-compressed.jpg"
                  },
                  new Vehicle
                  {
                     VehicleId = 31,
                     VehicleType = "Motorcycle",
                     Make = "Harley-Davidson",
                     Model = "Sportster S",
                     Year = new DateTime(2022, 8, 12),
                     Price = 15000,
                     Color = "Orange",
                     FuelType = "Petrol",
                     ImageUrl = "https://ricks-motorcycles.com/wp-content/uploads/2021/11/Harley-Davidson-Sportster-S-Ricks-Custombike-002.jpg"
                  },
                  new Vehicle
                  {
                     VehicleId = 32,
                     VehicleType = "Motorcycle",
                     Make = "Triumph",
                     Model = "Street Triple",
                     Year = new DateTime(2023, 4, 22),
                     Price = 12000,
                     Color = "Silver",
                     FuelType = "Petrol",
                     ImageUrl = "https://cdn.dealerwebs.co.uk/uploads/images/triumph/2023/street-triple-765-r/street-triple-r-f-2.jpg"
                  },
                  new Vehicle
                  {
                     VehicleId = 33,
                     VehicleType = "Motorcycle",
                     Make = "KTM",
                     Model = "Duke 890",
                     Year = new DateTime(2022, 6, 30),
                     Price = 11000,
                     Color = "Orange",
                     FuelType = "Petrol",
                     ImageUrl = "https://press.ktm.com/Content/598149/26736ab1-8a7c-450c-8339-26e87cad5364/1200/2400/.jpg"
                  },
                  new Vehicle
                  {
                     VehicleId = 34,
                     VehicleType = "Motorcycle",
                     Make = "Honda",
                     Model = "CBR600RR",
                     Year = new DateTime(2021, 9, 15),
                     Price = 14000,
                     Color = "Red",
                     FuelType = "Petrol",
                     ImageUrl = "https://riders.drivemag.com/wp-content/uploads/2020/08/2021-Honda-CBR600RR-production-form-01.jpg"
                  },
                  new Vehicle
                  {
                     VehicleId = 35,
                     VehicleType = "Motorcycle",
                     Make = "Aprilia",
                     Model = "RS 660",
                     Year = new DateTime(2023, 2, 10),
                     Price = 13500,
                     Color = "Blue",
                     FuelType = "Petrol",
                     ImageUrl = "https://www.philharmonicmoto.com/wp-content/uploads/2024/11/01-Aprilia_RS-660_Blue-Marlin-600x450.jpg"
                  },
                  new Vehicle
                  {
                     VehicleId = 36,
                     VehicleType = "Bus",
                     Make = "Volvo",
                     Model = "9900 DD",
                     Year = new DateTime(2022, 9, 10),
                     Price = 198222,
                     Color = "Brown",
                     FuelType = "Diesel",
                     ImageUrl = "https://www.volvobuses.com/content/dam/volvo-buses/markets/master/coaches/complete-coaches/volvo-9900/2326x800-volvo-9900-CGI.jpg"
                  },
                  new Vehicle
                  {
                      VehicleId = 37,
                      VehicleType = "Bus",
                      Make = "Mercedes-Benz",
                      Model = "Tourismo",
                      Year = new DateTime(2021, 6, 12),
                      Price = 210000,
                      Color = "White",
                      FuelType = "Diesel",
                      ImageUrl = "https://www.route-one.net/wp-content/uploads/2021/07/MB-Tourismo-Access-test-drive-1.jpg"
                  },
                  new Vehicle
                  {
                        VehicleId = 38,
                        VehicleType = "Bus",
                        Make = "Scania",
                        Model = "Interlink HD",
                        Year = new DateTime(2023, 5, 20),
                        Price = 195000,
                        Color = "Blue",
                        FuelType = "Diesel",
                        ImageUrl = "https://apecauto.com/images/seo/model/scania/interlink.png"
                    },
                  new Vehicle
                    {
                        VehicleId = 39,
                        VehicleType = "Bus",
                        Make = "MAN",
                        Model = "Lion's Coach",
                        Year = new DateTime(2022, 3, 25),
                        Price = 205000,
                        Color = "Silver",
                        FuelType = "Diesel",
                        ImageUrl = "https://man.com.ge/storage/213/conversions/man-bus-lions-coach-technical-data-stage-16-9_width_800_height_450-webp.webp"
                    },
                  new Vehicle
                    {
                        VehicleId = 40,
                        VehicleType = "Bus",
                        Make = "Iveco",
                        Model = "Crossway",
                        Year = new DateTime(2021, 7, 15),
                        Price = 175000,
                        Color = "Yellow",
                        FuelType = "Diesel",
                        ImageUrl = "https://www.truck1.eu/img/auto/fullview/9831/9831_8025162586282.jpg"
                    },
                  new Vehicle
                  {
                     VehicleId = 41,
                     VehicleType = "Bus",
                     Make = "Setra",
                     Model = "S 531 DT",
                     Year = new DateTime(2023, 9, 10),
                     Price = 220000,
                     Color = "Red",
                     FuelType = "Diesel",
                     ImageUrl = "https://p.turbosquid.com/ts-thumb/xu/9lCBc6/qWUpWEQM/setra_s_531_dt_tourist_bus_0006_02_2560x1440/jpg/1557836774/1920x1080/fit_q87/a84af1ae08057a519cbe2f1bce71f7ea2523dafa/setra_s_531_dt_tourist_bus_0006_02_2560x1440.jpg"
                  },
                  new Vehicle
                  {
                     VehicleId = 42,
                     VehicleType = "Truck",
                     Make = "Volvo",
                     Model = "FH16",
                     Year = new DateTime(2018, 5, 14),
                     Price = 220000,
                     Color = "White",
                     FuelType = "Diesel",
                     ImageUrl = "https://cdn.truckscout24.com/data/listing/img/hdv/ts/18/68/17618278-01.jpg?v=1730896061"
                  },
                  new Vehicle
                  {
                        VehicleId = 43,
                        VehicleType = "Truck",
                        Make = "Scania",
                        Model = "R500",
                        Year = new DateTime(2019, 3, 19),
                        Price = 210000,
                        Color = "Blue",
                        FuelType = "Diesel",
                        ImageUrl = "https://img.youtube.com/vi/BMjpiXe9MEY/sddefault.jpg"
                  },
                  new Vehicle
                  {
                        VehicleId = 44,
                        VehicleType = "Truck",
                        Make = "Mercedes",
                        Model = "Actros",
                        Year = new DateTime(2020, 7, 22),
                        Price = 230000,
                        Color = "Silver",
                        FuelType = "Diesel",
                        ImageUrl = "https://www.modelsnavigator.com/buxus/images/fotogaleria/modelsnavigator.com/katalog_produktov/modely_uzitkovych_vozidiel/modely_kamionov/mercedes-benz_actros_mp4_strieborna_farba/TR124.22.jpg"
                  },
                    new Vehicle
                    {
                        VehicleId = 45,
                        VehicleType = "Truck",
                        Make = "DAF",
                        Model = "XF",
                        Year = new DateTime(2021, 1, 15),
                        Price = 240000,
                        Color = "Red",
                        FuelType = "Diesel",
                        ImageUrl = "https://www.truckpages.co.uk/wp-content/uploads/2024/08/29/1a0034d8d5.jpg.webp"
                    },
                    new Vehicle
                    {
                        VehicleId = 46,
                        VehicleType = "Truck",
                        Make = "Iveco",
                        Model = "S-Way",
                        Year = new DateTime(2022, 6, 10),
                        Price = 250000,
                        Color = "Black",
                        FuelType = "Diesel",
                        ImageUrl = "https://cdn.webshopapp.com/shops/76444/files/418915046/650x650x2/solarguard-onderspoiler-iveco-s-way.jpg"
                    },
                    new Vehicle
                    {
                        VehicleId = 47,
                        VehicleType = "Truck",
                        Make = "Kenworth",
                        Model = "T680",
                        Year = new DateTime(2017, 4, 18),
                        Price = 200000,
                        Color = "Green",
                        FuelType = "Diesel",
                        ImageUrl = "https://d29qvoplt93a6w.cloudfront.net/efs/wp/domains/www.exceltruckgroup.com/wp-content/uploads/2022/11/1667569543479.jpg"
                    },
                    new Vehicle
                    {
                        VehicleId = 48,
                        VehicleType = "Truck",
                        Make = "Peterbilt",
                        Model = "579",
                        Year = new DateTime(2018, 2, 20),
                        Price = 205000,
                        Color = "Yellow",
                        FuelType = "Diesel",
                        ImageUrl = "https://static.truckmarket.com/wp-content/uploads/trucks/129413/2018-peterbilt-579-daycab-472914-23.jpg"
                    },
                    new Vehicle
                    {
                        VehicleId = 49,
                        VehicleType = "Truck",
                        Make = "Mack",
                        Model = "Anthem",
                        Year = new DateTime(2019, 11, 25),
                        Price = 215000,
                        Color = "Brown",
                        FuelType = "Diesel",
                        ImageUrl = "https://www.macktrucks.com/mack-news/2019/media_13ab286fb6f1e4155c5f435b46c86e439cd34075f.png?width=1200&format=pjpg&optimize=medium"
                    },
                    new Vehicle
                    {
                        VehicleId = 50,
                        VehicleType = "Truck",
                        Make = "Freightliner",
                        Model = "Cascadia",
                        Year = new DateTime(2020, 8, 30),
                        Price = 225000,
                        Color = "Purple",
                        FuelType = "Diesel",
                        ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQLN308QJPQH7M4ymPQ2SCWu8MFjnAIAwI_Aw&s"
                    }

            };

            return vehicles;
        }
    }
}
