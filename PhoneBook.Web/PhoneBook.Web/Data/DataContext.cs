using Microsoft.EntityFrameworkCore;
using PhoneBook.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Web.Data
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=PhoneBook.db");
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DataContext()
        {
        }

        public DbSet<PhoneBookContact> PhoneBookContacts { get; set; }

        public DbSet<Entry> Entries { get; set; }


    }
}
