using System.Collections.Generic;
using System.Linq;

namespace Pnprpg.DomainService.Models.Processing
{
    public class ServiceResponse<T> where T : class
    {
        public List<ModelStateError> Errors { get; set; }

        public ServiceResponse() => Errors = new List<ModelStateError>();

        public bool Successful() => !Errors.Any();

        public ServiceResponse<T> AddError(string error, string key = "")
        {
            Errors.Add(new ModelStateError(key, error));
            return this;
        }

        public T Object { get; set; }
    }
}