namespace AspFinalProje.Migrations
{
    using AspFinalProje.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AspFinalProje.DATA.AspFinalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AspFinalProje.DATA.AspFinalContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Cities.AddOrUpdate(m => m.CityName, new City[] {
                new City { CityName = "Baki"},
                new City { CityName = "Bilesuvar" },
                new City { CityName = "Masalli" },
                new City { CityName = "Sumqayit" },
                new City { CityName = "Shamaxi" },
                new City { CityName = "Shemkir" },
                new City { CityName = "Astara" },
                new City { CityName = "Lenkeran" },
                new City { CityName = "Gence" },
                new City { CityName = "Goychay" },
                new City { CityName = "Salyan" }
            });
            context.SaveChanges();

            context.adminSettings.AddOrUpdate(m => m.Email, new AdminSetting[] 
            {
                new AdminSetting{ Email = "admin@code.az", Firstname="Afiq" , Lastname = "Mehdizade", Password = "AAq2pQz50fN+/oak9cfQMV9YQuF/DdB98eOZ0SeIxdOHhvVHawH6ceaN71vznAdNJg=="}
            });
            context.SaveChanges();
            

            context.Markas.AddOrUpdate(m => m.MarkaName, new Marka[] {
                new Marka{ MarkaName = "BMW"},
                new Marka{ MarkaName = "Mercedes"},
                new Marka{ MarkaName = "Kia"},
                new Marka{ MarkaName = "Aston-Martin"},
                new Marka{ MarkaName = "Vaz"},
                new Marka{ MarkaName = "Nissan"},
                new Marka{ MarkaName = "Honda"}
            });
            context.SaveChanges();

            context.Models.AddOrUpdate(m => m.ModelName, new Model[] {
                new Model{ MarkaId=1, ModelName="X5"},
                new Model{ MarkaId=1, ModelName="X6"},
                new Model{ MarkaId=1, ModelName="M5"},
                new Model{ MarkaId=1, ModelName="345"},
                new Model{ MarkaId=1, ModelName="525"},
                new Model{ MarkaId=2, ModelName="C200"},
                new Model{ MarkaId=2, ModelName="ML350"},
                new Model{ MarkaId=2, ModelName="GALENVAGEN"},
                new Model{ MarkaId=2, ModelName="AMG-GT"},
                new Model{ MarkaId=2, ModelName="BENZ-C"},
                new Model{ MarkaId=2, ModelName="CLA"},
                new Model{ MarkaId=3, ModelName="RIO"},
                new Model{ MarkaId=3, ModelName="OPTIMA"},
                new Model{ MarkaId=3, ModelName="SPORTAGE"},
                new Model{ MarkaId=3, ModelName="FORTE"},
                new Model{ MarkaId=3, ModelName="PICANTO"},
                new Model{ MarkaId=4, ModelName="VANQUISH"},
                new Model{ MarkaId=4, ModelName="DB11V8"},
                new Model{ MarkaId=4, ModelName="VALKYRIE"},
                new Model{ MarkaId=4, ModelName="VANTAGE"},
                new Model{ MarkaId=5, ModelName="2107"},
                new Model{ MarkaId=5, ModelName="NIVA"},
                new Model{ MarkaId=5, ModelName="2106"},
                new Model{ MarkaId=5, ModelName="21011"},
                new Model{ MarkaId=6, ModelName="NAVARA"},
                new Model{ MarkaId=6, ModelName="GT-R"},
                new Model{ MarkaId=6, ModelName="SENTRA"},
                new Model{ MarkaId=6, ModelName="TEANA"},
                new Model{ MarkaId=7, ModelName="CIVIC"},
                new Model{ MarkaId=7, ModelName="INSIGHT"},
                new Model{ MarkaId=7, ModelName="ACCORD"},
                new Model{ MarkaId=7, ModelName="PASSPORT"},
            });
            context.SaveChanges();

