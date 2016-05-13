using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gesture_App_1
{
    public class RecipeItem
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string RecipeName { get; set; }
        public string Level { get; set; }  //testing line
        public string Ingredients { get; set; }
        public string Image { get; set; }
    }

    public class RecipeManager
    {
        /*public static void GetAllRecipe(ObservableCollection<RecipeItem> recipeItems)
        {
            var allItems = getRecipeItems();
            recipeItems.Clear();
            allItems.ForEach(p => recipeItems.Add(p));
        }*/

        public static void GetRecipe(string category, ObservableCollection<RecipeItem> recipeItems)
        {
            var allItems = getRecipeItems();
            var filteredRecipeItems = allItems.Where(p => p.Category == category).ToList();
            recipeItems.Clear();
            filteredRecipeItems.ForEach(p => recipeItems.Add(p));
        }

        public static void GetDifficulty(string level, ObservableCollection<RecipeItem> recipeItems)
        {
            var allItems = getRecipeItems();
            var filteredRecipeItems1 = allItems.Where(p => p.Level == level).ToList();
            recipeItems.Clear();
            filteredRecipeItems1.ForEach(p => recipeItems.Add(p));
        }

        private static List<RecipeItem> getRecipeItems()
        {
            var items = new List<RecipeItem>();

            // ------- Breakfast Items --------
            items.Add(new RecipeItem() {
                Id = 1,
                Category = "Breakfast",
                RecipeName = "Porridge",
                Level = "easyLevel",
                Ingredients = "1 part Rolled Oats to 2 parts Milk, Pinch of Salt, 1 Apple, 2 tbsp Honey, Handful toasted Pecans - roughly chopped",
                Image = "Assets/Recipes/Porridge.jpg" });

            items.Add(new RecipeItem() {
                Id = 2,
                Category = "Breakfast",
                RecipeName = "Pancakes",
                Level = "intermediateLevel",
                Ingredients = "200g plain flour, 2 tsp baking powder, Pinch of sea salt, ½ tsp ground cinnamon, 220ml milk, 2 large eggs, A little butter, melted 50g toasted hazelnuts, roughly chopped, 75g butter, plus a knob 100g golden syrup, 8 mini bananas, halved lengthways, 1 tblsp caster sugar",
                Image = "Assets/Recipes/Pancakes.jpg" });

            items.Add(new RecipeItem() {
                Id = 3,
                Category = "Breakfast",
                RecipeName = "Eggs-Benedict",
                Level = "hardLevel",
                Ingredients = "6 rashers of smoked streaky bacon, Pinch of salt, 1 tsp white wine vinegar, 4 large eggs, 2 English muffins, split and toasted, Butter - for the muffins, Small handful of chives, 2 large egg yolks 150g butter, cold and cut into cubes, Juice of ½ lemon",
                Image = "Assets/Recipes/Eggs-Benedict.jpg" });


            // ------- Dinner Items --------
            items.Add(new RecipeItem() {
                Id = 4,
                Category = "Dinner",
                RecipeName = "Sweet-Sour-Chicken",
                Level = "hardLevel",
                Ingredients = "4 free range chicken breasts, 1 tbsp of rice wine, 1 tbsp of light soy sauce, ½ teaspoon salt, 1 green pepper, cut in 1 inch sqaures, 1 red pepper, cut in 1 inch sqaures, 6 spring onions - finely sliced, 1 egg - beaten, 2 tbsp cornflour, Sunflower oil for frying, For the sauce: 300ml of chicken stock, 2 tbsp light soy sauce, 1 tsp of salt, 4 tbsp Chinese white rice vinegar, 2 tbsp caster sugar, 2 tbsp tomato puree, 2 tsp cornflour, 2 tsp water",
                Image = "Assets/Recipes/Sweet-Sour-Chicken-2.jpg" });

            items.Add(new RecipeItem() {
                Id = 5,
                Category = "Dinner",
                RecipeName = "Shepherds Pie",
                Level = "intermediateLevel",
                Ingredients = "2 tbsp of olive oil, 1 large onion, chopped 2 - 3 medium carrots, chopped 700g minced lamb, 2 tbsp of thyme roughly chopped, 400ml beef stock, 2 tbsp tomato purée, 2 tsp of Worcestershire sauce, 400ml beef stock, 2 tbsp of thyme, roughly chopped, 1.75 lbs potatoes, peeled and cut into chunks, 75g butter, 100ml milk, 6 spring onions - finely sliced, Sea salt and ground black pepper to season",
                Image = "Assets/Recipes/Shepherds-Pie.jpg" });

            items.Add(new RecipeItem() {
                Id = 6,
                Category = "Dinner",
                RecipeName = "Spaghetti",
                Level = "easyLevel",
                Ingredients = "400g spaghetti, 2 tbsp olive oil, 500g beef mince, 8 rashers smoked streaky bacon, roughly chopped 1 onion -finely chopped, 2 garlic cloves- finely chopped, 1 small carrot, grated 75g mushrooms - finely chopped, 2 x 400g tins chopped tomatoes, 1 tbsp tomato purée, 250ml red wine, 1 tsp dried oregano, Handful of fresh basil - chopped, Finely grated parmesan cheese to serve",
                Image = "Assets/Recipes/Spaghetti-Bolgnese.jpg" });


            //items.Add(new RecipeItem() { Id = 1, Category = "Breakfast", RecipeName = "Porridge", Ingredients = "1 part Rolled", Image = "Assets/Apple-Cinnamon-Porridge.jpg" });
            //items.Add(new RecipeItem() { Id = 2, Category = "Breakfast", RecipeName = "Pancakes", Ingredients = "1 tblsp caster sugar", Image = "Assets/Banana-Pancakes.jpg" });
            //items.Add(new RecipeItem() { Id = 3, Category = "Breakfast", RecipeName = "Eggs-Benedict", Ingredients = "Juice of ½ lemon", Image = "Assets/Eggs-Benedict.jpg" });

            //items.Add(new RecipeItem() { Id = 4, Category = "Dinner", RecipeName = "Sweet-Sour-Chicken", Ingredients = "2 tsp water", Image = "Assets/Sweet-Sour-Chicken-2.jpg" });
            //items.Add(new RecipeItem() { Id = 5, Category = "Dinner", RecipeName = "Shepherds Pie", Ingredients = "2 tbsp of olive oil", Image = "Assets/Shepherds-Pie.jpg" });
            //items.Add(new RecipeItem() { Id = 6, Category = "Dinner", RecipeName = "Spaghetti", Ingredients = "400g spaghetti", Image = "Assets/Spaghetti-Bolgnese.jpg" });


            return items;
        }

    }
}

