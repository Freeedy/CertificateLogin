using Common;
using Common.Enums.CommonEnums;
using Common.Enums.ErrorEnums;
using Common.Resources;
using DataAccess.UnitofWork;
using FrdCoreCrypt.Converters;
using FrdCoreCrypt.Enums;
using FrdCoreCrypt.Objects;
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

                TokenHelper tokenHelper = new TokenHelper();

                Result.Output = new CertificateLoginOutput
                {
                    CertificateLogin = new CertificateLoginDto
                    {
                        AccessToken = tokenHelper.GenerateToken(new TokenInput
                        {
                            Issuer = "NCSCenter",
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
            ContainerResult<ValidateCertificateOutput> result = new ContainerResult<ValidateCertificateOutput>();

            CertificateClaimConverterModel certificateClaimConverterModel = new CertificateClaimConverter()
            .GetClaimsFromCertificate(input.LoginCertificate);

            if (certificateClaimConverterModel.CertificateStatus.Status != CertificateStatusEnum.Good)
            {
                result.ErrorList.Add(new Error
                {
                    ErrorCode = ErrorCodes.ORGANIZATION_DOES_NOT_EXIST,//todo add status
                    ErrorMessage = Resource.ORGANIZATION_DOES_NOT_EXIST,//todo add status
                    StatusCode = ErrorHttpStatus.NOT_FOUND //todo add status
                });

                return result;
            }

            if (!certificateClaimConverterModel.ChainValidationStatus)
            {
                result.ErrorList.Add(new Error
                {
                    ErrorCode = ErrorCodes.ORGANIZATION_DOES_NOT_EXIST,//todo add status
                    ErrorMessage = Resource.ORGANIZATION_DOES_NOT_EXIST,//todo add status
                    StatusCode = ErrorHttpStatus.NOT_FOUND //todo add status
                });

                return result;
            }

            if (!input.LoginCertificate.Verify())
            {
                result.ErrorList.Add(new Error
                {
                    ErrorCode = ErrorCodes.ORGANIZATION_DOES_NOT_EXIST,//todo add status
                    ErrorMessage = Resource.ORGANIZATION_DOES_NOT_EXIST,//todo add status
                    StatusCode = ErrorHttpStatus.NOT_FOUND //todo add status
                });

                return result;
            }

            result.Output = new ValidateCertificateOutput
            {
                CertificateClaims = certificateClaimConverterModel.Claims
            };

            await Task.CompletedTask;
            return result;
        });
    }
}
