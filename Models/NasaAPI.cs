using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MarsImage.Models
{
    public class NasaAPI
    {
        public string baseUrl { get; set; }
        public string api_key { get; set; }
        public string earth_date { get; set; }

        public string GetApiParam() {

            string path = "?";
            PropertyInfo[] properties = this.GetType().GetProperties();

            int i = 0;
            while (i < properties.Length) {
                if (properties[i].Name != "baseUrl") {
                    path += properties[i].Name + "=" + properties[i].GetValue(this, null);

                    if (i < (properties.Length - 1))
                    {
                        path += "&";
                    }
                }

                i++;
            }

            return path;
        }
    }
}
