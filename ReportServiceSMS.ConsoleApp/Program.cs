using ReportServiceSMS.Core;
using ReportServiceSMS.Core.Models.Domains;
using SmsSender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportServiceSMS.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {

            var smsString = new GenerateStringSms();

            var errors = new List<Error>
            {
                new Error{Id = 1, Message ="Bład testowy 1", Date = DateTime.Now },
                new Error{Id = 2, Message ="Bład testowy 2", Date = DateTime.Now },
            };

            Console.WriteLine("Wysłanie e-mail(Błędy w aplikacji)...");

            Sms.Send(smsString.GenerateErrors(errors, 10), "48510119404");

            Console.WriteLine("Wysłanno e-mail(Błędy w aplikacji)...");
            
            Console.ReadLine();
        }
    }
}
