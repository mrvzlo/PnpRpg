using System;
using System.Collections.Generic;
using System.Linq;

namespace Boot.Models
{
    public class ServiceResponse
    {
        public List<ModelStateError> Errors { get; set; }

        public ServiceResponse() => Errors = new List<ModelStateError>();

        public bool Successful() => !Errors.Any();

        public ServiceResponse AddError(string error, string key = "")
        {
            Errors.Add(new ModelStateError(key, error));
            return this;
        }
    }
}