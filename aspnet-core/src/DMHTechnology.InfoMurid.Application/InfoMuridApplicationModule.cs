using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DMHTechnology.InfoMurid.Authorization;

namespace DMHTechnology.InfoMurid
{
    [DependsOn(
        typeof(InfoMuridCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class InfoMuridApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<InfoMuridAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(InfoMuridApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
