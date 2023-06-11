using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestorankoWeb.Models
{
    public class RecipeIngredient
    {
        public int RecipeId { get; set; }

        public int IngredientId { get; set; }

        public decimal Quantity { get; set; }

        public virtual Ingredient Ingredient { get; set; } = null!;

        public virtual Recipe Recipe { get; set; } = null!;
    }
}