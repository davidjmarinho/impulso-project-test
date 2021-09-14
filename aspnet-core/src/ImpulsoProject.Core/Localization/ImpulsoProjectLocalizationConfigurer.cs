using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace ImpulsoProject.Localization
{
    public static class ImpulsoProjectLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ImpulsoProjectConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ImpulsoProjectLocalizationConfigurer).GetAssembly(),
                        "ImpulsoProject.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
