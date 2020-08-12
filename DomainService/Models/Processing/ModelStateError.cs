namespace Pnprpg.DomainService.Models.Processing
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
    }
}