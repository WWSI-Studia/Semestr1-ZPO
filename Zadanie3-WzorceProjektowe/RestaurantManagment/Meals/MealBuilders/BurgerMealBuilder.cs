namespace RestaurantManagment.Meals.MealBuilders
{
    class BurgerMealBuilder : IMealBuilder<BurgerMainCourseOption, BurgerFirstSideDishOption, BurgerSecondSideDishOption>
    {
        private BurgerMeal _burgerMeal = new();
        private readonly Dictionary<Enum, double> MealItemPrices = new()
        {
            { BurgerMainCourseOption.Standard, 16.99 },
            { BurgerMainCourseOption.Spicy, 18.99 },

            { BurgerFirstSideDishOption.Fries, 7.99 },
            { BurgerFirstSideDishOption.Curly_Fries, 9.90 },
            { BurgerFirstSideDishOption.Corn, 6.99 },

            { BurgerSecondSideDishOption.Salad, 5.50 },
            { BurgerSecondSideDishOption.Coleslaw, 5.50 }
        };

        public void Reset()
        {
            _burgerMeal = new();
        }

        public BurgerMeal GetMeal()
        {
            return _burgerMeal;
        }

        public void SetDefaultMeal()
        {
            BurgerMainCourseOption mainCourse = BurgerMainCourseOption.Standard;
            BurgerFirstSideDishOption firstSideDish = BurgerFirstSideDishOption.Fries;
            BurgerSecondSideDishOption secondSideDish = BurgerSecondSideDishOption.Salad;

            double mainCoursePrice = MealItemPrices.GetValueOrDefault(mainCourse, 20);
            double firstSideDishPrice = MealItemPrices.GetValueOrDefault(firstSideDish, 20);
            double secondSideDishPrice = MealItemPrices.GetValueOrDefault(secondSideDish, 20);

            _burgerMeal.SetMainCourse(mainCourse, mainCoursePrice);
            _burgerMeal.SetFirstSideDish(firstSideDish, firstSideDishPrice);
            _burgerMeal.SetSecondSideDish(secondSideDish, secondSideDishPrice);
        }

        public void SetMainCourse(BurgerMainCourseOption mainCourse = BurgerMainCourseOption.Standard)
        {
            if (!MealItemPrices.TryGetValue(mainCourse, out double price))
            {
                mainCourse = BurgerMainCourseOption.Standard;
                price = MealItemPrices.GetValueOrDefault(mainCourse, 20);
            }

            _burgerMeal.SetMainCourse(mainCourse, price);
        }

        public void SetFirstSideDish(BurgerFirstSideDishOption firstSideDish = BurgerFirstSideDishOption.Fries)
        {
            if (!MealItemPrices.TryGetValue(firstSideDish, out double price))
            {
                firstSideDish = BurgerFirstSideDishOption.Fries;
                price = MealItemPrices.GetValueOrDefault(firstSideDish, 10);
            }

            _burgerMeal.SetFirstSideDish(firstSideDish, price);
        }

        public void SetSecondSideDish(BurgerSecondSideDishOption secondSideDish = BurgerSecondSideDishOption.Salad)
        {
            if (!MealItemPrices.TryGetValue(secondSideDish, out double price))
            {
                secondSideDish = BurgerSecondSideDishOption.Salad;
                price = MealItemPrices.GetValueOrDefault(secondSideDish, 8);
            }

            _burgerMeal.SetSecondSideDish(secondSideDish, price);
        }
    }
}