            context.Oils.AddOrUpdate(m => m.YanacaqAdi, new Oil[] {
                new Oil{ YanacaqAdi = "Benzin"},
                new Oil{ YanacaqAdi = "Qaz"},
                new Oil{ YanacaqAdi = "Disel"},
                new Oil{ YanacaqAdi = "Elektrik"},
            });
            context.SaveChanges();

            context.News.AddOrUpdate(m => new { m.Title, m.Content }, new New[] {
                new New{ Title="Lamborgini yeni avtomobilini teqdim etdi",
                    Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry." +
                    " Lorem Ipsum has been the industry's standard dummy text ever since the 1500s," +
                    " when an unknown printer took a galley of type and scrambled it to make a type " +
                    "specimen book.", CreatedAt=DateTime.Now, Image="news/lamborg.jpg"},
                new New{ Title="Honda yeni avtomobilini teqdim etdi",
                    Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry." +
                    " Lorem Ipsum has been the industry's standard dummy text ever since the 1500s," +
                    " when an unknown printer took a galley of type and scrambled it to make a type " +
                    "specimen book. ", CreatedAt=DateTime.Now.AddMinutes(39), Image="news/honda-xeber.jpg"},
                new New{ Title="Chevrolet yeni avtomobilini teqdim etdi",
                    Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry." +
                    " Lorem Ipsum has been the industry's standard dummy text ever since the 1500s," +
                    " when an unknown printer took a galley of type and scrambled it to make a type " +
                    "specimen book. ", CreatedAt=DateTime.Now.AddMinutes(10), Image="news/camaro.jpeg"}
            });
            context.SaveChanges();

            context.Users.AddOrUpdate(m => m.Email, new User[] {
                new User{ Email="samir@code.az", Firstname="Samir", Lastname="Dadash-zade",
                    Password ="AIfSYfwuMDhYoeuZfZ/oCG9+j+WcpcAStlQXL59xpdrZP1Irg1FFZ0wSywfOF8dHKQ==",
                    ConfirmPassword = "AIfSYfwuMDhYoeuZfZ/oCG9+j+WcpcAStlQXL59xpdrZP1Irg1FFZ0wSywfOF8dHKQ==",
                    Phone="+994515090515"
                },
                 new User{ Email="afig@code.az", Firstname="Afiq", Lastname="Mehdi-zade",
                    Password ="AM9tA2YPeRdjIdl8pgtitvGygRiNrqVPqVgvy6KECljM7nouytxExrhlWf/EwFlhcA==",
                    ConfirmPassword = "AM9tA2YPeRdjIdl8pgtitvGygRiNrqVPqVgvy6KECljM7nouytxExrhlWf/EwFlhcA==",
                    Phone="+994515090515"
                },
                  new User{ Email="emil@code.az", Firstname="Emil", Lastname="Aliyev",
                    Password ="ADer9lNOQP+nXuaCQ7B4LSMATdrrgFW46i85iW0RZeC5tNi4lkPOuEQpRDEwRI8nRw==",
                    ConfirmPassword = "ADer9lNOQP+nXuaCQ7B4LSMATdrrgFW46i85iW0RZeC5tNi4lkPOuEQpRDEwRI8nRw==",
                    Phone="+994515090515"
                }
            });
            context.SaveChanges();

