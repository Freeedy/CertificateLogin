using Models;
using Models.ServiceParameters.LoginParameters;
using System.Threading.Tasks;

namespace Services.Services.ValidationServices
{
    public interface ICertificateValidationService : IService
    {
        Task<ContainerResult<CertificateLoginOutput>> Login(CertificateLoginInput input);
        Task<ContainerResult<ValidateCertificateOutput>> ValidateCertificate(ValidateCertificateInput input);
    }
}
