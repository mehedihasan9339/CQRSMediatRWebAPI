using CQRSMediatRWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatRWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
    }
}
