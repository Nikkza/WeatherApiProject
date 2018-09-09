using System.Configuration;
using WeatherApi.Model;

namespace WeatherApi.Logic
{
    public class Variables
    {
        public static UrlProperty SetUrl()
        {
            UrlProperty url = new UrlProperty
            {
                UrlApi = ConfigurationManager.AppSettings["url"],
                UrlDays = ConfigurationManager.AppSettings["urldays"]

            };
            return url;
        }
    }
}
