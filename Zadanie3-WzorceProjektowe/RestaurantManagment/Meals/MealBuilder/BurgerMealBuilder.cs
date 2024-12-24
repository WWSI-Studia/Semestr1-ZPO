namespace RestaurantManagment.Meals.MealsBuilder
{
    class BurgerMealBuilder : MealBuilder
    {
        public override void SetMainCourse<BurgerMainCourseOptions>(BurgerMainCourseOptions mainCourse)
        {
            if (mainCourse != null)
            {
                meal.MainCourse = mainCourse.ToString();
            }
        }

        public override void SetFirstSideDish<BurgerFirstSideDishOptions>(BurgerFirstSideDishOptions firstSideDish)
        {
            if (firstSideDish != null)
            {
                meal.FirstSideDish = firstSideDish.ToString();
            }
        }

        public override void SetSecondSideDish<BurgerSecondSideDishOptions>(BurgerSecondSideDishOptions secondSideDish)
        {
            if (secondSideDish != null)
            {
                meal.SecondSideDish = secondSideDish.ToString();
            }
        }
    }

    enum BurgerMainCourseOptions
    {
        Standard
    }

    enum BurgerFirstSideDishOptions
    {
        Fries
    }

    enum BurgerSecondSideDishOptions
    {
        Salad
    }
}
