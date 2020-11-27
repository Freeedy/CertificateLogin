using Models;
using Models.ServiceParameters.LoginParameters;
using System.Threading.Tasks;

namespace Services.Services.LoginParameters
{
    public interface ICertificateValidationService
    {
        Task<ContainerResult<CertificateLoginOutput>> Login(CertificateLoginInput input);
    }
}
