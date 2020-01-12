using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace Interview.Controllers.Filters
{
    public class AuthAttribute : ActionFilterAttribute
    {
        public AuthAttribute(string authorizationMethod)
        {

        }
        public void OnExecuting()
        {
            //todo - stop execution if not authorized
        }
    }
}