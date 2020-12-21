using FrdCoreCrypt.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrdCoreCrypt.Objects
{
    public class CertificateStatusObject
    {
        public CertificateStatusEnum  Status { get; private set; }

        public DateTime ProducedUTC { get; private set; }


        public string SignatureAlgName { get; private set; }


        public CertificateStatusObject(DateTime produced , string algname , CertificateStatusEnum status )
        {
            SetStatus(produced, algname, status); 
        }

        public CertificateStatusObject()
        {

        }


        public void SetStatus(DateTime produced, string algname, CertificateStatusEnum state )
        {
            Status = state;
            ProducedUTC = produced;
            SignatureAlgName = algname;
        }
        public CertificateStatusObject(CertificateStatusEnum state)
        {
            Status = state;
        }


    }
}
