namespace RestaurantManagment.Meals.MealBuilders
{
    class StandardMealBuilder : MealBuilder<StandardMainCourseOption, StandardFirstSideDishOption, StandardSecondSideDishOption>
    {
        private readonly Dictionary<Enum, double> MealItemPrices = new()
        {
            { StandardMainCourseOption.Porkchop, 18 },

            { StandardFirstSideDishOption.Potatoes, 5.99 },

            { StandardSecondSideDishOption.Salad, 5.50 },
        };

        public override void SetMainCourse(StandardMainCourseOption mainCourse = StandardMainCourseOption.Porkchop)
        {
            if (!MealItemPrices.TryGetValue(mainCourse, out double price))
            {
                mainCourse = StandardMainCourseOption.Porkchop;
                price = MealItemPrices.GetValueOrDefault(mainCourse, 20);
            }

            meal.MainCourse = new MealItem(mainCourse.ToString(), price);
        }

        public override void SetFirstSideDish(StandardFirstSideDishOption firstSideDish = StandardFirstSideDishOption.Potatoes)
        {
            if (!MealItemPrices.TryGetValue(firstSideDish, out double price))
            {
                firstSideDish = StandardFirstSideDishOption.Potatoes;
                price = MealItemPrices.GetValueOrDefault(firstSideDish, 10);
            }

            meal.FirstSideDish = new MealItem(firstSideDish.ToString(), price);
        }

        public override void SetSecondSideDish(StandardSecondSideDishOption secondSideDish = StandardSecondSideDishOption.Salad)
        {
            if (!MealItemPrices.TryGetValue(secondSideDish, out double price))
            {
                secondSideDish = StandardSecondSideDishOption.Salad;
                price = MealItemPrices.GetValueOrDefault(secondSideDish, 8);
            }

            meal.SecondSideDish = new MealItem(secondSideDish.ToString(), price);
        }
    }

    enum StandardMainCourseOption
    {
        Porkchop
    }

    enum StandardFirstSideDishOption
    {
        Potatoes
    }

    enum StandardSecondSideDishOption
    {
        Salad
    }
}
