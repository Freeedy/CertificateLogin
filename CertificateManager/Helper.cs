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
        
        public static string GetExtentionValue(this X509Certificate2 certificate , string oid )
        {

            Asn1OctetString ext = certificate.ConvertToBCX509Certificate().GetExtensionValue(new DerObjectIdentifier(oid)) ;

            if (ext ==null)
            {
                return null;
            }

           // Console.WriteLine(Encoding.UTF8.GetString(ext.GetOctets()));
            //foreach (System.Security.Cryptography.X509Certificates.X509Extension extension in certificate.Extensions)
            //{
            //    // Create an AsnEncodedData object using the extensions information.
            //    AsnEncodedData asndata = new AsnEncodedData(extension.Oid, extension.RawData);
            //    Console.WriteLine("Extension type: {0}", extension.Oid.FriendlyName);
            //    Console.WriteLine("Oid value: {0}", asndata.Oid.Value);
            //    Console.WriteLine("Raw data length: {0} {1}", asndata.RawData.Length, Environment.NewLine);
            //  //  Console.WriteLine(asndata.Format(true));

            //    if ( asndata.Oid.Value == oid)
            //    {
            //        return asndata.Format(true);
            //    }
            string result = Encoding.Default.GetString(ext.GetOctets());
            Console.WriteLine(result);
            //}
            //DerIA5String.GetInstance()

            // Asn1TaggedObject taggedObject = (Asn1TaggedObject)element[1];
            // GeneralName gn = (GeneralName)GeneralName.GetInstance();
            //  ocspUrls.Add(((DerIA5String)DerIA5String.GetInstance(gn.Name)).GetString());

            return result;
        }

    }
}
