using CertAuth.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertAuth.Controllers
{
    
    [Route("api/CertLogin")]
    public class CertApiController:Controller
    {
        

       [HttpGet]
       [Route("TestCert")]
       [Authorize]
       //[RequireHttps]
       public async Task<string> GetValue()
        {
           var a =  Request.HttpContext.User; 
            return "tested";
        }



        [HttpGet]
        [Route("test")]


        public async Task<string> TestMethod()
        {
            return "TestMethod";
        }
    }
}
