using System.Linq;

namespace Pnprpg.DomainService.Helpers
{
    public class StringHelper
    {
        public static char Separator = '.';
        public static string FormatToSentence(string src) =>
            $"{src.First().ToString().ToUpper()}{src.Substring(1).ToLower()}";
    }
}