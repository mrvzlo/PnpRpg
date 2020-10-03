namespace FightBalancer
{
    public class FightResult
    {
        public string FighterName { get; set; }
        public int Deaths { get; set; }

        public FightResult(Fighter fighter)
        {
            FighterName = $"{fighter.Name} {fighter.Level}";
            Deaths = fighter.Logs.Deaths;
        }
    }
}
