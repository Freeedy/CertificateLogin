using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FrdCoreCrypt.Objects
{
    public class CertificateClaimConverterModel
    {

        public List<Claim> Claims { get; set; }

        public CertificateStatusObject CertificateStatus { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }


        public string  AKI { get; set; }

        public bool ChainValidationStatus { get; set; }


    }
}
