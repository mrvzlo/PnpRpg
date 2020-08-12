namespace Pnprpg.DomainService.Entities
{
    public class SkillInfo : BaseEntity<int>
    {
        public int Difficulty { get; set; }
        public int AbilityId { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }

        public virtual Ability Ability { get; set; }
        public virtual SkillGroup Group { get; set; }
    }
}