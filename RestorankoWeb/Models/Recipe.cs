using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestorankoWeb.Models
{
    public class Recipe
    {
        public int Idrecipe { get; set; }

        public string RecipeName { get; set; }

        public string RecipeDescription { get; set; }

        public string RecipeInstructions { get; set; }

        public string RecipeImage { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

    }
}