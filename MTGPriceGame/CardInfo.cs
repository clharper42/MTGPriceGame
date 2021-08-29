using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGPriceGame
{
    public class ImageUris
    {
        public string small;
        public string normal;
        public string large;
        public string png;
        public string art_crop;
        public string border_crop;
    }

    public class CardFace
    {
        public string @object;
        public string name;
        public string mana_cost;
        public string type_line;
        public string oracle_text;
        public List<string> colors;
        public string power;
        public string toughness;
        public string flavor_text;
        public string artist;
        public string artist_id;
        public string illustration_id;
        public ImageUris image_uris;
        public List<string> color_indicator;
        public string loyalty;
    }

    public class AllPart
    {
        public string @object;
        public string id;
        public string component;
        public string name;
        public string type_line;
        public string uri;
    }

    public class Legalities
    {
        public string standard;
        public string future;
        public string historic;
        public string gladiator;
        public string pioneer;
        public string modern;
        public string legacy;
        public string pauper;
        public string vintage;
        public string penny;
        public string commander;
        public string brawl;
        public string historicbrawl;
        public string paupercommander;
        public string duel;
        public string oldschool;
        public string premodern;
    }

    public class Prices
    {
        public string usd;
        public string usd_foil;
        public string eur;
        public string eur_foil;
        public string tix;
    }

    public class RelatedUris
    {
        public string gatherer;
        public string tcgplayer_infinite_articles;
        public string tcgplayer_infinite_decks;
        public string edhrec;
        public string mtgtop8;
    }

    public class PurchaseUris
    {
        public string tcgplayer;
        public string cardmarket;
        public string cardhoarder;
    }

    public class Card
    {
        public string @object;
        public string id;
        public string oracle_id;
        public List<int> multiverse_ids;
        public int mtgo_id;
        public int mtgo_foil_id;
        public int tcgplayer_id;
        public int cardmarket_id;
        public string name;
        public string lang;
        public string released_at;
        public string uri;
        public string scryfall_uri;
        public string layout;
        public bool highres_image;
        public string image_status;
        public ImageUris image_uris;
        public double cmc;
        public string type_line;
        public List<string> color_identity;
        public List<string> keywords;
        public List<CardFace> card_faces;
        public List<AllPart> all_parts;
        public Legalities legalities;
        public List<string> games;
        public bool reserved;
        public bool foil;
        public bool nonfoil;
        public bool oversized;
        public bool promo;
        public bool reprint;
        public bool variation;
        public string set_id;
        public string set;
        public string set_name;
        public string set_type;
        public string set_uri;
        public string set_search_uri;
        public string scryfall_set_uri;
        public string rulings_uri;
        public string prints_search_uri;
        public string collector_number;
        public bool digital;
        public string rarity;
        public string card_back_id;
        public string artist;
        public List<string> artist_ids;
        public string border_color;
        public string frame;
        public List<string> frame_effects;
        public bool full_art;
        public bool textless;
        public bool booster;
        public bool story_spotlight;
        public int edhrec_rank;
        public Prices prices;
        public RelatedUris related_uris;
        public PurchaseUris purchase_uris;
    }


}
