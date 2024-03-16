using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using IdentityDbContext = Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext;
using Stor_E_Books.Models;





namespace Stor_E_Books.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet <Book> Books { get; set; }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<ShopppingCart> shoppingCarts { get; set; }

        public DbSet<CartDetail> cartDetails { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderStatus> orderStatuses { get; set; }






    }
}
