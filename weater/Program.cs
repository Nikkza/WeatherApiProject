using System;
using WeatherApi.API;
using WeatherApi.Logic;

namespace WeatherApi
{
    public class Program
    {
        private static void Main(string[] args)
        {
            GenericHandler<RootObject> rootObject = new GenericHandler<RootObject>();
            LogicHandler logic = new LogicHandler();
            rootObject.GetObject = rootObject.WeatherApi(Variables.SetUrl().UrlApi).Result;
            logic.WeahterResultsFromApi(rootObject.GetObject);
            rootObject.GetObject = rootObject.WeatherApi(Variables.SetUrl().UrlDays).Result;
            logic.WeahterResultsFromApi(rootObject.GetObject);

            Console.ReadKey();
        }
    }
}
