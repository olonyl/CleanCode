using Formatting.Entities;
using Formatting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formatting.Handlers
{
    public class NotFoundResponder : IResponder
    {
        public Response MakeReponse(FitNesseContext context, Request request)
        {
            throw new NotImplementedException();
        }

        public Response MakeReponse(FitNesseContext context)
        {
            throw new NotImplementedException();
        }
    }
}
