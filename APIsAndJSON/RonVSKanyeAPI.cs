using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    public class RonVSKanyeAPI
    {
        HttpClient _client;

        public RonVSKanyeAPI(HttpClient client)
        {
            _client = client;
        }

        public string KanyeQuote()
        {
            var kanyeURL = "https://api.kanye.rest/";

            var kanyeResponse = _client.GetStringAsync(kanyeURL).Result;

            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

            return kanyeQuote;
        }

        public string RonQuote()
        {
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            var ronResponse = _client.GetStringAsync(ronURL).Result;

            var ronQuote = JArray.Parse(ronResponse).ToString().Replace("[", "").Replace("]", "").Replace('"', ' ').Trim();

            return ronQuote;
        }

        public void HowLongConversation(int times)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine($"Conversation {i+1}:");
                Console.WriteLine();

                Console.Write("Kanye: ");
                Console.WriteLine(KanyeQuote());
                Console.WriteLine();

                Console.Write("Ron Swanson: ");
                Console.WriteLine(RonQuote());

                for (int j = 0; j < Console.WindowWidth; j++)
                {
                    Console.Write("_");
                }
                Console.WriteLine();
            }
        }

    }
}
