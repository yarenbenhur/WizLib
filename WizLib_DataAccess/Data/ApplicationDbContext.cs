using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizLib_DataAccess.FluentConfig;
using WizLib_Model.Models;

namespace WizLib_DataAccess.Data
{
   public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers{ get; set; }
        public DbSet<Author> Authors{ get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Detail> Details { get; set; }

        public DbSet<Fluent_Detail> Fluent_Details { get; set; }
        public DbSet<Fluent_Book> Fluent_Books { get; set; }
        public DbSet<Fluent_Author> Fluent_Authors { get; set; }
        public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }
        public DbSet<Fluent_Genre> Fluent_Genres { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configure fluent API
            // composite key
            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.Author_Id, ba.Book_Id });
 
            //Genre table name and column name
            modelBuilder.Entity<Fluent_Genre>().ToTable("tb_Fluent_Genre");
            modelBuilder.Entity<Fluent_Genre>().Property(b => b.GenreName).HasColumnName("Name");

            modelBuilder.ApplyConfiguration(new FluentBookConfig());
            modelBuilder.ApplyConfiguration(new FluentDetailConfig());
            modelBuilder.ApplyConfiguration(new FluentBookAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentPublisherConfig());
            modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
        }
    }
}
