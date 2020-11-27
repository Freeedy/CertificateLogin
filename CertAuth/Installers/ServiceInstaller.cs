using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models.ServiceParameters.LoginParameters;
using Services.Services.UserServices;
using Services.Services.ValidationServices;

namespace CertAuth.Installers
{
    public class ServiceInstaller : IInstaller
	{
		public void InstallServices(IServiceCollection services, IConfiguration configuration)
		{
			services.AddSingleton(configuration);
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICertificateValidationService, CertificateValidationService>();
        }
	}
}
