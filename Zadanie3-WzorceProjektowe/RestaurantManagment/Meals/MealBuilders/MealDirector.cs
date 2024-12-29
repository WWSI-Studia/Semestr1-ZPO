namespace RestaurantManagment.Meals.MealBuilders
{
    class MealDirector
    {
        public Meal CreateDefaultMeal<T, U, W>(IMealBuilder<T, U, W> standardMealBuilder)
        {
            standardMealBuilder.Reset();
            standardMealBuilder.SetDefaultMeal();

            return standardMealBuilder.Build();
        }

        public Meal CreateCustomMeal<T, U, W>(IMealBuilder<T, U, W> mealBuilder, T mainCourse, U? firstSideDish = null, W? secondSideDish = null) where U : struct where W : struct
        {
            mealBuilder.Reset();
            mealBuilder.SetMainCourse(mainCourse);

            if (firstSideDish != null)
            {
                mealBuilder.SetFirstSideDish(firstSideDish.Value);
            }

            if (secondSideDish != null)
            {
                mealBuilder.SetSecondSideDish(secondSideDish.Value);
            }

            return mealBuilder
                .Build();
        }
    }
}
