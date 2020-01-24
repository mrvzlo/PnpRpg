using System.IO;

namespace Boot.Helpers
{
    public class FileHelper
    {
        public static string ReadFile(string path)
        {
            using (var r = new StreamReader(path))
            {
                return r.ReadToEnd();
            }
        }
    }
}