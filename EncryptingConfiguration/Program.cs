using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace EncryptingConfiguration
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Open the configuration file and retrieve 
                // the connectionStrings section.
                Configuration config = WebConfigurationManager.OpenWebConfiguration(@"C:\Users\Anjeylav\Documents\Visual Studio 2017\BackEnd\DentistRegistration\DentistRegistration");

                ConnectionStringsSection section =
                    config.GetSection("connectionStrings")
                    as ConnectionStringsSection;

                if (section.SectionInformation.IsProtected)
                {
                    // Remove encryption.
                    section.SectionInformation.UnprotectSection();

                    Console.WriteLine("Protected already={0}",
                    section.SectionInformation.IsProtected);
                }
                else
                {
                    // Encrypt the section.
                    section.SectionInformation.ProtectSection(
                        "DataProtectionConfigurationProvider");
                }
                // Save the current configuration.
                config.Save();

                Console.WriteLine("Protected={0}",
                    section.SectionInformation.IsProtected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
