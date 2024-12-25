namespace RestaurantManagment.Meals.MealBuilders
{
    class BurgerMealBuilder : MealBuilder<BurgerMainCourseOption, BurgerFirstSideDishOption, BurgerSecondSideDishOption>
    {
        private readonly Dictionary<Enum, double> MealItemPrices = new()
        {
            { BurgerMainCourseOption.Standard, 16.99 },

            { BurgerFirstSideDishOption.Fries, 7.99 },

            { BurgerSecondSideDishOption.Salad, 5.50 },
        };

        public override void SetMainCourse(BurgerMainCourseOption mainCourse = BurgerMainCourseOption.Standard)
        {
            if (!MealItemPrices.TryGetValue(mainCourse, out double price))
            {
                mainCourse = BurgerMainCourseOption.Standard;
                price = MealItemPrices.GetValueOrDefault(mainCourse, 20);
            }

            meal.MainCourse = new MealItem("Burger " + mainCourse.ToString(), price);
        }

        public override void SetFirstSideDish(BurgerFirstSideDishOption firstSideDish = BurgerFirstSideDishOption.Fries)
        {
            if (!MealItemPrices.TryGetValue(firstSideDish, out double price))
            {
                firstSideDish = BurgerFirstSideDishOption.Fries;
                price = MealItemPrices.GetValueOrDefault(firstSideDish, 10);
            }

            meal.FirstSideDish = new MealItem(firstSideDish.ToString(), price);
        }

        public override void SetSecondSideDish(BurgerSecondSideDishOption secondSideDish = BurgerSecondSideDishOption.Salad)
        {
            if (!MealItemPrices.TryGetValue(secondSideDish, out double price))
            {
                secondSideDish = BurgerSecondSideDishOption.Salad;
                price = MealItemPrices.GetValueOrDefault(secondSideDish, 8);
            }

            meal.SecondSideDish = new MealItem(secondSideDish.ToString(), price);
        }
    }

    enum BurgerMainCourseOption
    {
        Standard
    }

    enum BurgerFirstSideDishOption
    {
        Fries
    }

    enum BurgerSecondSideDishOption
    {
        Salad
    }
}
