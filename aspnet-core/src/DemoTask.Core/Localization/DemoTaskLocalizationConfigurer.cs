using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace DemoTask.Localization
{
    public static class DemoTaskLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(DemoTaskConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(DemoTaskLocalizationConfigurer).GetAssembly(),
                        "DemoTask.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
