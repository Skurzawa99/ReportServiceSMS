using ReportServiceSMS.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportServiceSMS.Core.Repositories
{
    public class ErrorRepository
    {
        public List<Error> GetLastErrors(int intervalInMinutes)
        {
            //Pobieranie z bazy danych 

            return new List<Error>
            {
                new Error{Id = 1, Message ="Bład testowy 1", Date = DateTime.Now },
                new Error{Id = 2, Message ="Bład testowy 2", Date = DateTime.Now },
            };
        }
    }
}
