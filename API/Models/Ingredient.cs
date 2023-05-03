using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Ingredient
{
    public int IngredientId { get; set; }

    public string IngredientName { get; set; } = null!;

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
}
