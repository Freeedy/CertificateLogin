extern alias BC;

using BC::Org.BouncyCastle.Asn1;
using BC::Org.BouncyCastle.X509;
using FrdCoreCrypt.Objects;
using FrdCoreCrypt.Objects.Static;
using FrdCoreCrypt;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using X509Certificate = BC::Org.BouncyCastle.X509.X509Certificate;
using System.Security.Claims;

namespace FrdCoreCrypt.Converters
{
    public class ClaimConverter
    {
        

        public List<Claim> GetClaimsFromCertificate(X509Certificate2 certificate2)
        {

            var uniquename = CertManager.GetUniqueName(certificate2); 




            return null;
        }




    }
}
