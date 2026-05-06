using System;
using System.Collections.Generic;
using System.Text;

namespace IrisCraftCalc
{
    public class CraftCalculationResult
    {
        public string ItemName { get; set; }
        public int TotalRequired { get; set; }    // Сколько всего нужно по рецепту
        public int InInventory { get; set; }      // Сколько уже есть в сумке
        public int Shortage => Math.Max(0, TotalRequired - InInventory); // Сколько нужно докупить
    }
}