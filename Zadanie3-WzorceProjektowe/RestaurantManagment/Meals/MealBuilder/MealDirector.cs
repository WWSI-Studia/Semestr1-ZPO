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

        public Meal CreateStandardMeal(
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

        public Meal CreateBurgerMeal(
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
