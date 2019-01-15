using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CreepySuits.Models
{
    

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            
        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public string UserRole { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        
        public ApplicationDbContext()
            : base("master", throwIfV1Schema: false)
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            
            return new ApplicationDbContext();
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GenderAgeCategory> GenderAgeCategories { get; set; }
      
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<OrderHistory> OrderHistory { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<PickupPoint> PickupPoint { get; set; }

    }
}
