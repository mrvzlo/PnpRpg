namespace Pnprpg.DomainService.Helpers
{
    public static class Int32Extension
    {
        public static bool Fits(this int value, int max, int min = 0)
            => value >= min && value <= max;
    }
}
