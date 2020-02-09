using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boot.Models
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