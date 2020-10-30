using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertAuth.Attributes
{
    public class CustomAuthAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            try
            {
                context.HttpContext.Request.Headers.TryGetValue("Signature", out StringValues signatureData);

                bool result = true;
                string body = null;

                if (context.HttpContext.Request.Method.ToUpper() == "POST" ||
                   context.HttpContext.Request.Method.ToUpper() == "PUT")
                {
                    context.HttpContext.Request.EnableBuffering();

                    using (StreamReader reader = new StreamReader(context.HttpContext.Request.Body, Encoding.UTF8, true, 1024, true))
                    {
                        body = await reader.ReadToEndAsync();
                        context.HttpContext.Request.Body.Position = 0;
                    }
                }

               
            }
            catch
            {
               // context.Result = new ActionResult("");
            }
        }


    }
}
