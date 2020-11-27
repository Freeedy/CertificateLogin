using Common.Enums.CommonEnums;
using DataAccess.UnitofWork;
using Microsoft.IdentityModel.Tokens;
using Models;
using Models.Dtos.LoginDtos;
using Models.ServiceParameters.LoginParameters;
using SecurityManager.Helpers;
using SecurityManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services.ValidationServices
{
    public class CertificateValidationService : AbstractService, ICertificateValidationService
    {
        public CertificateValidationService(IUnitOfWork UoW) : base(UoW) { }

        public async Task<ContainerResult<CertificateLoginOutput>> Login(CertificateLoginInput input)
            => await ExecuteAsync(ConnectionTypes.NONE, async () =>
            {
                ContainerResult<CertificateLoginOutput> Result = new ContainerResult<CertificateLoginOutput>();

                TokenHelper tokenHelper = new TokenHelper("CerCenter");
                string nameIdentifier = "5u8m8wn";
                Dictionary<string, string> claims = new Dictionary<string, string>
                {
                    { "Test", "Test" }
                };

                Result.Output = new CertificateLoginOutput
                {
                    CertificateLogin = new CertificateLoginDto
                    {
                        AccessToken = tokenHelper.GenerateToken(new TokenInput
                        {
                            Customer = input.Customer,
                            NameIdentifier = nameIdentifier,
                            Claims = claims
                        })
                    }
                };

                //await _uow.OrganizationRepository().GetOrganizationById(input.OrganizationId)

                await Task.CompletedTask;
                return Result;
            });
    }
}
