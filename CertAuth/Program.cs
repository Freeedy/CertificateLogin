using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace CertAuth
{
    //passs 111222

    public class Program
    {
        public static IConfiguration Configuration { get; private set; }
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();


       // public static void Main(string[] args) => CreateWebHostBuilder(args).Build().Run();

        public static void BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
           //.SetBasePath(env.ContentRootPath)
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           //.AddJsonFile($"appsettings.{}.json", optional: true)
           .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            BuildConfiguration();
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());

            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));




            var certificate = GetServiceCertificate(Configuration.GetSection("AppSetting")["SSlCertname"], Configuration.GetSection("AppSetting")["SSLCertPassw"]);
            var whb = Host.CreateDefaultBuilder(args)

          .ConfigureWebHostDefaults(webBuilder =>
          {

              webBuilder.UseStartup<Startup>();
              webBuilder.ConfigureKestrel(o =>
              {
                  o.ConfigureHttpsDefaults(o =>
              o.ClientCertificateMode =
                  ClientCertificateMode.RequireCertificate);
              });


              webBuilder.UseKestrel(options =>
              {
                  options.Listen(new IPEndPoint(IPAddress.Any, Convert.ToInt32(Configuration.GetSection("AppSetting")["PortNumber"])), listenOptions =>
                  {
                      var httpsConnectionAdapterOptions = new HttpsConnectionAdapterOptions()
                      {
                          ClientCertificateMode = ClientCertificateMode.AllowCertificate,
                          SslProtocols = System.Security.Authentication.SslProtocols.Tls12,
                          ServerCertificate = certificate
                          //,
                          //ServerCertificateSelector= (connectionContext, name) =>
                          //{
                          //    return null ;
                          //}
                      };
                      listenOptions.UseHttps(httpsConnectionAdapterOptions);
                      listenOptions.Protocols = HttpProtocols.Http1;
                  });
              }
                  );

          }
          );

            ;

            return whb;
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            BuildConfiguration();
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());

            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));




            var certificate = GetServiceCertificate(Configuration.GetSection("AppSetting")["SSlCertname"], Configuration.GetSection("AppSetting")["SSLCertPassw"]);
            var webBuilder = WebHost.CreateDefaultBuilder(args);



            webBuilder.UseStartup<Startup>();
            webBuilder.ConfigureKestrel(o =>
            {
                o.ConfigureHttpsDefaults(o =>
            o.ClientCertificateMode =
                ClientCertificateMode.RequireCertificate);
            });


            webBuilder.UseKestrel(options =>
            {
                options.Listen(new IPEndPoint(IPAddress.Loopback, Convert.ToInt32(Configuration.GetSection("AppSetting")["PortNumber"])), listenOptions =>
                {
                    var httpsConnectionAdapterOptions = new HttpsConnectionAdapterOptions()
                    {
                        ClientCertificateMode = ClientCertificateMode.AllowCertificate,
                        SslProtocols = System.Security.Authentication.SslProtocols.Tls12,
                        ServerCertificate = certificate
                        //,
                        //ServerCertificateSelector= (connectionContext, name) =>
                        //{
                        //    return null ;
                        //}
                    };
                    listenOptions.UseHttps(httpsConnectionAdapterOptions);
                    listenOptions.Protocols = HttpProtocols.Http1;
                });
            });







            return webBuilder;
        }
        private static X509Certificate2 GetServiceCertificate(string subjectName, string password)
        {

            var certbytes = File.ReadAllBytes(subjectName);

            return new X509Certificate2(certbytes, password);

            //using (var certStore = new X509Store(StoreName.My, StoreLocation.CurrentUser))
            //{
            //    certStore.Open(OpenFlags.ReadOnly);
            //    var certCollection = certStore.Certificates.Find(
            //                               X509FindType.FindBySubjectDistinguishedName, subjectName, false);
            //    // Get the first certificate
            //    X509Certificate2 certificate = null;
            //    if (certCollection.Count > 0)
            //    {
            //        certificate = certCollection[0];
            //    }
            //    return certificate;
            //}
        }
    }
}
