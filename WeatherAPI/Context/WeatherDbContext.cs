using WeatherAPI.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Context
{
    public class WeatherDbContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PmeMember> PmeMembers { get; set; }

        public WeatherDbContext(DbContextOptions<WeatherDbContext> Options) : base(Options)
        {

        }
    }
}