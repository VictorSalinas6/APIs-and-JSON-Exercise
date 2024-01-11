using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            var kanyeURL = "https://api.kanye.rest/";

            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Conversation {i}:");
                Console.WriteLine();

                var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
                var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
                Console.Write("Kanye: ");
                Console.WriteLine(kanyeQuote);
                Console.WriteLine();

                var ronResponse = client.GetStringAsync(ronURL).Result;
                var ronQuote = JArray.Parse(ronResponse).ToString().Replace("[", "").Replace("]", "").Replace('"', ' ').Trim();
                Console.Write("Ron Swanson: ");
                Console.WriteLine(ronQuote);

                for(int j  = 0; j < Console.WindowWidth; j++)
                {
                    Console.Write("_");
                }
                Console.WriteLine();
            }

        }
    }
}
