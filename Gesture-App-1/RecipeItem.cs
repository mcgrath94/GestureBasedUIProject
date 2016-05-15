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
        public int PrepTime { get; set; }  //prep time
        public string Directions { get; set; }  //directions

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
            var filteredRecipeItems = allItems.Where(p => p.Level == level).ToList();
            recipeItems.Clear();
            filteredRecipeItems.ForEach(p => recipeItems.Add(p));
        }

        private static List<RecipeItem> getRecipeItems()
        {
            var items = new List<RecipeItem>();

            // ------- Breakfast Items --------
            items.Add(new RecipeItem() {
                Id = 1,
                Category = "Dinner",
                RecipeName = "Porridge",
                Level = "easyLevel",
                PrepTime = 10,
                Ingredients = "1 part Rolled Oats to 2 parts Milk, Pinch of Salt, 1 Apple, 2 tbsp Honey, handful toasted Pecans chopped",
                Directions = "Put oats in saucepan, add milk/water, add pinch of salt, bring to boil and simmer for 5 mins. Serve and add honey.",
                Image = "Assets/Recipes/Porridge.jpg" });

            items.Add(new RecipeItem() {
                Id = 2,
                Category = "Breakfast",
                RecipeName = "Pancakes",
                Level = "intermediateLevel",
                PrepTime = 25,
                Ingredients = "200g plain flour, 2 tsp baking powder, Pinch of sea salt, ½ tsp ground cinnamon, 220ml milk, 2 large eggs, A little butter, melted 50g toasted hazelnuts, roughly chopped, 75g butter, plus a knob 100g golden syrup, 8 mini bananas, halved lengthways, 1 tblsp caster sugar",
                Directions = "Put flour and pinch of salt in bowl. Add eggs, 50ml milk, 1tbsp oil and whisk until smooth thick paste.Add rest of milk while continuing to whisk. Oil pan and heat for 2 mins.Pour batter on - leave for  30 seconds and then flip.Repeat on other side.",
                Image = "Assets/Recipes/Pancakes.jpg" });

            items.Add(new RecipeItem() {
                Id = 3,
                Category = "Breakfast",
                RecipeName = "Eggs-Benedict",
                Level = "hardLevel",
                PrepTime = 20,
                Ingredients = "4 eggs, 2 toasting muffins, hollandaise sauce, 4 slices parma ham, 3 tbsp white wine vinegar",
                Directions = "Bring saucepan of water to boil, add viengar.Break eggs into sepearte mugs and toast muffins.Swirl water and slide in egg.Cook for 2 - 3 mins, then remove.Spread some sauce on muffin, add ham, top with egg and sauce.",
                Image = "Assets/Recipes/Eggs-Benedict.jpg" });

            items.Add(new RecipeItem()
            {
                Id = 4,
                Category = "Breakfast",
                RecipeName = "Breakfast Bagel",
                Level = "easyLevel",
                PrepTime = 10,
                Ingredients = "50g cream cheese, 2 bagels, halved and lightly toasted, 100g smoked salmon, 1 avocado, ½ lemon, 1 tbsp olive oil, 2 eggs, pinch of cayenne pepper",
                Directions = "Spread the cream cheese over both halves of the toasted bagels. Add the salmon to the bottom halves, then top with the avocado. Squeeze over lemon juice. Heat oil in non-stick frying pan. When hot, crack in the eggs, season and cook for 2-3 mins until the white is set and crisp around edges. Sit eggs on top of each bagel base and sprinkle cayenne on each. Serve with lemon wedges on the side",
                Image = ""
            });

            items.Add(new RecipeItem()
            {
                Id = 5,
                Category = "Breakfast",
                RecipeName = "French Toast",
                Level = "intermediateLevel",
                PrepTime = 15,
                Ingredients = "4 tbsp soft butter, 2 tsp cinnamon, 2 egg, beaten 100ml milk, 4 hot cross bun, split in half vanilla ice cream and maple syrup, to serve",
                Directions = "Mix 3 tbsp of the butter with half the cinnamon. Beat together egg, milk and remaining cinnamon. Sandwich 2 slices of hot cross bun together with half cinnamon butter and repeat with the remaining two slices. Dip in the egg mix. Heat butter in pan until foaming. Cook hot cross buns each side until light golden. Serve topped with scoop of ice cream and a drizzle of maple syrup.",
                Image = ""
            });


            // ------- Dinner Items --------
            items.Add(new RecipeItem() {
                Id = 6,
                Category = "Dinner",
                RecipeName = "Sweet-Sour-Chicken",
                Level = "easyLevel",
                PrepTime = 25,
                Ingredients = "4 free range chicken breasts, 1 tbsp of rice wine, 1 tbsp of light soy sauce, ½ teaspoon salt, 1 green pepper, cut in 1 inch sqaures, 1 red pepper, cut in 1 inch sqaures, 6 spring onions - finely sliced, 1 egg - beaten, 2 tbsp cornflour, Sunflower oil for frying, For the sauce: 300ml of chicken stock, 2 tbsp light soy sauce, 1 tsp of salt, 4 tbsp Chinese white rice vinegar, 2 tbsp caster sugar, 2 tbsp tomato puree, 2 tsp cornflour, 2 tsp water",
                Directions = "Mix ketchup, vinegar, sugar and garlic thoroughly with the chicken, onion and peppers. Microwave, uncovered, on High for 8-10 minutes. Stir in the pineapple pieces and sugar snap peas and return to the microwave for another 3-5 minutes until chicken completely cooked. Leave to stand for a few minutes, then serve.",
                Image = "Assets/Recipes/Sweet-Sour-Chicken-2.jpg" });

            items.Add(new RecipeItem() {
                Id = 7,
                Category = "Dinner",
                RecipeName = "Shepherds Pie",
                Level = "hardLevel",
                PrepTime = 155,
                Ingredients = "2 tbsp of olive oil, 1 large onion, chopped 2 - 3 medium carrots, chopped 700g minced lamb, 2 tbsp of thyme roughly chopped, 400ml beef stock, 2 tbsp tomato purée, 2 tsp of Worcestershire sauce, 400ml beef stock, 2 tbsp of thyme, roughly chopped, 1.75 lbs potatoes, peeled and cut into chunks, 75g butter, 100ml milk, 6 spring onions - finely sliced, Sea salt and ground black pepper to season",
                Directions = "Heat butter in pan, gently fry onions, carrots, celery and garlic for 15 mins. Turn up heat, add mushrooms, cook for 4 mins more. Stir in herbs, add lentils. Pour over wine and stock. Simmer for 40-50 mins until lentils very soft. Take off heat, then stir in the tomato purée. While the lentils cooking, tip potatoes into pan of water, then boil for about 15 mins until tender. Drain well, mash with butter and milk, then season with salt and pepper. To assemble the pies, divide the lentil mixture between all the dishes that you are using, then top with mash. Scatter over cheese, heat oven to 190C and bake for 30 mins until golden.",
                Image = "Assets/Recipes/Shepherds-Pie.jpg" });

            items.Add(new RecipeItem() {
                Id = 8,
                Category = "Dinner",
                RecipeName = "Spaghetti Meatballs",
                Level = "easyLevel",
                PrepTime = 55,
                Ingredients = "400g spaghetti, 2 tbsp olive oil, 500g beef mince, 8 rashers smoked streaky bacon, roughly chopped 1 onion -finely chopped, 2 garlic cloves- finely chopped, 1 small carrot, grated 75g mushrooms - finely chopped, 2 x 400g tins chopped tomatoes, 1 tbsp tomato purée, 250ml red wine, 1 tsp dried oregano, Handful of fresh basil - chopped, Finely grated parmesan cheese to serve",
                Directions = "First make meatballs. Split the sausage skins and squeeze out the meat into mixing bowl. Add mince, onion, parsley, Parmesan, breadcrumbs, beaten eggs and lots of seasoning. Mix well, heat oven to 220C. Roll mince mixture into golf-ball-size meatballs. Spread meatballs out in large roasting tin. Drizzle with little oil, shake to coat, then roast for 20-30 mins until browned. Heat oil in pan, add garlic and sizzle for 1 min. Stir in tomatoes, sugar, parsley and seasoning. Simmer for 15-20 mins until slightly thickened. Add cooked meatballs to pan to keep warm while boiling spaghetti. Spoon sauce and meatballs over spaghetti, and serve with Parmesan.",
                Image = "Assets/Recipes/Spaghetti-Bolgnese.jpg" });

            items.Add(new RecipeItem()
            {
                Id = 9,
                Category = "Dinner",
                RecipeName = "One pan roast",
                Level = "intermediateLevel",
                PrepTime = 90,
                Ingredients = "1½ kg chicken, 1 lemon, 50g softened butter, 2 tsp dried mixed herbs, 750g potatoes, about 7 carrots, 2 tbsp olive oil, 100g frozen peas, 300ml chicken stock, 1 tsp Marmite",
                Directions = "Heat oven to 220C. Place chicken in roasting tin. Shove lemon halves in cavity. Rub butter, herbs and seasoning over  chicken. Put potatoes and carrots around it, drizzle with oil, season and toss together. Roast for 20 mins, then turn oven down to 200C and roast for 50 mins. Stir peas, stock and Marmite into veg in the tin, return to oven for 10 mins",
                Image = ""
            });

            items.Add(new RecipeItem()
            {
                Id = 10,
                Category = "Dinner",
                RecipeName = "Chicken Chorizo Jambalaya",
                Level = "intermediateLevel",
                PrepTime = 50,
                Ingredients = "1 tbsp olive oil, 2 chicken breast, 1 onion, 1 red pepper, 2 garlic cloves, 75g chorizo, 1 tbsp Cajun seasoning, 250g long grain rice, 400g can plum tomato, 350ml chicken stock",
                Directions = "Heat oil in pan and brown the chicken until golden. Tip in onion and cook for 3-4 mins. Then add the pepper, garlic, chorizo and Cajun seasoning, cook for 5 mins. Stir chicken back in with rice, add tomatoes and stock. Simmer for 20-25 mins until the rice is tender.",
                Image = "Assets/Recipes/Spaghetti-Bolgnese.jpg"
            });


            return items;
        }

    }
}

