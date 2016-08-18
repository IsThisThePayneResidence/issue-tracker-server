using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace It.Model.Interfaces
{
    public interface IResponse
    {
        void SetProperties(IDictionary<string, object> properties);

        void SetProperty(string key, object value);

        string GetResponse();

        Message GetResponseMessage();
    }
}
