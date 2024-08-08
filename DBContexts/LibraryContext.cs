using BinarTestMandiri.Models;
using Microsoft.EntityFrameworkCore;

namespace BinarTestMandiri.DBContexts
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fill category
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Biography",
                    Description = "A biography (from the Greek words bios meaning \"life\", and graphos meaning \"write\") is a non-fictional account of a person's life. Biographies are written by an author who is not the subject/focus of the book."
                },
                new Category
                {
                    Id = 2,
                    Name = "Comics",
                    Description = "A comic book or comicbook, also called comic magazine or simply comic, is a publication that consists of comic art in the form of sequential juxtaposed panels that represent individual scenes."
                },
                new Category
                {
                    Id = 3,
                    Name = "Mystery",
                    Description = "The mystery genre is a genre of fiction that follows a crime (like a murder or a disappearance) from the moment it is committed to the moment it is solved. Mystery novels are often called “whodunnits” because they turn the reader into a detective trying to figure out the who, what, when, and how of a particular crime."
                }
            );

            //fill book
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    CategoryId = 1,
                    Title = "Women in the Valley of the Kings",
                    Price = 15000
                },
                new Book
                {
                    Id = 2,
                    CategoryId = 1,
                    Title = "Ask Not: The Kennedys and the Women They Destroyed",
                    Price = 23000
                },
                new Book
                {
                    Id = 3,
                    CategoryId = 2,
                    Title = "One Piece",
                    Price = 17000
                },
                new Book
                {
                    Id = 4,
                    CategoryId = 2,
                    Title = "Naruto",
                    Price = 17000
                },
                new Book
                {
                    Id = 5,
                    CategoryId = 3,
                    Title = "The Grandest Game",
                    Price = 30000
                },
                new Book
                {
                    Id = 6,
                    CategoryId = 3,
                    Title = "Look in the Mirror",
                    Price = 25000
                }
            );

            //fill user
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "Andi",
                    Password = "12345"
                },
                new User
                {
                    Id = 2,
                    Username = "Budi",
                    Password = "12345"
                }
            );

            //fill user detail
            modelBuilder.Entity<UserDetail>().HasData(
                new UserDetail
                {
                    Id = 1,
                    UserId = 1,
                    Age = 26,
                    Name = "Andi Suherman",
                    Email = "andi@test.com"
                },
                new UserDetail
                {
                    Id = 2,
                    UserId = 2,
                    Age = 22,
                    Name = "Budi Herlambang",
                    Email = "budi@test.com"
                }
            );

            //fill transaction
            modelBuilder.Entity<Transaction>().HasData(
                new Transaction
                {
                    Id = 1,
                    UserId = 1,
                    BookId = 1
                },
                new Transaction
                {
                    Id = 2,
                    UserId = 2,
                    BookId = 5
                }
            );
        }
    }
}
