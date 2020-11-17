namespace Pnprpg.DomainService.Models
{
    public class ModelStateError
    {
        public string Key { get; set; }
        public string Error { get; set; }

        public ModelStateError(string key, string error)
        {
            Key = key;
            Error = error;
        }

        public ModelStateError(string error)
        {
            Error = error;
        }
    }
}