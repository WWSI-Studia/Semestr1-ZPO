using RestaurantManagment.Meals.MealsBuilder;

namespace RestaurantManagment.Meals.MealBuilder
{
    class MealDirector
    {
        private readonly StandardMealBuilder _standardMealbuilder;
        private readonly BurgerMealBuilder burgerMealBuilder;

        public MealDirector()
        {
            _standardMealbuilder = new StandardMealBuilder();
            burgerMealBuilder = new BurgerMealBuilder();
        }

        public Meal CreateDefaultStandardMeal(
        )
        {
            _standardMealbuilder.Reset();
            _standardMealbuilder.SetMainCourse(StandardMainCourseOptions.Porkchop);
            _standardMealbuilder.SetFirstSideDish(StandardFirstSideDishOptions.Potatoes);
            _standardMealbuilder.SetSecondSideDish(StandardSecondSideDishOptions.Salad);

            return _standardMealbuilder.Build();
        }

        public Meal CreateCustomStandardMeal(
            StandardMainCourseOptions mainCourse,
            StandardFirstSideDishOptions? firstSideDish,
            StandardSecondSideDishOptions? secondSideDish
        )
        {
            _standardMealbuilder.Reset();
            _standardMealbuilder.SetMainCourse(mainCourse);
            _standardMealbuilder.SetFirstSideDish(firstSideDish);
            _standardMealbuilder.SetSecondSideDish(secondSideDish);

            return _standardMealbuilder.Build();
        }

        public Meal CreateDefaultBurgerMeal()
        {
            _standardMealbuilder.Reset();
            _standardMealbuilder.SetMainCourse(BurgerMainCourseOptions.Standard);
            _standardMealbuilder.SetFirstSideDish(BurgerFirstSideDishOptions.Fries);
            _standardMealbuilder.SetSecondSideDish(BurgerSecondSideDishOptions.Salad);

            return _standardMealbuilder.Build();
        }

        public Meal CreateCustomBurgerMeal(
            BurgerMainCourseOptions mainCourse,
            BurgerFirstSideDishOptions? firstSideDish,
            BurgerSecondSideDishOptions? secondSideDish
        )
        {
            _standardMealbuilder.Reset();
            _standardMealbuilder.SetMainCourse(mainCourse);
            _standardMealbuilder.SetFirstSideDish(firstSideDish);
            _standardMealbuilder.SetSecondSideDish(secondSideDish);

            return _standardMealbuilder.Build();
        }
    }
}
