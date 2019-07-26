using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace DMHTechnology.InfoMurid.Localization
{
    public static class InfoMuridLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(InfoMuridConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(InfoMuridLocalizationConfigurer).GetAssembly(),
                        "DMHTechnology.InfoMurid.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
