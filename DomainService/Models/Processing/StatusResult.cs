using System.Collections.Generic;
using System.Linq;

namespace Pnprpg.DomainService.Models
{
    public class StatusResult
    {
        public string Color, Message;

        public StatusResult(bool success, string message) => Init(success, message);

        public StatusResult(List<ModelStateError> errors)
        {
            var success = !errors.Any();
            var message = success ? "" : string.Join(", ", errors.Select(x => x.Error));
            Init(success, message);
        }

        private void Init(bool success, string message)
        {
            Color = success ? "success" : "danger";
            Message = message;
        }
    }
}