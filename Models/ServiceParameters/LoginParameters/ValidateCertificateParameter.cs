using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceParameters.LoginParameters
{
    public class ValidateCertificateInput:ServiceInput
    {
       public X509Certificate2 LoginCertificate { get; set; } 

    }

    public class ValidateCertificateOutput:ServiceOutput
    {
       public   List<Claim> CertificateClaims { get; set;  }
    }
}
