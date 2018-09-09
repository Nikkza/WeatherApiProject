using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WeatherApi.API;

namespace WeatherApi.Logic
{
    public class LogicHandler
    {
        public static async Task<string> GetJson(string uri)
        {
            string json = "";
            try
            {
                using (var webClient = new WebClient())
                {
                    using (var stream = webClient.OpenRead(uri))
                    {
                        using (var streamReader = new StreamReader(stream ?? throw new InvalidOperationException()))
                        {
                            json = await streamReader.ReadToEndAsync();
                        }
                    }
                }
            }

            catch (WebException ex)
            {
                throw new Exception(ex.Message);
            }
            return json;
        }

        public void WeahterResultsFromApi(RootObject root)
        {
            if (root.list.Count == 1)
            {
                Console.WriteLine("---------------------------only the lastest time------------------------");
                foreach (var s in root.list)
                {
                    Console.WriteLine($" City: {root.city.name} | " +
                                      $"Date: {s.dt_txt} | Temp: {s.main.temp} | " +
                                      $"Sky: {s.weather[0].description} | " +
                                      $"Wind: {s.wind.speed}");
                }
            }
            else if (root.list.Count == 40)
            {
                var dateNow = DateTime.Now;
                var date = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day).ToString();
                var sub = date.Substring(0, 10);
                var list = root.list.Where(x =>
                    x.dt_txt.EndsWith("09:00:00")
                    || x.dt_txt.EndsWith("12:00:00")
                    || x.dt_txt.EndsWith("15:00:00") 
                    || x.dt_txt.EndsWith("21:00:00"));

                Console.WriteLine("---------------------------times after------------------------");
                foreach (var s in list.Skip(1))
                {
                    string dateFormat = s.dt_txt.Substring(0, 10);

                    if (sub == dateFormat)
                    {
                        Console.WriteLine($" City: {root.city.name} | " +
                                          $"Date: {s.dt_txt} | Temp: {s.main.temp} | " +
                                          $"Sky: {s.weather[0].description} | " +
                                          $"Wind: {s.wind.speed}");
                    }
                }
            }
        }
    }
}
