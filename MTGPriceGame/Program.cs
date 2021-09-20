using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MTGPriceGame
{
    //https://scryfall.com/advanced
    //https://scryfall.com/docs/syntax
    //https://scryfall.com/docs/api/cards/random
    static class Program
    {
        static public string Color { get; set; } = "";
        static public string Typefilter { get; private set; } = "+type%3A";
        static public string Selectedtype { get; set; } = "";
        static public string Selectedtypeleg { get; private set; } = "+type%3A" + "legendary";
        static public string ColorFilter { get; set; } = "+color%3D";
        private const string URL = "https://api.scryfall.com/cards/random?q=game%3Apaper";
        private static HttpClient client = new HttpClient();
        private static HttpResponseMessage response;
        public static List<Card> cards = new List<Card>();
        public static List<string> colorfilters = new List<string>() {"Exactly", "Including", "At Most" };
        public static List<string> typefilters = new List<string>() {"Any", "Commander", "Creature", "Planeswalker", "Instant", "Sorcery", "Enchantment" };
         
        public static void Start()
        {
            Get_Cards();
        }
        public static bool Get_Cards()
        {
            string searchurl = "";
            if(!Color.Equals(""))
            {
                
                searchurl = URL + ColorFilter + Color;
            }
            else
            {
                searchurl = URL;
            }

            if(!Selectedtype.Equals(""))
            {
                searchurl = searchurl + Selectedtype;
            }

            cards.Clear();

            Card card;
            try
            {
                for (int i = 0; i < 2; i++)
                {
                    response = client.GetAsync(searchurl).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        card = response.Content.ReadAsAsync<Card>().Result;
                        cards.Add(card);
                    }
                }
            }
            catch(Exception e)
            {
                return false;
            }

            if(cards.Count == 0)
            {
                return false;
            }

            return true;

        }

    }
}
