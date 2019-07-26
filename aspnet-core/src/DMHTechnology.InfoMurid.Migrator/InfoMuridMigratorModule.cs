using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DMHTechnology.InfoMurid.Configuration;
using DMHTechnology.InfoMurid.EntityFrameworkCore;
using DMHTechnology.InfoMurid.Migrator.DependencyInjection;

namespace DMHTechnology.InfoMurid.Migrator
{
    [DependsOn(typeof(InfoMuridEntityFrameworkModule))]
    public class InfoMuridMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public InfoMuridMigratorModule(InfoMuridEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(InfoMuridMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                InfoMuridConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(InfoMuridMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
