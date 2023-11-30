using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    class Day21 : Helper
    {
        public void Solve()
        {
            long part1 = 0;
            string part2 = "";

            string allText = File.ReadAllText("Input\\2020\\day21.txt");
            var lines = allText.Split("\r\n").ToList();

            var foods = new List<(HashSet<string> ingredients, List<string> allergens)>();
            foreach (var line in lines)
            {
                var x = line.TrimEnd(')').Split(" (contains ");
                foods.Add((x[0].Split().ToHashSet(), x[1].Split(", ").ToList()));
            }

            var allergenToIngredientLists = foods
                .SelectMany(f => f.allergens)
                .Distinct()
                .ToDictionary(a => a, a => foods.Where(f => f.allergens.Contains(a)).Select(f => f.ingredients).Distinct().ToList());

            var allergenToIngredient = new Dictionary<string, string>();
            while (allergenToIngredientLists.Any())
            {
                foreach (var allergen in allergenToIngredientLists.Keys)
                {
                    var possibleIngredients = allergenToIngredientLists[allergen].Select(a => a.AsEnumerable()).Aggregate((a, b) => a.Intersect(b)).ToList();
                    if (possibleIngredients.Count == 1)
                    {
                        var ingredient = possibleIngredients[0];
                        allergenToIngredient.Add(allergen, ingredient);
                        allergenToIngredientLists.Remove(allergen);

                        foreach (var otherAllergen in allergenToIngredientLists.Keys.ToArray())
                            allergenToIngredientLists[otherAllergen].ForEach(l => l.Remove(ingredient));
                        
                        break;
                    }
                }
            }

            part1 = foods.Sum(f => f.ingredients.Count(i => !allergenToIngredient.Values.Contains(i)));
            part2 = string.Join(",", allergenToIngredient.Keys.OrderBy(a => a).Select(k => allergenToIngredient[k]));
            
            WriteResultStringValues(21, part1.ToString(), part2, Result.twoStars);
        }
    }
}
