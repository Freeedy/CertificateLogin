using Common;
using Common.Enums.CommonEnums;
using Common.Enums.ErrorEnums;
using Common.Resources;
using DataAccess.UnitofWork;
using FrdCoreCrypt.Converters;
using FrdCoreCrypt.Enums;
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

                Customer customer = new Customer
                {
                    Audience = input.Origin,
                    Minutes = 15,
                    Secret = "OFRC1j9aaR2BvADxNWlG2pmuD392UfQBZZLM1fuzDEzDlEpSsn+btrpJKd3FfY855OMA9oK4Mc8y48eYUrVUSw==",
                    SecurityAlgorithm = SecurityAlgorithms.HmacSha256Signature
                };

                TokenHelper tokenHelper = new TokenHelper("CerCenter");

                Result.Output = new CertificateLoginOutput
                {
                    CertificateLogin = new CertificateLoginDto
                    {
                        AccessToken = tokenHelper.GenerateToken(new TokenInput
                        {
                            Customer = customer,
                            Claims = input.Claims
                        })
                    }
                };

                await Task.CompletedTask;
                return Result;
            });


        public async Task<ContainerResult<ValidateCertificateOutput>> ValidateCertificate(ValidateCertificateInput input)
           => await ExecuteAsync(ConnectionTypes.NONE, async () =>
           {
               ContainerResult<ValidateCertificateOutput> Result = new ContainerResult<ValidateCertificateOutput>();

               CertificateClaimConverter converter = new CertificateClaimConverter();

               var result = converter.GetClaimsFromCertificate(input.LoginCertificate);

               if (result.CertificateStatus.Status != CertificateStatusEnum.Good)
               {
                   Result.ErrorList.Add(new Error
                   {
                       ErrorCode = ErrorCodes.ORGANIZATION_DOES_NOT_EXIST,//todo add status
                       ErrorMessage = Resource.ORGANIZATION_DOES_NOT_EXIST,//todo add status
                       StatusCode = ErrorHttpStatus.NOT_FOUND //todo add status
                   });

                   return Result;
               }


               if (!result.ChainValidationStatus )
               {
                   Result.ErrorList.Add(new Error
                   {
                       ErrorCode = ErrorCodes.ORGANIZATION_DOES_NOT_EXIST,//todo add status
                       ErrorMessage = Resource.ORGANIZATION_DOES_NOT_EXIST,//todo add status
                       StatusCode = ErrorHttpStatus.NOT_FOUND //todo add status
                   });

                   return Result;
               }

               if (!input.LoginCertificate.Verify())
               {
                   Result.ErrorList.Add(new Error
                   {
                       ErrorCode = ErrorCodes.ORGANIZATION_DOES_NOT_EXIST,//todo add status
                       ErrorMessage = Resource.ORGANIZATION_DOES_NOT_EXIST,//todo add status
                       StatusCode = ErrorHttpStatus.NOT_FOUND //todo add status
                   });

                   return Result;
               }

               Result.Output = new ValidateCertificateOutput
               {
                  CertificateClaims=result.Claims 
               };

              

                await Task.CompletedTask;
               return Result;
           });

    }
}
