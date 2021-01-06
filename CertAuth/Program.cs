using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.Extensions.Hosting;

namespace CertAuth
{
    //passs 111222

    public class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var certificate =GetServiceCertificate("local") ;
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
                  options.Listen(new IPEndPoint(IPAddress.Loopback, 4530), listenOptions =>
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
           


            return whb; 
        }


        private static X509Certificate2 GetServiceCertificate(string subjectName)
        {

            var certbytes = File.ReadAllBytes("local.pfx");

            return new X509Certificate2(certbytes, "111222"); 

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
