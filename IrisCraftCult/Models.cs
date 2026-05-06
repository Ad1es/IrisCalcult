using System;
using System.Collections.Generic;
using System.Text;

namespace IrisCraftCalc
{
    public class GameItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public bool IsCraftable => Recipe != null;
        public CraftRecipe Recipe { get; set; } // Если null, то это базовый ресурс (руда)
    }

    public class Ingredient
    {
        public GameItem Item { get; set; }
        public int Quantity { get; set; }
    }

    public class CraftRecipe
    {
        public List<Ingredient> RequiredItems { get; set; }
        public int OutputQuantity { get; set; } = 1; // Сколько штук получается за 1 раз
        public long GoldCost { get; set; }
    }
}
