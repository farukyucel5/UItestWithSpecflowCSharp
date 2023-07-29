using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowSelenium.Utils
{
    public class ConfigurationReader
    {
        private readonly Dictionary<string, string> properties;

        public ConfigurationReader(string filePath)
        {
            properties = new(); //new Dictionary<string, string>();
       

            // Read the properties from the file and store them in the dictionary
            foreach (string line in File.ReadAllLines(filePath))
            {
                int separatorIndex = line.IndexOf('=');
                if (separatorIndex > 0)
                {
                    string key = line.Substring(0, separatorIndex).Trim();
                    string value = line.Substring(separatorIndex + 1).Trim();
                    properties[key] = value;
                }
            }
        }

        public string? GetValue(string key)
        {
            if (properties.TryGetValue(key, out string value))
            {
                return value;
            }

            // Return null or throw an exception if the key is not found, depending on your preference
            return null;
        }
    }
}
