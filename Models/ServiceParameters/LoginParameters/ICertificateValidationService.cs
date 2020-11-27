using System.Threading.Tasks;

namespace Models.ServiceParameters.LoginParameters
{
    public interface ICertificateValidationService
    {
        Task<ContainerResult<CertificateLoginOutput>> Login(CertificateLoginInput input);
    }
}
