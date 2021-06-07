using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace TestAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ApiKey = "32e7ef7473524a64fee2f7f42b66389d";
            //var City = "Kazan";
            var url = $"http://api.icndb.com/jokes/random/3";

            var request = WebRequest.Create(url);

            var response = request.GetResponse();
            var httpStatusCode = (response as HttpWebResponse).StatusCode;

            if (httpStatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine(httpStatusCode);
                return;
            }

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                //Console.WriteLine(result);
                var weatherForecast = JsonConvert.DeserializeObject<Root>(result);
                Console.WriteLine(weatherForecast.value[0].joke);
                Console.ReadLine();
            }

        }
    }
}
