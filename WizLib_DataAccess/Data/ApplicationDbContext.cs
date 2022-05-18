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
            
            // Detail
            modelBuilder.Entity<Fluent_Detail>().HasKey(b => b.Detail_Id);
            modelBuilder.Entity<Fluent_Detail>().Property(b => b.NumberOfChapters).IsRequired();
            
            // Book
            modelBuilder.Entity<Fluent_Book>().HasKey(b => b.Book_Id);
            modelBuilder.Entity<Fluent_Book>().Property(b=>b.ISBN).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<Fluent_Book>().Property(b => b.Title).IsRequired();
            modelBuilder.Entity<Fluent_Book>().Ignore(b => b.PriceRange);
            
            //Author
            modelBuilder.Entity<Fluent_Author>().HasKey(b => b.Author_Id);
            modelBuilder.Entity<Fluent_Author>().Property(b => b.FirstName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Property(b => b.LastName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Ignore(b => b.FullName);
            
            //Publisher
            modelBuilder.Entity<Fluent_Publisher>().HasKey(b => b.Publisher_Id);
            modelBuilder.Entity<Fluent_Publisher>().Property(b => b.Name).IsRequired();
            modelBuilder.Entity<Fluent_Publisher>().Property(b => b.Location).IsRequired();

            //Genre
            modelBuilder.Entity<Fluent_Genre>().ToTable("tb_Fluent_Genre");
            modelBuilder.Entity<Fluent_Genre>().Property(b => b.GenreName).HasColumnName("Name");








        }


    }
}
