using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CertAuth.Services
{
    public class MyValidationService
    {
        public bool ValidateCertificate(X509Certificate2 clientCertificate)
        {
            //var cert = new X509Certificate2(Path.Combine("localhost_root_l1.pfx"), "1234");
            //if (clientCertificate.Thumbprint == cert.Thumbprint)
            //{
            //    return true;
            //}


            if ( clientCertificate!=null)
            {
                return true;
            }

            return false;
        }
    }
}
