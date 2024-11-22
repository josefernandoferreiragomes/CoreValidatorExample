
using CoreValidatorExample.DataAccessLayer;
using CoreValidatorExample.DataAccessLayer.Data;

using System.Net.Http.Headers;
namespace CoreValidatorExample.BusinessLayer.Repository
{
    public class AppraisalSvcRepository
    {

        public string GetDataFromApi()
        {
            //example service call, missing try catch and dispose
            string result = "";
            string address = @"http://localhost:5108/";
            HttpClient httpClient = new HttpClient();
            Uri addressUri = new Uri(address);
            httpClient.BaseAddress = addressUri;

            var client = new CoreValidatorExample.DataAccessLayer.WeatherForecastClient(address, httpClient);

            WeatherForecast forecast = client.GetWeatherForecastAsync().Result.First();
            result = string.Format("{0} {1}", forecast.Summary, forecast.TemperatureC);
            return result;
        }


    }
}