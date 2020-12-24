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
using System.Linq;
using FrdCoreCrypt.Enums;

namespace FrdCoreCrypt.Converters
{
    public class ClaimConverter
    {
        

        /// <summary>
        /// Convert Dictionary of Claims  to List of Claims 
        /// </summary>
        /// <param name="certificate2"></param>
        /// <returns></returns>
        public List<Claim> GetClaimsFromCertificate(X509Certificate2 certificate2)
        {
            var uniquename = CertManager.GetUniqueName(certificate2); 

            ///Get subject Claims 
            List<Claim> result = uniquename.Claims.Values.ToList();

            FrdOcspClient ocspClient = new FrdOcspClient();

            var ocspresult = ocspClient.ValidateOCSPx509_2(certificate2);

            Claim ocsptimeClaim = new Claim(CertificateClaims.CertificateOCSPResultTime, ocspresult.ProducedUTC.ToString());
            Claim ocspResultClaim = new Claim(CertificateClaims.CertificateOCSPStatus, ocspresult.Status.ToString());

            Claim certVFR = new Claim(CertificateClaims.CertificateValidFrom, certificate2.NotBefore.ToString());

            Claim certVTO = new Claim(CertificateClaims.CertificateValidTo, certificate2.NotAfter.ToString());

            string aki = certificate2.GetAuthorityKeyIdentifier();

            result.AddRange( new Claim[] { ocspResultClaim, ocspResultClaim ,certVFR ,certVTO } );
           
             if (aki!=null)
            {
                result.Add(new Claim(CertificateClaims.CertificateAuthorityKeyIdentifier, aki));
            }


            return result;
        }




    }
}
