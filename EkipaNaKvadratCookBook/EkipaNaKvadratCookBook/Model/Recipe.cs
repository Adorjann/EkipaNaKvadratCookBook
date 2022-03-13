using System;
using System.Collections.Generic;
using System.Text;

namespace EkipaNaKvadratCookBook.Model
{
    internal class Recipe
    {
        public string id { get; set; }
        public string name { get; set; }
        public IList<Step> steps { get; set; }
        public string backgroundImage { get; set; }
        public string thumbnailImage { get; set; }
        public IList<Ingredient> ingredients { get; set; }
        public string shortDescription { get; set; }
        public string longDescription { get; set; }
        public string type { get; set; }
    }
}