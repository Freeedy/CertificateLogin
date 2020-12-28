using Common.Helpers;
using ExternalServices.Services.DpcServices.IamasServices;
using ExternalServices.Services.SignerServices.OnlineSignerService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Services.ApplicationServices;
using Services.Services.ContactPersonServices;
using Services.Services.DpcIamasServices;
using Services.Services.EnumServices;
using Services.Services.OrganizationServices;
using Services.Services.ProductServices;
using Services.Services.RoleClaimServices;
using Services.Services.SubjectServices;
using Services.Services.SubOrganizationServices;
using Services.Services.UserServices;

namespace Web.Installers
{
    public class ServiceInstaller : IInstaller
	{
		public void InstallServices(IServiceCollection services, IConfiguration configuration)
		{
			services.AddSingleton(configuration);
			services.AddSingleton<IFileHelper, FileHelper>();
			services.AddSingleton<IContractGenerator, ContractGenerator>();
			services.AddTransient<IUserService, UserService>();
			services.AddTransient<IProductService, ProductService>();
			services.AddTransient<IApplicationService, ApplicationService>();
			services.AddTransient<ISubjectService, SubjectService>();
			services.AddTransient<IEnumService, EnumService>();
			services.AddTransient<IContactPersonService, ContactPersonService>();
			services.AddTransient<IOrganizationService, OrganizationService>();
			services.AddTransient<ISubOrganizationService, SubOrganizationService>();
			services.AddTransient<IRoleClaimService, RoleClaimService>();
			services.AddTransient<IDpcIamasService, DpcIamasService>();
			services.AddSingleton<ISignerService, SignerService>();
			services.AddSingleton<IIamasService, IamasService>();
		}
	}
}
