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
       [CustomAuth]
       public async Task<string> GetValue()
        {
            return "tested";
        }



    }
}
