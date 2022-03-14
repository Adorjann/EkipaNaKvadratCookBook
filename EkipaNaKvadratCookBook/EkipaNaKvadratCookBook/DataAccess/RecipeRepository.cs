using EkipaNaKvadratCookBook.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace EkipaNaKvadratCookBook.DataAccess
{
    internal class RecipeRepository : IRecipeRepository
    {
        private List<Recipe> _recipes;
        private const string FileName = "recipe.txt";

        public RecipeRepository()
        {
            LoadRecipes();
        }

        public List<Recipe> GetRecipesByType(string type)
        {
            return _recipes.Where(r => r.type.Equals(type)).ToList();
        }

        public List<Recipe> GetTypesOfRecipes()
        {
            return _recipes.Distinct().ToList();
        }

        private void LoadRecipes()
        {
            var path = Path.Combine(FileSystem.AppDataDirectory, FileName);
            if (!File.Exists(path))
            {
                Init();
                return;
            }

            var data = File.ReadAllText(path);
            _recipes = JsonConvert.DeserializeObject<List<Recipe>>(data);
        }

        private void Save()
        {
            File.WriteAllText(Path.Combine(FileSystem.AppDataDirectory, FileName), JsonConvert.SerializeObject(_recipes));
        }

        private void Init()
        {
            if (_recipes == null)
            {
                RecipeList recipeList = JsonConvert.DeserializeObject<RecipeList>("{\n\t\"recipe\": [{\n\t\t\t\"id\": \"63eac511-4450-402d-aad1-3d83ce512a" +
                    "0d\",\n\t\t\t\"name\": \"Losos na roštilju sa prelivom od tri začina\",\n\t\t\t\"steps\": [{\n\t\t\t\t\t\"text\": \"Napravite preliv tako što" +
                    " sitno iseckajte prešun, dodajte ostale sastojke, dobro izmešajte i ostavite da odstoji bar pola sata kako bi se ukusi sjedinili.\"\n\t\t\t\t}" +
                    ",\n\t\t\t\t{\n\t\t\t\t\t\"text\": \"Filetu lososa skinite kožu, i isecite na komade, na primer, kao trouglovi i pokapajte maslinovim" +
                    " uljem.\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"text\": \"Na vrelom roštilj tiganju ili roštilju ispecite losos 3 minuta sa jedne strane i 2" +
                    " minuta sa druge strane, dopeći će se još stajanjem koji minut pre služenja. Kad skinete losos sa roštilja prelijte pripremljenim prelivom." +
                    "\"\n\t\t\t\t}\n\t\t\t],\n\t\t\t\"backgroundImage\": \"background1.png\",\n\t\t\t\"thumbnailImage\": \"thumbnail1.png\",\n\t\t\t\"ingredients\": " +
                    "[{\n\t\t\t\t\t\"name\": \"fileta lososa\",\n\t\t\t\t\t\"unit\": \"kg\",\n\t\t\t\t\t\"amount\": \"1\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": " +
                    "\"veze peršuna\",\n\t\t\t\t\t\"amount\": \"1/2\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"kašičice suve nane (mente)\",\n\t\t\t\t\t\"amount\":" +
                    " \"1/2\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"kašičice origana\",\n\t\t\t\t\t\"amount\": \"1/2\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": " +
                    "\"kašika kapra\",\n\t\t\t\t\t\"amount\": \"1\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"limuna rendana kora i sok\",\n\t\t\t\t\t\"amount\": \"1/2" +
                    "\"\n\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"maslinovog ulja\",\n\t\t\t\t\t\"unit\": \"ml\",\n\t\t\t\t\t\"amount\": \"50-70\"\n\t\t\t\t}" +
                    ",\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"so i biber\"\n\t\t\t\t}\n\t\t\t],\n\t\t\t\"shortDescription\": \"Za ljubitelje lososa jednostavno, brzo i veoma " +
                    "ukusno, sta je više potrebno.\",\n\t\t\t\"longDescription\": \"Za ljubitelje lososa jednostavno, brzo i veoma ukusno, sta je više potrebno.\"," +
                    "\n\t\t\t\"type\": \"Lunch\"\n\t\t},\n\t\t{\n\t\t\t\"id\": \"6a5b3a53-d8ed-4a8f-bf40-940a09adf016\",\n\t\t\t\"name\": \"Ramstek sa prelivom od soja" +
                    " sosa\",\n\t\t\t\"steps\": [{\n\t\t\t\t\t\"text\": \"Ramstek posuti sa malo maslinovog ulja, staviti u najlon kesu i lagano izlupati tučkom preko " +
                    "kese kako ne bi oštetili strukturu mesa. Ostaviti u frižideru preko noći, a može i koji dan više. Ako nemate toliko vremena uradite to isto i ostavite" +
                    " koji sat na sobnoj temperaturi.\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"text\": \"Za preliv od soja sosa izrendati u posudi češalj belog luka, koren" +
                    " djumbira, ljutu papričicu i dodati soja sos, maslinovo ulje, so, biber i sok od limuna.\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"text\": \"Obariti " +
                    "kratko blitvu.\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"text\": \"Ramstek koji je na sobnoj temperaturi pecite na vrelom roštilju ili teflon tiganju " +
                    "(ramstek debljine 2-3 cm.) oko 2 minuta s jedne strane i 2 minuta s druge strane i ostavite da odstoji koji minut kako bi ostao sočan unutra. Ovo " +
                    "važi za srednje pečeni ramstek.\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"text\": \"Na veliki tanjir za serviranje staviti ocedjeno bareno povrće, preko" +
                    " ramstek nasečen koso na komade i preliti ga pripremljenim prelivom sa soja sosom.\"\n\t\t\t\t}\n\t\t\t],\n\t\t\t\"backgroundImage\": \"background2." +
                    "png\",\n\t\t\t\"thumbnailImage\": \"thumbnail2.png\",\n\t\t\t\"ingredients\": [{\n\t\t\t\t\t\"name\": \"ramsteka\",\n\t\t\t\t\t\"unit\": \"g" +
                    "r\",\n\t\t\t\t\t\"amount\": \"400-500\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"malo maslinovog ulja\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"nam" +
                    "e\": \"velike veze blitve ili nekog drugog sličnog povrća\",\n\t\t\t\t\t\"amount\": \"2\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"čen belog lu" +
                    "ka\",\n\t\t\t\t\t\"amount\": \"1\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"dužine koren svežeg đumbira\",\n\t\t\t\t\t\"unit\": \"cm\",\n\t\t\t\t\t\"am" +
                    "ount\": \"1.5\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"male sveže ljute papričice\",\n\t\t\t\t\t\"amount\": \"1/2\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"n" +
                    "ame\": \"kašika soja sosa\",\n\t\t\t\t\t\"amount\": \"5\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"kašike maslinovog ulja\",\n\t\t\t\t\t\"amo" +
                    "unt\": \"2\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"sok 1/2 limuna\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"so i bib" +
                    "er\"\n\t\t\t\t}\n\t\t\t],\n\t\t\t\"shortDescription\": \"Za sve one ljubitelje ramsteka, u koje spadam ja i moja porodica, evo jednog recepta sa soja" +
                    " sosom, djumbirom i ostalim djakonijama koje mu daju zaista izuzetan ukus.\",\n\t\t\t\"longDescription\": \"Za sve one ljubitelje ramsteka, u koje spadam" +
                    " ja i moja porodica, evo jednog recepta sa soja sosom, djumbirom i ostalim djakonijama koje mu daju zaista izuzetan ukus.\",\n\t\t\t\"type\": \"Di" +
                    "nner\"\n\t\t},\n\t\t{\n\t\t\t\"id\": \"9ce41e7a-beef-4125-9717-167e92a235b0\",\n\t\t\t\"name\": \"Vegan špagete\",\n\t\t\t\"steps\": [{\n\t\t\t\t\t\"te" +
                    "xt\": \"Sitno isecite luk i prodinstajte u tiganju na ulju dok ne porumeni.\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"text\": \"Za to vreme u šolju sa soji" +
                    "nim ljuspicama dodajte vode do vrha i ostavite da se hidrira.\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"text\": \"Sklonite sa vatre i dodajte kašiku mleve" +
                    "ne paprike, promešajte i ostavite par minuta. Vratite tiganj na vatru, dodajte šolju vode i dinstajte još tri do pet min" +
                    "uta.\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"text\": \"Sipajte hidriranu soju u tiganj, dodajte biber, nalijte vode i ostavite oko 20 minuta da se" +
                    " krčka, uz dodavanje vode ukoliko ispari i povremeno mešanje.\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"text\": \"Dodajte pola šolje paradajz soka, fino " +
                    "naseckan beli luk ili beli luk u prahu, promešajte i kuvajte još pet minuta. Smesa ne treba da ima previše tečnosti kada je goto" +
                    "va.\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"text\": \"U odvojenom loncu pripremite sos za špagete prema uputstvu sa kesice. Nakon što provri, dodajte sme" +
                    "su koju ste pripremili u tiganju i ostavite da se krčka još pet minuta na srednjoj vatri.\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"text\": \"Špagete skuva" +
                    "jte, procedite i isperite mlakom vodom.\"\n\t\t\t\t}\n\t\t\t],\n\t\t\t\"backgroundImage\": \"background3.png\",\n\t\t\t\"thumbnailImage\": \"thumbnail3." +
                    "png\",\n\t\t\t\"ingredients\": [{\n\t\t\t\t\t\"name\": \"A\",\n\t\t\t\t\t\"unit\": \"A\",\n\t\t\t\t\t\"amount\": \"A\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"n" +
                    "ame\": \"glavica crnog luka\",\n\t\t\t\t\t\"amount\": \"1\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"šolja sojinih ljuspi" +
                    "ca\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"vegeta\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"nekoliko kašike u" +
                    "lja\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"pola šolje paradajz soka\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"kašike slatke papr" +
                    "ike\",\n\t\t\t\t\t\"amount\": \"2\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"kesica sosa za špagete\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"pol" +
                    "a kašičice bibera\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"špagete ili makaroni bez jaja\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"komad vegansko" +
                    "g kačkavalja\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"čen belog luka ili beli luk u prahu\"\n\t\t\t\t}\n\t\t\t],\n\t\t\t\"shortDescription\": \"Evo j" +
                    "ednog brzog i jednostavnog recepta koji dokazuje da priprema veganskih jela može biti jeftina, veoma jednostavna, bez komplikovanih i skupih sastojaka, a da" +
                    " ukusom može parirati bilo kom drugom jelu.\",\n\t\t\t\"longDescription\": \"Evo jednog brzog i jednostavnog recepta koji dokazuje da priprema veganskih jel" +
                    "a može biti jeftina, veoma jednostavna, bez komplikovanih i skupih sastojaka, a da ukusom može parirati bilo kom drugom jelu.\",\n\t\t\t\"type\": \"Lunc" +
                    "h\"\n\t\t},\n\t\t{\n\t\t\t\"id\": \"e4218673-904c-4962-baee-fc47b095ecb0\",\n\t\t\t\"name\": \"Voćni doručak sa kiselim mlekom\",\n\t\t\t\"steps\": " +
                    "[{\n\t\t\t\t\t\"text\": \"Oljuštiti i na komade iseći kivi, pa ga staviti u šerpu. Sipati 50 ml vode i 20 gr šećera i kuvati 5 minuta od kada smesa provr" +
                    "i. Štapnim mikserom izblendirati smesu.\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"text\": \"U malo vode rastvoriti 2 kašičice gustina, pa tu smesu dodati izmiksan" +
                    "om kiviju. Vratiti ovu smesu još malo na ringlu i kuvati dok smesa ne počne da se steže. Smesu rasporediti u 4 čaše.\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"t" +
                    "ext\": \"Istopiti 3 kašike žutog šećera kao karamel i u to dodati pahuljice. Promešati i preručiti na ravan i tanak pleh da se smesa ohladi.\"\n\t\t\t\t}" +
                    ",\n\t\t\t\t{\n\t\t\t\t\t\"text\": \"Kiselo mleko dobro izmešati sa medom. Rasporediti u čaše i staviti do služenja u frižider. Pred samo služenje ukrasit" +
                    "i i krokantima od pahuljica.\"\n\t\t\t\t}\n\t\t\t],\n\t\t\t\"backgroundImage\": \"background4.png\",\n\t\t\t\"thumbnailImage\": \"thumbnail4.png\",\n\t\t\t\"i" +
                    "ngredients\": [{\n\t\t\t\t\t\"name\": \"vode\",\n\t\t\t\t\t\"unit\": \"ml\",\n\t\t\t\t\t\"amount\": \"50\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"k" +
                    "ašičice gustina\",\n\t\t\t\t\t\"amount\": \"2\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"ovsenih ili ječmenih pahuljica\",\n\t\t\t\t\t\"unit\": \"g" +
                    "r\",\n\t\t\t\t\t\"amount\": \"100\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"kašike žutog šećera\",\n\t\t\t\t\t\"amount\": \"3\"\n\t\t\t\t}" +
                    ",\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"kivija\",\n\t\t\t\t\t\"unit\": \"gr\",\n\t\t\t\t\t\"amount\": \"250\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"p" +
                    "una kašika meda\",\n\t\t\t\t\t\"amount\": \"1\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"kiselog mleka\",\n\t\t\t\t\t\"amount\": \"450\",\n\t\t\t\t\t\"" +
                    "unit\": \"ml\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"šećera\",\n\t\t\t\t\t\"amount\": \"20\",\n\t\t\t\t\t\"unit\": \"gr\"\n\t\t\t\t}\n\t\t\t],\n\t\t\t\"" +
                    "shortDescription\": \"samo ime govori\",\n\t\t\t\"longDescription\": \"samo ime govori\",\n\t\t\t\"type\": \"Breakfast\"\n\t\t},\n\t\t{\n\t\t\t\"id\": \"8" +
                    "01d4b9c-5e85-4d08-ab40-7044fc33bca9\",\n\t\t\t\"name\": \"Pogačice/grickalice\",\n\t\t\t\"steps\": [{\n\t\t\t\t\t\"text\": \"U zdjelu za miješanje dodate t" +
                    "oplo mlijeko ,mineralnu vodu šećer i kvasac/mlijeko možete malo više zagrijati tako kad dodate mineralnu da temperatura bude optimalna/miješate rukom da se" +
                    " sve otopi ostavite stajati minutu -dvije .Dodate ulje ,promiješate pa postepeno dodate brašno i sol . izmiješate sve u fino tijesto,stavite na lagano pob" +
                    "rašnjeni radni stol pa nastavite miješati da tijesto bude fino mekano i da se ne lijep,dodate toliko brašna koliko je potrebno. ,pokrijte običnom kesom i" +
                    "li ako ima posuda poklopac pa ostavite stajati 45 min. na toplom mjestu.Pripremite meso tako da sve sastojke zamiješale zajedno ,isprobate slanost i začinjen" +
                    "ost tako da komadić mesa ispečete na suhoj tavi ako ste zadovoljni ostavite stajati dok se tijesto ne digne.\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"image\": \"s" +
                    "tep5_1.png\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"text\": \"Razvaljate tijesto na tanko pa vadite krugove/ja sam ovo radila kalupom za krafne jer sam htjela ma" +
                    "nje a vi možete po želji manje ili veće komade.Zarežete krug na sredini na par mjesta .Stavite u sredinu komadić fino oblikovanog mesa.\",\n\t\t\t\t\t\"imag" +
                    "e\": \"step5_2.png\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"text\": \"Krajeve tijesta spojite.Na lim stavite tijesto sa spojem prema dolje .Lagano raširite rup" +
                    "e da se odvoje .Premažete peciva razmucenim žumanjkom ,pospite sezamom. Pecite u zagrijanoj pećnici 200C/25 min ili dok ne dobiju finu boju i počnu se odvajat" +
                    "i od papira.\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"image\": \"step5_3.png\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"text\": \"Servirate toplo ili hladn" +
                    "o.\",\n\t\t\t\t\t\"image\": \"step5_4.png\"\n\t\t\t\t}\n\t\t\t],\n\t\t\t\"backgroundImage\": \"background5.png\",\n\t\t\t\"thumbnailImage\": \"thumbnail5." +
                    "png\",\n\t\t\t\"ingredients\": [{\n\t\t\t\t\t\"name\": \"brašna\",\n\t\t\t\t\t\"unit\": \"g\",\n\t\t\t\t\t\"amount\": \"500-" +
                    "550\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"mlakog mleka\",\n\t\t\t\t\t\"unit\": \"ml\",\n\t\t\t\t\t\"amount\": \"25" +
                    "0\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"kašika kvasca\",\n\t\t\t\t\t\"amount\": \"1\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"nam" +
                    "e\": \"mineralne vode\",\n\t\t\t\t\t\"unit\": \"ml\",\n\t\t\t\t\t\"amount\": \"200\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"kafene kašike šećera " +
                    "u prahu\",\n\t\t\t\t\t\"amount\": \"2\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"suncokretovog ulja\",\n\t\t\t\t\t\"unit\": \"ml\",\n\t\t\t\t\t\"amo" +
                    "unt\": \"170\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"kafena kašika soli\",\n\t\t\t\t\t\"amount\": \"1\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"m" +
                    "levene junetine\",\n\t\t\t\t\t\"unit\": \"g\",\n\t\t\t\t\t\"amount\": \"200\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"mleveni b" +
                    "iber\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"naribani čen belog luka\",\n\t\t\t\t\t\"amount\": \"1\"\n\t\t\t\t},\n\t\t\t\t{\n\t\t\t\t\t\"name\": \"na " +
                    "vrh noža mlevenog kumina\"\n\t\t\t\t}\n\t\t\t],\n\t\t\t\"shortDescription\": \"Fine grickalice punjene mljevenim mesom. Ako ne volite sa mljevenim mesom mož" +
                    "ete koristi sir ,feta sir ,špinat i sl.\",\n\t\t\t\"longDescription\": \"Fine grickalice punjene mljevenim mesom. Ako ne volite sa mljevenim mesom možete kor" +
                    "isti sir ,feta sir ,špinat i sl.\",\n\t\t\t\"type\": \"Snack\"\n\t\t}\n\t]\n}");

                _recipes = new List<Recipe>(recipeList.recipe);
                Save();
            }
        }
    }
}