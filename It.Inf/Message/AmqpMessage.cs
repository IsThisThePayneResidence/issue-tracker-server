using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace It.Inf.Message
{
    public class AmqpMessage
    {
        public string Method { get; set; }

        public string Body { get; set; }

        public AmqpMessage(string message)
        {
            dynamic deserialized = JObject.Parse(message);
            Method = deserialized.method;
            Body = deserialized.body;
        }
    }
}
