using CertAuth.Attributes;
using CertAuth.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.ServiceParameters.LoginParameters;
using Services.Services.ValidationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertAuth.Controllers
{

    public class CertApiController : BaseV1Controller
    {
        private readonly ICertificateValidationService _certificateValidationService;

        public CertApiController(ICertificateValidationService certificateValidationService) :
            base(certificateValidationService) => _certificateValidationService = certificateValidationService;

        [HttpGet]
        [Authorize]
        [Route("certificateLogin/{origin}")]
        public async Task<IActionResult> CertificateLogin(string origin) =>
        Result(await _certificateValidationService.Login(new CertificateLoginInput
        {
            Origin = origin,
            Claims = Request.HttpContext.User.Claims
        }));
    }
}
