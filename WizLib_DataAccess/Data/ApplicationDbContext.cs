using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizLib_Model.Models;

namespace WizLib_DataAccess.Data
{
   public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base(options)
        {
        }
       // public DbSet<Category> Categories { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers{ get; set; }
        public DbSet<Author> Authors{ get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Detail> Details { get; set; }

        public DbSet<Fluent_Detail> Fluent_Details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configure fluent API
            // composite key

            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.Author_Id, ba.Book_Id });
            
            // Detail
            modelBuilder.Entity<Fluent_Detail>().HasKey(b => b.Detail_Id);
            modelBuilder.Entity<Fluent_Detail>().Property(b => b.NumberOfChapters).IsRequired();
        }


    }
}
