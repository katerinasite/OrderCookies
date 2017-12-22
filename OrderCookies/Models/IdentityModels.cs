using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OrderCookies.Models
{
    // В профиль пользователя можно добавить дополнительные данные, если указать больше свойств для класса ApplicationUser. Подробности см. на странице https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public string UserFIO { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<OrderCookies.Models.Cookies> Cookies { get; set; }

        public System.Data.Entity.DbSet<OrderCookies.Models.CookieForm> CookieForms { get; set; }

        public System.Data.Entity.DbSet<OrderCookies.Models.CookieSize> CookieSizes { get; set; }

        public System.Data.Entity.DbSet<OrderCookies.Models.Filling> Fillings { get; set; }

        public System.Data.Entity.DbSet<OrderCookies.Models.Glaze> Glazes { get; set; }

        public System.Data.Entity.DbSet<OrderCookies.Models.Pastry> Pastries { get; set; }

        public System.Data.Entity.DbSet<OrderCookies.Models.MiddleOrder> MiddleOrders { get; set; }

        public System.Data.Entity.DbSet<OrderCookies.Models.FinalOrder> FinalOrders { get; set; }

        public System.Data.Entity.DbSet<OrderCookies.Models.SpecialDesign> SpecialDesigns { get; set; }
    }
}