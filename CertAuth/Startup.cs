using System;
using System.Security.Claims;
using System.Threading.Tasks;
using CertAuth.Installers;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models;
using Models.ServiceParameters.LoginParameters;
using Services.Services.CertificateValidationServices;

namespace CertAuth
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {

            services.InstallServicesAssembly(Configuration);
            services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme)
            .AddCertificate(options =>
            {
                options.AllowedCertificateTypes = CertificateTypes.Chained;
                options.RevocationFlag = System.Security.Cryptography.X509Certificates.X509RevocationFlag.EntireChain;
                options.RevocationMode = System.Security.Cryptography.X509Certificates.X509RevocationMode.NoCheck;
                options.Events = new CertificateAuthenticationEvents
                {
                    OnCertificateValidated = async (context) =>
                    {
                        
                        if (context.ClientCertificate == null)
                        {
                            context.Fail("Certificate is null");
                            return;
                        }
                        Console.WriteLine("Validation Start");
                        ContainerResult<ValidateCertificateOutput> data = await context.HttpContext.RequestServices
                        .GetService<ICertificateValidationService>().ValidateCertificate(new ValidateCertificateInput
                        {
                            LoginCertificate = context.ClientCertificate
                        });

                        if (!data.IsSuccess)
                        {
                            context.Fail(data.ErrorList[0].ErrorMessage);
                            return;
                        }
                        context.Principal = new ClaimsPrincipal(new ClaimsIdentity(data.Output.CertificateClaims, context.Scheme.Name));

                        context.Success();
                        
                    }
                    
                };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCertificateForwarding();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
