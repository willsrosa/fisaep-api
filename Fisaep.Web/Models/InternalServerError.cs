using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Fisaep.Web.Models
{
    public class InternalServerError : ApiError
    {
        public InternalServerError()
            : base(415, HttpStatusCode.InternalServerError.ToString())
        {
        }


        public InternalServerError(string message)
            : base(415, HttpStatusCode.InternalServerError.ToString(), message)
        {
        }
    }
}
