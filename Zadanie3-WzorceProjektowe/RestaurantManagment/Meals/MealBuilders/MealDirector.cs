namespace RestaurantManagment.Meals.MealBuilders
{
    class MealDirector
    {
        private readonly StandardMealBuilder _standardMealbuilder;
        private readonly BurgerMealBuilder _burgerMealBuilder;

        public MealDirector()
        {
            _standardMealbuilder = new StandardMealBuilder();
            _burgerMealBuilder = new BurgerMealBuilder();
        }
        // TODO - builder jako argument metody / konstruktora
        public Meal CreateDefaultStandardMeal()
        {
            _standardMealbuilder.Reset();
            _standardMealbuilder.SetMainCourse(StandardMainCourseOption.Porkchop);
            _standardMealbuilder.SetFirstSideDish(StandardFirstSideDishOption.Potatoes);
            _standardMealbuilder.SetSecondSideDish(StandardSecondSideDishOption.Salad);

            return _standardMealbuilder.Build();
        }

        public Meal CreateCustomStandardMeal(
            StandardMainCourseOption mainCourse,
            StandardFirstSideDishOption? firstSideDish,
            StandardSecondSideDishOption? secondSideDish
        )
        {
            _standardMealbuilder.Reset();
            _standardMealbuilder.SetMainCourse(mainCourse);

            if (firstSideDish != null)
            {
                _standardMealbuilder.SetFirstSideDish(firstSideDish.Value);
            }

            if (secondSideDish != null)
            {
                _standardMealbuilder.SetSecondSideDish(secondSideDish.Value);
            }

            return _standardMealbuilder.Build();
        }

        public Meal CreateDefaultBurgerMeal()
        {
            _burgerMealBuilder.Reset();
            _burgerMealBuilder.SetMainCourse(BurgerMainCourseOption.Standard);
            _burgerMealBuilder.SetFirstSideDish(BurgerFirstSideDishOption.Fries);
            _burgerMealBuilder.SetSecondSideDish(BurgerSecondSideDishOption.Salad);

            return _burgerMealBuilder.Build();
        }

        public Meal CreateCustomBurgerMeal(
            BurgerMainCourseOption mainCourse,
            BurgerFirstSideDishOption? firstSideDish,
            BurgerSecondSideDishOption? secondSideDish
        )
        {
            _burgerMealBuilder.Reset();
            _burgerMealBuilder.SetMainCourse(mainCourse);

            if (firstSideDish != null)
            {
                _burgerMealBuilder.SetFirstSideDish(firstSideDish.Value);
            }

            if (secondSideDish != null)
            {
                _burgerMealBuilder.SetSecondSideDish(secondSideDish.Value);
            }

            return _burgerMealBuilder.Build();
        }
    }
}
