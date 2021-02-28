namespace Pnprpg.DomainService.Entities
{
    public class Spell : BaseEntity
    {
        public int MagicSchoolId { get; set; }
        public int Level { get; set; }
        public int Damage { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }
        public string Effect { get; set; }

        public virtual MagicSchool MagicSchool { get; set; }
    }
}