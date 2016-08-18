using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using It.Inf.Message;
using It.Model.Interfaces;

namespace It.Inf.Helpers
{
    public static class ResponseBuilder
    {
        public static ResponseWrapper JsonResponse()
        {
            return new ResponseWrapper(new JsonResponse());
        }
    }
}
