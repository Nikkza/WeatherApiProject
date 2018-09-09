using System.Threading.Tasks;

namespace WeatherApi.Logic
{
    public interface IGenericHandler<T>
    {
        T GetObject { get; set; }

        Task<T> WeatherApi(string uri);
    }
}