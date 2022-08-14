using ReportServiceSMS.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportServiceSMS.Core
{
    public class GenerateStringSms
    {
        public string GenerateErrors(List<Error> errors, int interval)
        {
            if (errors == null)
                throw new ArgumentNullException(nameof(errors));

            if (!errors.Any())
                return string.Empty;

            var text = new StringBuilder();

            text.AppendLine($"Błędy z ostatnich {interval} minut.");

            foreach (var error in errors)
            {
                text.Append(error.Id);
                text.Append(' ');
                text.Append(error.Message);
                text.Append(' ');
                text.Append(error.Date);
                text.Append("\n");
            }

            return text.ToString(); 
        }
    }
}
