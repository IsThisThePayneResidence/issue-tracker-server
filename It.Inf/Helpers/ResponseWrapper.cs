using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using It.Model.Interfaces;

namespace It.Inf.Helpers
{
    public class ResponseWrapper
    {
        private IResponse _response;

        public ResponseWrapper(IResponse response)
        {
            _response = response;
        }

        public ResponseWrapper With(string key, object value)
        {
            _response.SetProperty(key, value);
            return this;
        }

        public ResponseWrapper With(IDictionary<string, object> properties)
        {
            _response.SetProperties(properties);
            return this;
        }

        public IResponse Done()
        {
            return _response;
        }
    }
}
