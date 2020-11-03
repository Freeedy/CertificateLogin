﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CertAuth.Services;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
        public void ConfigureServices(IServiceCollection services )//, IConfiguration con )
        {


            services.AddControllersWithViews();
            services.AddMvc();
            services.AddTransient<MyValidationService>();
            services.AddAuthentication(

                CertificateAuthenticationDefaults.AuthenticationScheme
                ).AddCertificate(options =>
                {
                    options.Events = new CertificateAuthenticationEvents
                    {
                        OnCertificateValidated = context =>
                        {
                            var validationService = context.HttpContext.RequestServices.GetService<MyValidationService>();
                            if (validationService.ValidateCertificate(context.ClientCertificate))
                            {
                                context.Success();
                            }
                            else
                            {
                                context.Fail("Invalid Cert");
                            }
                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = contex =>
                        {
                            contex.Fail("Invalid Cert");
                            return Task.CompletedTask;
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
