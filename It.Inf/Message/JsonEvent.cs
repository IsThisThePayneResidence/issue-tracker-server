using It.Model.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace It.Inf.Message
{
    public class JsonEvent<T> : IEvent
    {
        private readonly Message _message;

        public JsonEvent(string body)
        {
            _message = new Message(body);
        }

        public object GetData()
        {
            return JsonConvert.DeserializeObject<T>(_message.Body);
        }

        public Type GetDataType()
        {
            return typeof(T);
        }

        public bool IsCreate()
        {
            return _message.Method == "create";
        }

        public bool IsDelete()
        {
            return _message.Method == "delete";
        }

        public bool IsGet()
        {
            return _message.Method == "get";
        }

        public bool IsUpdate()
        {
            return _message.Method == "update";
        }
    }
}
