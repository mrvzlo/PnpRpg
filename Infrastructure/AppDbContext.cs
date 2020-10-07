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
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchBonus> BranchBonuses { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<TraitEffect> Effects { get; set; }
        public DbSet<MagicSchool> MagicSchools { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Perk> Perks{ get; set; }
        public DbSet<Potion> Potions{ get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<RaceAbility> RaceAbilities { get; set; }
        public DbSet<RaceBonus> RaceBonuses { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Spell> Spells { get; set; }
        public DbSet<Trait> Traits { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<WeaponBonus> WeaponBonuses { get; set; }
    }
}
