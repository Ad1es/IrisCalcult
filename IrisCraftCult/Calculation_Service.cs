using System;
using System.Collections.Generic;
using System.Text;

namespace IrisCraftCalc
{
    public class CraftService
    {
        // Словарь для хранения общего количества ресурсов: <Имя предмета, Количество>
        private Dictionary<string, int> _totalMaterials = new();

        public Dictionary<string, int> CalculateTotalResources(GameItem targetItem, int desiredQuantity)
        {
            _totalMaterials.Clear();
            CalculateRecursive(targetItem, desiredQuantity);
            return _totalMaterials;
        }

        private void CalculateRecursive(GameItem item, int quantity)
        {
            if (!item.IsCraftable)
            {
                // Если это базовый ресурс, просто добавляем в список
                AddMaterial(item.Name, quantity);
                return;
            }

            // Если предмет крафтовый, считаем, сколько раз нужно запустить процесс крафта
            int craftsNeeded = (int)Math.Ceiling((double)quantity / item.Recipe.OutputQuantity);

            foreach (var ingredient in item.Recipe.RequiredItems)
            {
                // Рекурсивно уходим вглубь для каждого ингредиента
                CalculateRecursive(ingredient.Item, ingredient.Quantity * craftsNeeded);
            }
        }

        private void AddMaterial(string name, int amount)
        {
            if (_totalMaterials.ContainsKey(name))
                _totalMaterials[name] += amount;
            else
                _totalMaterials[name] = amount;
        }
    }
}
