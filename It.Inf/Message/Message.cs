using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace It.Inf.Message
{
    public class Message
    {
        public string Method { get; set; }

        public string Body { get; set; }

        public Message(string message)
        {
            dynamic deserialized = JObject.Parse(message);
            Method = deserialized.method;
            Body = deserialized.body;
        }
    }
}
