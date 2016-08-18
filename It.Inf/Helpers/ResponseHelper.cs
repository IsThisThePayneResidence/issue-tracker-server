using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using It.Model.Interfaces;

namespace It.Inf.Helpers
{
    public static class ResponseHelper
    {
        public static IResponse GetResponse(string code, object body)
        {
            return ResponseBuilder.JsonResponse()
                .With("code", code)
                .With("data", body)
                .Done();
        }
    }
}
