using SMSApi.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsSender
{
    public class Sms
    {
        public static void Send(string errors, string phone)
        {
                IClient client = new ClientOAuth("0M1uC5PH7TX5gZSgM3WGvqUiSm3XobS49FP6VvYP");

                var smsApi = new SMSFactory(client, new ProxyHTTP("https://api.smsapi.pl/"));

                var result =
                    smsApi.ActionSend()
                        .SetText(errors)
                        .SetTo(phone)
                        .Execute();
        }

    }
}
