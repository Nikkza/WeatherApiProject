using System.Threading.Tasks;
using System.Web.Script.Serialization;
using WeatherApi.Logic;

namespace WeatherApi.Logic
{
    public class GenericHandler<T> : IGenericHandler<T>
    {
        public T GetObject { get; set; }

        public async Task<T> WeatherApi(string uri)
        {
            string json = LogicHandler.GetJson(uri).Result;
            var data = new JavaScriptSerializer().Deserialize<T>(json);
            return await Task.FromResult(data);
        }
    }
}
