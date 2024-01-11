using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            var AppSettingsText = File.ReadAllText("appsettings.json");

            var conversation = new RonVSKanyeAPI(client);

            var currentWeather = new OpenWeatherMapAPI(client,AppSettingsText);

            conversation.HowLongConversation(5);

            Console.WriteLine();
            Console.WriteLine("What a thriving conversation! Now press enter to display the weather!");

            Console.ReadKey();

            Console.Clear();

            currentWeather.DisplayWeather();

        }
    }
}
