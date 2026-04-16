using Company.Data.Data.CMS;
using Company.Data.Data.Shop;
using Microsoft.EntityFrameworkCore;

namespace Company.Data.Data;

public class CompanyContext : DbContext
{
    public CompanyContext (DbContextOptions<CompanyContext> options)
        : base(options)
    {
    }

    public DbSet<Page> Page { get; set; } = default!;
    public DbSet<News> News { get; set; } = default!;
    public DbSet<Product> Product { get; set; } = default!;
    public DbSet<Category> Category { get; set; } = default!;
    public DbSet<CartItem> CartItem { get; set; } = default!;
    public DbSet<OrderPosition> OrderPosition { get; set; } = default!;
    public DbSet<Order> Order { get; set; } = default!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Page>().HasData(
            new Page { IdPage = 1, LinkTitle = "About Us", Title = "About Our Company", Content = "We are a leading provider of innovative solutions.", DisplayOrder = 1 },
            new Page { IdPage = 2, LinkTitle = "Services", Title = "Our Services", Content = "We offer a wide range of services to meet your needs.", DisplayOrder = 2 },
            new Page { IdPage = 3, LinkTitle = "Contact", Title = "Contact Us", Content = "Get in touch with us for more information.", DisplayOrder = 3 }
        );

        modelBuilder.Entity<News>().HasData(
            new News { IdNews = 1, LinkTitle = "New Product", Title = "Announcing Our New Product", Content = "We are excited to launch our latest product.", DisplayOrder = 1 },
            new News { IdNews = 2, LinkTitle = "Partnership", Title = "New Partnership with XYZ Corp", Content = "We have partnered with XYZ Corp to expand our reach.", DisplayOrder = 2 },
            new News { IdNews = 3, LinkTitle = "Award", Title = "We Won an Industry Award", Content = "We are proud to be recognized for our achievements.", DisplayOrder = 3 }
        );

        modelBuilder.Entity<Category>().HasData(
            new Category { IdCategory = 1, Name = "Electronics", Description = "Find the latest electronic gadgets." },
            new Category { IdCategory = 2, Name = "Books", Description = "Discover a world of knowledge." },
            new Category { IdCategory = 3, Name = "Clothing", Description = "Shop for the latest fashion trends." }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { IdProduct = 1, Code = "ELEC-001", Name = "Smartphone", Price = 699.99m, FotoURL = "https://via.placeholder.com/150", Description = "A powerful and feature-rich smartphone.", IdCategory = 1 },
            new Product { IdProduct = 2, Code = "BOOK-001", Name = "The Great Gatsby", Price = 12.99m, FotoURL = "https://via.placeholder.com/150", Description = "A classic novel by F. Scott Fitzgerald.", IdCategory = 2 },
            new Product { IdProduct = 3, Code = "CLTH-001", Name = "T-Shirt", Price = 19.99m, FotoURL = "https://via.placeholder.com/150", Description = "A comfortable and stylish t-shirt.", IdCategory = 3 },
            new Product { IdProduct = 4, Code = "ELEC-002", Name = "Laptop", Price = 1299.99m, FotoURL = "https://via.placeholder.com/150", Description = "A high-performance laptop for work and play.", IdCategory = 1 },
            new Product { IdProduct = 5, Code = "BOOK-002", Name = "To Kill a Mockingbird", Price = 14.99m, FotoURL = "https://via.placeholder.com/150", Description = "A timeless story of justice and prejudice.", IdCategory = 2 }
        );
    }
}