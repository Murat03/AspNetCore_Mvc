using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace Repositories;
public class RepositoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Product>().HasData(
                new Product()
                {
                    ProductId = 1,
                    ProductName = "Computer",
                    Price = 17000
                },
                new Product()
                {
                    ProductId = 2,
                    ProductName = "SmartPhone",
                    Price = 7000
                },
                new Product()
                {
                    ProductId = 3,
                    ProductName = "Mouse",
                    Price = 500
                }
            );
        builder.Entity<Category>().HasData(new Category()
        {
            CategoryId = 1,
            CategoryName = "Electronic"
        },
        new Category()
        {
            CategoryId = 2,
            CategoryName = "Book"
        });
        }
    }
