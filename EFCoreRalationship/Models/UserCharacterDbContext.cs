using Microsoft.EntityFrameworkCore;

namespace EFCoreRalationship.Models
{
    public class UserCharacterDbContext : DbContext
    {
        public UserCharacterDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users{ get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Skill> Skills { get; set; }

    }
}
