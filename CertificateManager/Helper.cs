extern alias BC;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BC::Org.BouncyCastle.Asn1;
using BC::Org.BouncyCastle.Asn1.Utilities;
using BC::Org.BouncyCastle.Asn1.X509;
using FrdCoreCrypt.Objects.Static;

using X509Certificate = BC::Org.BouncyCastle.X509.X509Certificate;

namespace FrdCoreCrypt
{
    public static  class Helper
    {
        
        public static string GetAuthorityKeyIdentifier(this X509Certificate2 certificate )
        {

            Asn1OctetString ext = certificate.ConvertToBCX509Certificate().GetExtensionValue(new DerObjectIdentifier(CertificateOIDS.AuthorityKeyIdentifier)) ;


            if (ext ==null)
            {
                return null;
            }

            byte[] octets = ext.GetOctets();  ;
            AuthorityKeyIdentifier akia = AuthorityKeyIdentifier.GetInstance(octets);


            string result = BitConverter.ToString(akia.GetKeyIdentifier()).Replace("-", "");

            return result;
        }

    }
}
