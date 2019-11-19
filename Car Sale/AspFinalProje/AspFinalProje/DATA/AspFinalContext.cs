using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Web;
using AspFinalProje.Models;

namespace AspFinalProje.DATA
{
    public class AspFinalContext : DbContext
    {
      

        public AspFinalContext() : base("AspFinalContext") { }
        public DbSet<Oil> Oils { get; set; }
        public DbSet<Marka> Markas { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Avtomobil> Avtomobils { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<AdminSetting> adminSettings { get; set; }


    }
}