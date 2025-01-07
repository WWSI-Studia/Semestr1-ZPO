namespace RestaurantManagment.Meals.MealBuilders
{
    public class StandardMealBuilder : IMealBuilder<StandardMainCourseOption, StandardFirstSideDishOption, StandardSecondSideDishOption>
    {
        private StandardMeal _standardMeal = new();
        private readonly Dictionary<Enum, double> MealItemPrices = new()
        {
            { StandardMainCourseOption.Porkchop, 18 },
            { StandardMainCourseOption.Chicken, 16 },
            { StandardMainCourseOption.Beef_Welington, 40 },

            { StandardFirstSideDishOption.Potatoes, 5.99 },
            { StandardFirstSideDishOption.Baked_Potatoes, 8 },

            { StandardSecondSideDishOption.Salad, 5.50 },
            { StandardSecondSideDishOption.Asparagus, 6.50 },
        };

        public void Reset()
        {
            _standardMeal = new();
        }

        public StandardMeal GetMeal()
        {
            return _standardMeal;
        }

        public void SetDefaultMeal()
        {
            StandardMainCourseOption mainCourse = StandardMainCourseOption.Porkchop;
            StandardFirstSideDishOption firstSideDish = StandardFirstSideDishOption.Potatoes;
            StandardSecondSideDishOption secondSideDish = StandardSecondSideDishOption.Salad;

            double mainCoursePrice = MealItemPrices.GetValueOrDefault(mainCourse, 20);
            double firstSideDishPrice = MealItemPrices.GetValueOrDefault(firstSideDish, 20);
            double secondSideDishPrice = MealItemPrices.GetValueOrDefault(secondSideDish, 20);

            _standardMeal.SetMainCourse(mainCourse, mainCoursePrice);
            _standardMeal.SetFirstSideDish(firstSideDish, firstSideDishPrice);
            _standardMeal.SetSecondSideDish(secondSideDish, secondSideDishPrice);
        }


        public void SetMainCourse(StandardMainCourseOption mainCourse = StandardMainCourseOption.Porkchop)
        {
            if (!MealItemPrices.TryGetValue(mainCourse, out double price))
            {
                mainCourse = StandardMainCourseOption.Porkchop;
                price = MealItemPrices.GetValueOrDefault(mainCourse, 20);
            }

            _standardMeal.SetMainCourse(mainCourse, price);
        }

        public void SetFirstSideDish(StandardFirstSideDishOption firstSideDish = StandardFirstSideDishOption.Potatoes)
        {
            if (!MealItemPrices.TryGetValue(firstSideDish, out double price))
            {
                firstSideDish = StandardFirstSideDishOption.Potatoes;
                price = MealItemPrices.GetValueOrDefault(firstSideDish, 10);
            }

            _standardMeal.SetFirstSideDish(firstSideDish, price);
        }

        public void SetSecondSideDish(StandardSecondSideDishOption secondSideDish = StandardSecondSideDishOption.Salad)
        {
            if (!MealItemPrices.TryGetValue(secondSideDish, out double price))
            {
                secondSideDish = StandardSecondSideDishOption.Salad;
                price = MealItemPrices.GetValueOrDefault(secondSideDish, 8);
            }

            _standardMeal.SetSecondSideDish(secondSideDish, price);
        }
    }
}
