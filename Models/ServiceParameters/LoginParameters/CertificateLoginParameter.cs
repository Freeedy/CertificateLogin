using Models.Dtos.LoginDtos;
using SecurityManager.Models;
using System.Security.Cryptography.X509Certificates;

namespace Models.ServiceParameters.LoginParameters
{
    public class CertificateLoginInput: ServiceInput
    {
        public Customer Customer { get; set; }
        public X509Certificate2  LoginCertificate { get; set; }
    }

    public class CertificateLoginOutput : ServiceOutput
    {
        public CertificateLoginDto CertificateLogin { get; set; }
    }
}
