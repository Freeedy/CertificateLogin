extern alias BC;

using BC::Org.BouncyCastle.Asn1;
using BC::Org.BouncyCastle.X509;
using CertificateManager.Objects;
using CertificateManager.Objects.Static;
using FrdCoreCrypt;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using X509Certificate = BC::Org.BouncyCastle.X509.X509Certificate;


namespace CertificateManager
{
    public static  class CertManager
    {
       
        public static CertSubjectDetails GetUniqueName(X509Certificate2 certificate)
        {
            X509Certificate cert = certificate.ConvertToBCX509Certificate();
           var list = cert.SubjectDN.GetOidList();

            var values = cert.SubjectDN.GetValueList();

            

            if(list.Count!=values.Count )
            {
                return null; 
            }

           

            CertSubjectDetails result = new CertSubjectDetails();

            int indexofcmname = list.IndexOf( new DerObjectIdentifier(CertificateOIDS.SubjectOIds.CommonName_OID));
            int indexofOrg = list .IndexOf(new DerObjectIdentifier(CertificateOIDS.SubjectOIds.Organisation_OID));
            int  indexoforgunit = list.IndexOf( new DerObjectIdentifier(CertificateOIDS.SubjectOIds.OrganizationalUnit_OID));
            int  indexoftitleOid =  list.IndexOf( new DerObjectIdentifier(CertificateOIDS.SubjectOIds.Title_OID));
            int indexofgivenname = list.IndexOf(new DerObjectIdentifier(CertificateOIDS.SubjectOIds.GivenName_OID));
            int indexofsurname = list.IndexOf(new DerObjectIdentifier(CertificateOIDS.SubjectOIds.Surname_OID));
            int  indexofemail = list.IndexOf(new DerObjectIdentifier(CertificateOIDS.SubjectOIds.Email_OID));
            int indexofuid = list.IndexOf(new DerObjectIdentifier(CertificateOIDS.SubjectOIds.UserIdentifier_OID));
            int indexofloyality = list.IndexOf(new DerObjectIdentifier(CertificateOIDS.SubjectOIds.Loyality_OID));
            int indexofinitials = list.IndexOf(new DerObjectIdentifier(CertificateOIDS.SubjectOIds.Initials_OID));
            int indexofpostalcode = list.IndexOf(new DerObjectIdentifier(CertificateOIDS.SubjectOIds.PostalCode_OID));
            int indexofstate = list.IndexOf(new DerObjectIdentifier(CertificateOIDS.SubjectOIds.StateProvince_OID));
            int indexofcountry = list.IndexOf(new DerObjectIdentifier(CertificateOIDS.SubjectOIds.CountryName_OID));
            int indexofserail = list.IndexOf(new DerObjectIdentifier(CertificateOIDS.SubjectOIds.SerialNUmber_OID));



            result.CommonName = (indexofcmname !=-1) ? (string)values[indexofcmname] :null;
            result.GivenName = (indexofgivenname != -1) ? (string)values[indexofgivenname] : null;
            result.SerialNumber = (indexofserail != -1) ? (string)values[indexofserail] : null;
            result.Title = (indexoftitleOid != -1) ? (string)values[indexoftitleOid] : null;
            result.Surname = (indexofsurname != -1) ? (string)values[indexofsurname] : null;
            result.Organisation = (indexofOrg != -1) ? (string)values[indexofOrg] : null;
            result.OrganisationUnit = (indexoforgunit != -1) ? (string)values[indexoforgunit] : null;
            result.Email = (indexofemail != -1) ? (string)values[indexofemail] : null;
            result.UserId = (indexofuid != -1) ? (string)values[indexofuid] : null;
            result.Loyality = (indexofloyality != -1) ? (string)values[indexofloyality] : null;
            result.Initials = (indexofinitials != -1) ? (string)values[indexofinitials] : null;
            result.PostalCode = (indexofpostalcode != -1) ? (string)values[indexofpostalcode] : null;
            result.StateProvince = (indexofstate != -1) ? (string)values[indexofstate] : null;
            result.Country = (indexofcountry != -1) ? (string)values[indexofcountry] : null;















            // cert.SubjectDN.

            return result;
        }


        public static X509Certificate ConvertToBCX509Certificate(this X509Certificate2 cert)
        {

            X509CertificateParser parser = new X509CertificateParser();
            byte[] certarr = cert.Export(X509ContentType.Cert);
            return parser.ReadCertificate(certarr);

        }


        public static void ParseExtension(X509Certificate2 cert)
        {

            var b = GetUniqueName(cert);
            FrdOcspClient ocspclient = new FrdOcspClient();
            

            var result = ocspclient.ValidateOCSPx509_2(cert);
            foreach (X509Extension extension in cert.Extensions)
            {
                // Create an AsnEncodedData object using the extensions information.
                AsnEncodedData asndata = new AsnEncodedData(extension.Oid, extension.RawData);
                Console.WriteLine("Extension type: {0}", extension.Oid.FriendlyName);
                Console.WriteLine("Oid value: {0}", asndata.Oid.Value);
                Console.WriteLine("Raw data length: {0} {1}", asndata.RawData.Length, Environment.NewLine);
                Console.WriteLine(asndata.Format(true));
            }

            string subject = cert.GetNameInfo(X509NameType.DnsName, false);
            string cn = cert.GetNameInfo(X509NameType.SimpleName, false);


        }

    }
}
