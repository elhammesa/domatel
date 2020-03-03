using domatel.Models;
using domatel.Models.Bids;
using domatel.Models.Products;
using domatel.Models.SoldItems;
using domatel.Models.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace domatel.DataLayer.Data
{
    public class DomatelContext : IdentityDbContext<User>
    {
        public DomatelContext(DbContextOptions<DomatelContext> options)
            : base(options)
        {
        }

        public DbSet<User> users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SimCart> SimCarts { get; set; }
        public DbSet<Domain> Domains { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<SoldItem> SoldItems { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
          
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

        }
    }
}
