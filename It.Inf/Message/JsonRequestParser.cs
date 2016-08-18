using It.Model.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using It.Inf.Helpers;
using Newtonsoft.Json.Serialization;

namespace It.Inf.Message
{
    public class JsonRequestParser<T> : IRequest
    {
        private readonly AmqpMessage _amqpMessage;

        public JsonRequestParser(string body)
        {
            _amqpMessage = new AmqpMessage(body);
        }

        public object GetData()
        {
            return JsonSerializationHelper.Deserialize<T>(_amqpMessage.Body);
        }

        public Type GetDataType()
        {
            return typeof(T);
        }

        public bool IsCreate()
        {
            return _amqpMessage.Method == "create";
        }

        public bool IsDelete()
        {
            return _amqpMessage.Method == "delete";
        }

        public bool IsGet()
        {
            return _amqpMessage.Method == "get";
        }

        public bool IsUpdate()
        {
            return _amqpMessage.Method == "update";
        }
    }
}
