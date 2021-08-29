using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MTGPriceGame
{
    static class Program
    {
        private const string URL = "https://api.scryfall.com/cards/random";
        private static HttpClient client = new HttpClient();
        private static HttpResponseMessage response;
        public static List<Card> cards = new List<Card>();
        public static void Start()
        {
            Get_Cards();
        }
        public static void Get_Cards()
        {
            cards.Clear();

            Card card;

            for(int i = 0; i < 2; i++)
            {
                response = client.GetAsync(URL).Result;
                if (response.IsSuccessStatusCode)
                {
                    card = response.Content.ReadAsAsync<Card>().Result;
                    cards.Add(card);
                }
            }
        }

    }
}
