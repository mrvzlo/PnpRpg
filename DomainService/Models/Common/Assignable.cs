namespace Pnprpg.DomainService.Models
{
    public abstract class Assignable
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public bool IsAssigned() => Level != 0;
    }
}
