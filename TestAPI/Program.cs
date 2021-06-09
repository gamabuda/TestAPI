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
            while(true)
            {
                Console.WriteLine("Press 'J' for one more joke with Chuck Norris!");
                char answer = Console.ReadKey(true).KeyChar;
                answer = Char.ToUpper(answer);
                if (answer == 'J')
                {
                    Console.WriteLine("-------------------------------------------------");
                    string joke = RequestJoke();
                    string sVoid = "    ";
                    Console.WriteLine(sVoid + joke);
                }
            }
        }

        static public string RequestJoke()
        {
            var url = $"http://api.icndb.com/jokes/random/3";
            var request = WebRequest.Create(url);

            var response = request.GetResponse();
            var httpStatusCode = (response as HttpWebResponse).StatusCode;

            if (httpStatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine(httpStatusCode);
            }

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                var jokeValue = JsonConvert.DeserializeObject<Root>(result);
                return(jokeValue.value[0].joke);
            }
        }
    }
}
