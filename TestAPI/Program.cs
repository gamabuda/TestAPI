using System;
using System.IO;
using Telegram.Bot;
using System.Net;
using Newtonsoft.Json;

namespace TestAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            {

                TelegramBotClient bot = new TelegramBotClient("1866845271:AAHP8bEK_weBqQ-Mji8iKTit1lRaZBHfdvU");

                bot.OnMessage += (s, arg) =>
                {
                    Console.WriteLine($"{arg.Message.Chat.FirstName}: {arg.Message.Text}");
                    bot.SendTextMessageAsync(arg.Message.Chat.Id, RequestJoke());
                };

                bot.StartReceiving();

                Console.ReadKey();
            }
        }

        static public string RequestJoke()
        {
            var url = $"http://api.icndb.com/jokes/random/1";
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
