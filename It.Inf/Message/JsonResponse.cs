using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using It.Inf.Helpers;
using It.Model.Interfaces;
using MongoDB.Driver.Wrappers;

namespace It.Inf.Message
{
    public class JsonResponse : IResponse
    {
        private IDictionary<string, object> _properties;

        public JsonResponse()
        {
            _properties = new Dictionary<string, object>();
        }

        public JsonResponse(IDictionary<string, object> properties)
        {
            _properties = properties;
        }

        public JsonResponse(string key, object value)
        {
            _properties = new Dictionary<string, object> {{key, value}};
        }

        public void SetProperties(IDictionary<string, object> properties)
        {
            _properties = properties;
        }

        public void SetProperty(string key, object value)
        {
            _properties.Add(key, value);
        }

        public string GetResponse()
        {
            return JsonSerializationHelper.Serialize(_properties);
        }

        Model.Interfaces.Message IResponse.GetResponseMessage()
        {
            return new Model.Interfaces.Message
            {
                Body = GetResponse()
            };
        }
    }
}
