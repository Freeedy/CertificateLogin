using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CertAuth.Helpers;
using CertAuth.Installers;
using CertAuth.Services;
using CertificateManager;
using Common;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Models;
using Models.ServiceParameters.LoginParameters;
using SecurityManager.Models;
using Services.Services.ValidationServices;

namespace CertAuth
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)//, IConfiguration con )
        {

            services.InstallServicesAssembly(Configuration);
            //////services.AddControllersWithViews();
            // services.AddMvc();
            //services.AddTransient<MyValidationService>();
            services.AddAuthentication(

                CertificateAuthenticationDefaults.AuthenticationScheme
                )
              
         
            .AddCertificate(options =>
            {
                options.AllowedCertificateTypes = CertificateTypes.Chained;
                options.Events = new CertificateAuthenticationEvents
                {
                    OnCertificateValidated = async (context) =>
                    {

                        //Customer customer = new Customer
                        //{
                        //    Audience = "SxmVips",
                        //    Minutes = 15,
                        //    Secret = "OFRC1j9aaR2BvADxNWlG2pmuD392UfQBZZLM1fuzDEzDlEpSsn+btrpJKd3FfY855OMA9oK4Mc8y48eYUrVUSw==",
                        //    SecurityAlgorithm = SecurityAlgorithms.HmacSha256Signature
                        //};

                        //var validationService = context.HttpContext.RequestServices.GetService<ICertificateValidationService>();

                        //ContainerResult<CertificateLoginOutput> validationServiceResult = await validationService.Login(new CertificateLoginInput
                        //{
                        //    Customer = customer,
                        //    LoginCertificate = context.ClientCertificate
                        //});

                        CertManager.ParseExtension(context.ClientCertificate);

                        var claims = new[]
                       {
                            new Claim(ClaimTypes.NameIdentifier, context.ClientCertificate.Subject, ClaimValueTypes.String, context.Options.ClaimsIssuer),
                            new Claim(ClaimTypes.Name, context.ClientCertificate.Subject, ClaimValueTypes.String, context.Options.ClaimsIssuer)
                        };

                        context.Principal = new ClaimsPrincipal(new ClaimsIdentity(claims, context.Scheme.Name));

                        
                        context.Response.StatusCode= 203;

                        context.Success();

                       // context.Fail("Certificate Fail");
                        
                    }


                };
            });
           
            //services.AddMvc();
            //services.AddControllers();
            //services.AddAuthentication(
            // CertificateAuthenticationDefaults.AuthenticationScheme)
            //    .AddCertificate(options =>
            //    {
            //        options.Events = new CertificateAuthenticationEvents
            //        {
            //            OnCertificateValidated = context =>
            //            {
            //                var claims = new[]
            //                {
            //                    new Claim(
            //                        ClaimTypes.NameIdentifier,
            //                        context.ClientCertificate.Subject,
            //                        ClaimValueTypes.String,
            //                        context.Options.ClaimsIssuer),
            //                    new Claim(ClaimTypes.Name,
            //                        context.ClientCertificate.Subject,
            //                        ClaimValueTypes.String,
            //                        context.Options.ClaimsIssuer)
            //                };

            //                context.Principal = new ClaimsPrincipal(
            //                    new ClaimsIdentity(claims, context.Scheme.Name));
            //                context.Success();

            //                return Task.CompletedTask;
            //            }
            //        };
            //    });

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCertificateForwarding();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //{


        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }
        //    else
        //    {
        //        app.UseHsts();
        //    }
        //    app.UseRouting();
        //    app.UseCertificateForwarding();
        //    app.UseAuthentication();
        //    app.UseAuthorization();
        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapControllers();
        //    });
        //    //  app.UseMvcWithDefaultRoute();
        //    // app.UseRouting(); 

        //    //app.Run(async (context) =>
        //    //{
        //    //    await context.Response.WriteAsync("Hello World!");
        //    //});
        //}
    }
}
