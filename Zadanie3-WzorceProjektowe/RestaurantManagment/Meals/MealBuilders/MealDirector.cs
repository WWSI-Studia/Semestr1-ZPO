namespace RestaurantManagment.Meals.MealBuilders
{
    class MealDirector
    {
        public void CreateDefaultMeal<T, U, W>(IMealBuilder<T, U, W> standardMealBuilder)
        {
            standardMealBuilder.Reset();
            standardMealBuilder.SetDefaultMeal();
        }

        public void CreateCustomMeal<T, U, W>(IMealBuilder<T, U, W> mealBuilder, T mainCourse, U? firstSideDish = null, W? secondSideDish = null) where U : struct where W : struct
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
        }
    }
}
