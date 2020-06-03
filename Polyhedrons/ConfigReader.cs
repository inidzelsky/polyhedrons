using System.Xml.Linq;

namespace Polyhedrons
{
    public class ConfigReader
    {
        public static string ReadConnectionString()
        {
            return XDocument
                .Load("App.config").Root
                .Element("connectionStrings")
                .Element("add")
                .Attribute("connectionString").Value;
        }
    }
}