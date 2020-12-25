using Models.Dtos.LoginDtos;
using SecurityManager.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace Models.ServiceParameters.LoginParameters
{
    public class CertificateLoginInput: ServiceInput
    {
        public string Origin { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
    }

    public class CertificateLoginOutput : ServiceOutput
    {
        public CertificateLoginDto CertificateLogin { get; set; }
    }
}
