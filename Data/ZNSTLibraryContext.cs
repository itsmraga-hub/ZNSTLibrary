using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZNSTLibrary.Data.Models;

namespace ZNSTLibrary.Data
{
    public class ZNSTLibraryContext : DbContext
    {
        public ZNSTLibraryContext (DbContextOptions<ZNSTLibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Publisher> Publishers { get; set; } = default!;
        public DbSet<Author> Authors { get; set; } = default!;
        public DbSet<BookReservation> BookReservations { get; set; } = default!;
        public DbSet<BookRental> BookRentals { get; set; } = default!;
    }
}
