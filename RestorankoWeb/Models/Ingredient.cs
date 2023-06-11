using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestorankoWeb.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }

        public string IngredientName { get; set; } = null!;

        public decimal Quantity { get; set; }

        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

    }
}