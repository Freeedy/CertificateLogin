using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrdCoreCrypt.Enums
{
    public class CertificateClaims
    {
        public const string SubjectCommonName = "cert_subj_CN";
        public const string SubjectGivenName = "cert_subj_GN";
        public const string SubjectSurname = "cert_subj_SN";
        public const string SubjectCountry = "cert_subj_C";
        public const string SubjectOrganisation = "cert_subj_O";
        public const string SubjectOrganisationUnit = "cert_subj_OU";
        public const string SubjectSerialNUmber = "cert_subj_SERIALNUMBER";
        public const string SubjectTitle = "cert_subj_T";
        public const string SubjectStateProvince = "cert_subj_SP";
        public const string CertificateOCSPStatus = "cert_validation_OCSPStatus";
        public const string CertificateOCSPResultTime = "cert_validation_OCSPProducedTime";
        public const string CertificateChainValidation = "cert_validation_Chain";
        public const string CertificateValidFrom = "cert_VFR";
        public const string CertificateValidTo = "cert_VTO";
        public const string CertificateAuthorityKeyIdentifier = "cert_AKI";

    }
}
