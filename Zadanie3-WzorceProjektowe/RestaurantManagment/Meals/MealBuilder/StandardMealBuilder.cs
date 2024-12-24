namespace RestaurantManagment.Meals.MealsBuilder
{
    class StandardMealBuilder : MealBuilder
    {
        public override void SetMainCourse<StandardMainCourseOptions>(StandardMainCourseOptions mainCourse)
        {
            if (mainCourse != null)
            {
                meal.MainCourse = mainCourse.ToString();
            }
        }

        public override void SetFirstSideDish<StandardFirstSideDishOptions>(StandardFirstSideDishOptions firstSideDish)
        {
            if (firstSideDish != null)
            {
                meal.FirstSideDish = firstSideDish.ToString();
            }
        }

        public override void SetSecondSideDish<StandardSecondSideDishOptions>(StandardSecondSideDishOptions secondSideDish)
        {
            if (secondSideDish != null)
            {
                meal.SecondSideDish = secondSideDish.ToString();
            }
        }
    }

    enum StandardMainCourseOptions
    {
        Porkchop
    }

    enum StandardFirstSideDishOptions
    {
        Potatoes
    }

    enum StandardSecondSideDishOptions
    {
        Salad
    }
}
