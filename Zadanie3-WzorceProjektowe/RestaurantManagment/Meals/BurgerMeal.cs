namespace RestaurantManagment.Meals
{
    class BurgerMeal : Meal
    {
        public void SetMainCourse(BurgerMainCourseOption mainCourseOption, double price)
        {
            MainCourse = new MealItem("Burger " + mainCourseOption.ToString(), price);
        }

        public void SetFirstSideDish(BurgerFirstSideDishOption firstSideDish, double price)
        {
            FirstSideDish = new MealItem(firstSideDish.ToString(), price);
        }

        public void SetSecondSideDish(BurgerSecondSideDishOption secondSideDish, double price)
        {
            SecondSideDish = new MealItem(secondSideDish.ToString(), price);
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
