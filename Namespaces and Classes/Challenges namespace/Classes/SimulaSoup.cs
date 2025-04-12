namespace Challenges
{
    public static class SimulaSoup
    {
        public static void Run() // challenge on page 143
        {
            SpiceType spiceSelection;
            IngredientType ingredientSelection;
            FoodType foodSelection;

            Console.WriteLine("*** If you don't choose an item from the menu, we will choose for you ***");
            Console.WriteLine("MENU");
            Console.WriteLine("--------------------");
            Console.WriteLine($"SPICES: {SpiceType.Spicy}, {SpiceType.Salty}, {SpiceType.Sweet}");
            Console.WriteLine($"INGREDIENT: {IngredientType.Mushroom}, {IngredientType.Carrot}, {IngredientType.Potatoe}, {IngredientType.Chicken}");
            Console.WriteLine($"FOOD: {FoodType.Soup}, {FoodType.Stew}, {FoodType.Gumbo}");
            Console.WriteLine("--------------------");

            string userSelection = userChoice("SPICE");
            spiceSelection = userSelection switch
            {
                "SPICY" => SpiceType.Spicy,
                "SALTY" => SpiceType.Salty,
                "SWEET" => SpiceType.Sweet,
                _ => SpiceType.Spicy
            };

            userSelection = userChoice("INGREDIENT");
            ingredientSelection = userSelection switch
            {
                "MUSHROOM" => IngredientType.Mushroom,
                "CARROT" => IngredientType.Carrot,
                "POTATOE" => IngredientType.Potatoe,
                "CHICKEN" => IngredientType.Chicken,
                _ => IngredientType.Mushroom
            };

            userSelection = userChoice("FOOD");
            foodSelection = userSelection switch
            {
                "SOUP" => FoodType.Soup,
                "STEW" => FoodType.Stew,
                "GUMBO" => FoodType.Gumbo,
                _ => FoodType.Soup
            };

            string userChoice(string type)
            {
                string userSelection;
                Console.WriteLine("Choose a Spice, Ingredient, Food");
                Console.Write($"{type}: ");
                userSelection = Console.ReadLine().ToUpper();
                Console.WriteLine("--------------------");
                return userSelection;
            }

            Console.WriteLine($"{spiceSelection} {ingredientSelection} {foodSelection}");
        }

        internal enum SpiceType
        {
            Spicy,
            Salty,
            Sweet
        }
        internal enum IngredientType
        {
            Mushroom,
            Chicken,
            Carrot,
            Potatoe
        }

        internal enum FoodType
        {
            Soup,
            Stew,
            Gumbo
        }
    }
}
