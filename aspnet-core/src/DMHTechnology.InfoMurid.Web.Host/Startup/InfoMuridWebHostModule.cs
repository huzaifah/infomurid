using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DMHTechnology.InfoMurid.Configuration;

namespace DMHTechnology.InfoMurid.Web.Host.Startup
{
    [DependsOn(
       typeof(InfoMuridWebCoreModule))]
    public class InfoMuridWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public InfoMuridWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(InfoMuridWebHostModule).GetAssembly());
        }
    }
}
