using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace YourSay.Models
{
    public class YourSayDB : DbContext
    {
        public YourSayDB() : base ("DefaultConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<YourSayDB>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<YourSayDB>());
        }
        public DbSet<Causes> Causes { get; set; }                                           //Create a new DbSet to keep the causes
        public DbSet<UserAccount> userAccount { get; set; }                                 //Create a new DbSet to keep the user accounts
    }
}