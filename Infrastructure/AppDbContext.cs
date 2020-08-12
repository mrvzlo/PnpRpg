using System.Data.Entity;
using Pnprpg.DomainService.Entities;

namespace Pnprpg.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Database.SetInitializer<AppDbContext>(null);
        }

        public DbSet<Ability> Abilities { get; set; }
        public DbSet<AlchemySymbol> AlchemySymbols { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Effect> Effects { get; set; }
        public DbSet<MagicSchoolGroup> MagicSchoolGroups{ get; set; }
        public DbSet<MagicSchool> MagicSchools { get; set; }
        public DbSet<Perk> Perks{ get; set; }
        public DbSet<Potion> Potions{ get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<RequirementForPerk> RequirementsForPerks { get; set; }
        public DbSet<SkillGroup> SkillGroups { get; set; }
        public DbSet<SkillInfo> SkillInfos { get; set; }
        public DbSet<Spell> Spells { get; set; }
        public DbSet<Trait> Traits { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<WeaponBonus> WeaponsBonuses { get; set; }
    }
}
