using Formatting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formatting.Interfaces
{
    public interface IResponder
    {
        Response MakeReponse(FitNesseContext context, Request request);
        Response MakeReponse(FitNesseContext context);
    }
}
