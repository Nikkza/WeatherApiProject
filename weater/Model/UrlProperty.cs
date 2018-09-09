namespace WeatherApi.Model
{
    public class UrlProperty
    {
        private string _urlApi;

        public string UrlApi
        {
            get => _urlApi;
            set => _urlApi = value;
        }

        private string _urlDays;

        public string UrlDays
        {
            get => _urlDays;
            set => _urlDays = value;
        }
    }
}
