using System;
using System.IO;
using LightBDD.Core.Configuration;
using LightBDD.Framework.Reporting.Configuration;
using LightBDD.Framework.Reporting.Formatters;
using LightBDD.NUnit3;

namespace LightBDDExample.Resources.Utils
{
    public class ConfiguredLightBddScopeAttribute : LightBddScopeAttribute
    {
        protected override void OnConfigure(LightBddConfiguration configuration)
        {
            string lProjectRootDir = AppDomain.CurrentDomain.BaseDirectory;

            if (lProjectRootDir.Contains("bin"))
            {
                string lStringToReplace = lProjectRootDir.Substring(lProjectRootDir.IndexOf("bin", StringComparison.Ordinal) - 1);
                lProjectRootDir = lProjectRootDir.Replace(lStringToReplace, "");
            }

            // some example customization of report writers
            configuration
                .ReportWritersConfiguration()
                .AddFileWriter<PlainTextReportFormatter>( Path.Combine( lProjectRootDir, "Reports", "JasminMember_{TestDateTime:yyyy-MM-dd-HH_mm_ss}.txt" ) );
            configuration    
                .ReportWritersConfiguration()
                .AddFileWriter<HtmlReportFormatter>( Path.Combine( lProjectRootDir, "Reports", "JasminMember_{TestDateTime:yyyy-MM-dd-HH_mm_ss}.html" ) );
            configuration
                .ReportWritersConfiguration()
                .AddFileWriter<XmlReportFormatter>( Path.Combine( lProjectRootDir, "Reports", "JasminMember_{TestDateTime:yyyy-MM-dd-HH_mm_ss}.xml" ) );

        }
    }
}