            //context.Avtomobils.AddOrUpdate(new Avtomobil[] {
            //    new Avtomobil{ Color = "ag", ModelId=1, OilId=1, Price=35000, MadeYear="2018" EngineCapacity="180AG", KiloMetre=14300, Image = "cars/bmw-x5.jpg", Context="Mashin problemsizdir.Maraqlanmaq isteyen elaqe saxlaya biler.", TransMission=false},
            //    new Avtomobil{  Color = "Ag",ModelId=2, OilId=2, Price=45000, MadeYear="2018", EngineCapacity="190AG", KiloMetre=10300, Image = "cars/bmw-x6.jpg", Context="Mashin problemsizdir.Maraqlanmaq isteyen elaqe saxlaya biler.", TransMission=false},
            //    new Avtomobil{  Color = "Qirmizi", ModelId=2, OilId=2, Price=45000, MadeYear="2018", EngineCapacity="190AG", KiloMetre=10300, Image = "cars/bmw-x6.jpg", Context="Mashin problemsizdir.Maraqlanmaq isteyen elaqe saxlaya biler.", TransMission=false},
            //    new Avtomobil{  Color = "mavi", ModelId=4, OilId=2, Price=45000, MadeYear="2018", EngineCapacity="190AG", KiloMetre=10300, Image = "cars/bmw-x6.jpg", Context="Mashin problemsizdir.Maraqlanmaq isteyen elaqe saxlaya biler.", TransMission=false},
            //    new Avtomobil{  Color = "Agyasil", ModelId=6, OilId=2, Price=45000, MadeYear="2018", EngineCapacity="190AG", KiloMetre=10300, Image = "cars/bmw-x6.jpg", Context="Mashin problemsizdir.Maraqlanmaq isteyen elaqe saxlaya biler.", TransMission=false},
            //    new Avtomobil{  Color = "sari", ModelId=7, OilId=2, Price=45000, MadeYear="2018", EngineCapacity="190AG", KiloMetre=10300, Image = "cars/bmw-x6.jpg", Context="Mashin problemsizdir.Maraqlanmaq isteyen elaqe saxlaya biler.", TransMission=false},
            //    new Avtomobil{  Color = "Agyasil", ModelId=8, OilId=2, Price=45000, MadeYear="2018", EngineCapacity="190AG", KiloMetre=10300, Image = "cars/bmw-x6.jpg", Context="Mashin problemsizdir.Maraqlanmaq isteyen elaqe saxlaya biler.", TransMission=false},
            //    new Avtomobil{  Color = "mavi", ModelId=10, OilId=2, Price=45000, MadeYear="2018", EngineCapacity="190AG", KiloMetre=10300, Image = "cars/bmw-x6.jpg", Context="Mashin problemsizdir.Maraqlanmaq isteyen elaqe saxlaya biler.", TransMission=false}

            //});
            //context.SaveChanges();

            //context.Adverts.AddOrUpdate(m => m.AvtomobilId, new Advert[] {
            //    new Advert{ AvtomobilId=1, CityId=1, CreatedAt=DateTime.Now, IsVip=false, UpdatedAt=DateTime.Now, UserId=1, },
            //    new Advert{ AvtomobilId=2, CityId=1, CreatedAt=DateTime.Now, IsVip=false, UpdatedAt=DateTime.Now, UserId=1, },
            //    new Advert{ AvtomobilId=3, CityId=3, CreatedAt=DateTime.Now, IsVip=false, UpdatedAt=DateTime.Now, UserId=2, },
            //    new Advert{ AvtomobilId=4, CityId=2, CreatedAt=DateTime.Now, IsVip=true, UpdatedAt=DateTime.Now, UserId=2, },
            //    new Advert{ AvtomobilId=5, CityId=6, CreatedAt=DateTime.Now.AddMinutes(40), IsVip=true, UpdatedAt=DateTime.Now.AddMinutes(40), UserId=2, },
            //    new Advert{ AvtomobilId=6, CityId=1, CreatedAt=DateTime.Now, IsVip=true, UpdatedAt=DateTime.Now, UserId=2, },
            //    new Advert{ AvtomobilId=7, CityId=5, CreatedAt=DateTime.Now, IsVip=true, UpdatedAt=DateTime.Now, UserId=1, },
            //    new Advert{ AvtomobilId=8, CityId=4, CreatedAt=DateTime.Now, IsVip=true, UpdatedAt=DateTime.Now, UserId=1, },

            //});
            //context.SaveChanges();
        }
    }
}
